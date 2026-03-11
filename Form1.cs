using System;
using System.Windows.Forms;
using CurrencyConverterApp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private CurrencyConverter converter;

        public Form1()
        {
            converter = new CurrencyConverter();
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            // Проверка: введена ли сумма
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для конвертации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: корректный ли формат числа
            if (!decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Неверный формат суммы! Введите число.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранных валют
            string fromCurrency = fromCurrencyComboBox.SelectedItem?.ToString();
            string toCurrency = toCurrencyComboBox.SelectedItem?.ToString();

            // Проверка: выбраны ли валюты
            if (string.IsNullOrEmpty(fromCurrency) || string.IsNullOrEmpty(toCurrency))
            {
                MessageBox.Show("Выберите валюты для конвертации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Попытка конвертации
            try
            {
                decimal result = converter.Convert(amount, fromCurrency, toCurrency);
                resultLabel.Text = $"Результат: {amount} {fromCurrency} = {result:F2} {toCurrency}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}