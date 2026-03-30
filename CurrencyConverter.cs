using System;

namespace CurrencyConverterApp
{
    public class CurrencyConverter
    {
        private decimal usdToEur = 0.88m; // Примерный курс валют
        private decimal eurToUsd = 1.12m;

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            // Проверка граничных значений
            if (amount < 0)
            {
                throw new ArgumentException("Сумма не может быть отрицательной.");
            }

            else if (fromCurrency == "USD" && toCurrency == "EUR")
            {
                return amount * usdToEur;
            }
            else if (fromCurrency == "EUR" && toCurrency == "USD")
            {
                return amount * eurToUsd;
            }

            else if ((fromCurrency != "EUR" || fromCurrency != "USD") || (toCurrency != "EUR" || toCurrency != "USD"))
            {
                throw new NotSupportedException("Не поддерживаемая пара валют.");
            }
            else { 
            return 0;
            }

        }
    }
}