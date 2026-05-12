using System;

namespace CurrencyConverterApp
{
    public class CurrencyConverter
    {
        private readonly CurrencyRateService _rateService;


        public CurrencyConverter(CurrencyRateService rateService = null)
        {
            _rateService = rateService ?? new CurrencyRateService();
        }

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            // Валидация суммы
            if (amount < 0)
                throw new ArgumentException("Сумма не может быть отрицательной.");

            if (string.IsNullOrWhiteSpace(fromCurrency) || string.IsNullOrWhiteSpace(toCurrency))
                throw new ArgumentException("Коды валют не могут быть пустыми.");

            // Попытка получить актуальный курс
            var (success, rate) = _rateService.GetRate(fromCurrency, toCurrency);

            if (!success)
                throw new NotSupportedException($"Не поддерживаемая пара валют: {fromCurrency}/{toCurrency}");

            return amount * rate;
        }

        /// <summary>
        /// Получение текущего курса для отображения в UI
        /// </summary>
        public string GetCurrentRateInfo(string from, string to)
        {
            var (success, rate) = _rateService.GetRate(from, to);
            if (success)
                return $"1 {from} = {rate:F4} {to}";
            return "Курс недоступен";
        }

        /// <summary>
        /// Принудительное обновление курсов
        /// </summary>
        public async System.Threading.Tasks.Task<bool> RefreshRatesAsync()
        {
            return await _rateService.FetchRatesAsync();
        }
    }
}