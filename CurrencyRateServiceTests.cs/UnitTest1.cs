using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverterApp;
using System;
using System.Threading.Tasks;

namespace CurrencyConverterTests
{
    [TestClass]
    public class CurrencyRateServiceTests
    {
        private CurrencyRateService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new CurrencyRateService(TimeSpan.FromMinutes(1));
        }

        #region Тесты получения курсов

        [TestMethod]
        public async Task FetchRatesAsync_ValidResponse_ReturnsTrue()
        {
            // Act
            var result = await _service.FetchRatesAsync("USD");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task FetchRatesAsync_UpdatesLastUpdateTime()
        {
            // Arrange
            var beforeFetch = DateTime.UtcNow;

            // Act
            await _service.FetchRatesAsync("USD");
            var afterFetch = _service.LastUpdate;

            // Assert
            Assert.IsTrue(afterFetch >= beforeFetch);
        }

        #endregion

        #region Тесты GetRate

        [TestMethod]
        public void GetRate_USD_to_EUR_ReturnsSuccess()
        {
            // Arrange
            _service.FetchRatesAsync("USD").Wait();

            // Act
            var (success, rate) = _service.GetRate("USD", "EUR");

            // Assert
            Assert.IsTrue(success);
            Assert.IsTrue(rate > 0);
        }

        [TestMethod]
        public void GetRate_EUR_to_USD_ReturnsSuccess()
        {
            // Arrange
            _service.FetchRatesAsync("EUR").Wait();

            // Act
            var (success, rate) = _service.GetRate("EUR", "USD");

            // Assert
            Assert.IsTrue(success);
            Assert.IsTrue(rate > 0);
        }

        [TestMethod]
        public void GetRate_UnsupportedCurrency_ReturnsFalse()
        {
            // Act
            var (success, rate) = _service.GetRate("USD", "RUB");

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(0, rate);
        }

   

        #endregion

        #region Тесты кэширования

        [TestMethod]
        public async Task GetRate_AfterFetch_UsesCachedValue()
        {
            // Arrange
            await _service.FetchRatesAsync("USD");
            var firstCall = _service.GetRate("USD", "EUR");

            // Act
            var secondCall = _service.GetRate("USD", "EUR");

            // Assert
            Assert.AreEqual(firstCall.rate, secondCall.rate);
        }

        [TestMethod]
        public void GetRate_WithExpiredCache_FetchesNewRates()
        {
            // Arrange
            var serviceWithShortCache = new CurrencyRateService(TimeSpan.FromMilliseconds(100));
            serviceWithShortCache.FetchRatesAsync("USD").Wait();

            // Ждём истечения кэша
            System.Threading.Thread.Sleep(150);

            // Act
            var result = serviceWithShortCache.GetRate("USD", "EUR");

            // Assert
            Assert.IsTrue(result.success);
        }

        #endregion

        #region Тесты обработки ошибок

        [TestMethod]
        public async Task FetchRatesAsync_InvalidBaseCurrency_HandlesGracefully()
        {
            // Act
            var result = await _service.FetchRatesAsync("INVALID");

            // Assert - должен вернуть false или обработать ошибку
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetRate_InvalidCurrencyPair_ReturnsFalse()
        {
            // Act
            var (success, rate) = _service.GetRate("INVALID1", "INVALID2");

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(0, rate);
        }

        #endregion

        #region Тесты событий

        [TestMethod]
        public async Task FetchRatesAsync_RaisesOnRateUpdatedEvent()
        {
            // Arrange
            bool eventRaised = false;
            _service.OnRateUpdated += (msg) => eventRaised = true;

            // Act
            await _service.FetchRatesAsync("USD");

            // Assert
            Assert.IsTrue(eventRaised);
        }

        #endregion
    }
}