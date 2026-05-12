using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyConverterApp
{
    /// <summary>
    /// Сервис для получения актуальных курсов валют из внешнего API
    /// </summary>
    public class CurrencyRateService
    {
        private static readonly string OPEN_API_URL = "https://open.er-api.com/v6/latest/";
        private readonly HttpClient _httpClient;

        // Кэш последних успешных курсов (для работы при ошибке API)
        private decimal? _cachedUsdToEur;
        private decimal? _cachedEurToUsd;
        private DateTime _lastUpdate;
        private readonly TimeSpan _updateInterval;

        public event Action<string> OnRateUpdated;      // Событие: курсы обновлены
        public event Action<string> OnError;            // Событие: ошибка получения

        public CurrencyRateService(TimeSpan? updateInterval = null)
        {
            _httpClient = new HttpClient();
            _updateInterval = updateInterval ?? TimeSpan.FromMinutes(10);
            _lastUpdate = DateTime.MinValue;
        }

        /// <summary>
        /// Получение курсов валют из открытого API (без ключа)
        /// Источник: https://www.exchangerate-api.com/docs/free [[1]]
        /// </summary>
        public async Task<bool> FetchRatesAsync(string baseCurrency = "USD")
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{OPEN_API_URL}{baseCurrency}");
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

                if (apiResponse?.result == "success" && apiResponse.rates != null)
                {
                    // Обновляем кэш
                    if (apiResponse.rates.TryGetValue("EUR", out var eurRate))
                    {
                        if (baseCurrency == "USD")
                        {
                            _cachedUsdToEur = (decimal)eurRate;
                            _cachedEurToUsd = eurRate > 0 ? (decimal)(1.0 / eurRate) : _cachedEurToUsd;
                        }
                        else if (baseCurrency == "EUR")
                        {
                            _cachedEurToUsd = (decimal)eurRate;
                            _cachedUsdToEur = eurRate > 0 ? (decimal)(1.0 / eurRate) : _cachedUsdToEur;
                        }
                    }

                    _lastUpdate = DateTime.UtcNow;
                    OnRateUpdated?.Invoke($"Курсы обновлены: {DateTime.Now:HH:mm}");
                    return true;
                }

                OnError?.Invoke("Некорректный ответ от API");
                return false;
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Ошибка сети: {ex.Message}. Используются последние доступные курсы.");
                return false;
            }
        }

        /// <summary>
        /// Получение курса с использованием кэша при ошибке API
        /// </summary>
        public (bool success, decimal rate) GetRate(string from, string to)
        {
            // Если курсы ещё не загружены или устарели - пробуем обновить
            if (_cachedUsdToEur == null ||
                DateTime.UtcNow - _lastUpdate > _updateInterval)
            {
                // Синхронный вызов для простоты (в продакшене лучше async/await)
                FetchRatesAsync().Wait(5000); // Таймаут 5 секунд
            }

            if (from == "USD" && to == "EUR" && _cachedUsdToEur.HasValue)
                return (true, _cachedUsdToEur.Value);

            if (from == "EUR" && to == "USD" && _cachedEurToUsd.HasValue)
                return (true, _cachedEurToUsd.Value);

            // Fallback на дефолтные значения
            if (from == "USD" && to == "EUR")
                return (true, 0.88m);
            if (from == "EUR" && to == "USD")
                return (true, 1.12m);

            return (false, 0);
        }

        public DateTime LastUpdate => _lastUpdate;
    }

    /// <summary>
    /// Модель ответа от API
    /// </summary>
    public class ApiResponse
    {
        public string result { get; set; }
        public string base_code { get; set; }
        public Dictionary<string, double> rates { get; set; }
        public long time_last_update_unix { get; set; }
    }
}