using System;
using System.Windows.Forms;
using CurrencyConverterApp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private CurrencyConverter converter;
        private CurrencyRateService rateService;
        private Timer autoUpdateTimer;

        public Form1()
        {
            rateService = new CurrencyRateService(TimeSpan.FromMinutes(10));
            converter = new CurrencyConverter(rateService);

            InitializeComponent();
            SetupEvents();

            // Загрузка курсов при старте
            LoadRatesAsync();
        }

        private void SetupEvents()
        {
            // Подписка на события сервиса
            rateService.OnRateUpdated += (msg) =>
                this.Invoke(new Action(() => {
                    UpdateRatesDisplay();
                    MessageBox.Show(msg, "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));

            rateService.OnError += (msg) =>
                this.Invoke(new Action(() => {
                    UpdateRatesDisplay();
                    statusLabel.Text = "⚠ " + msg;
                }));

            // Таймер автообновления (каждые 10 минут)
            autoUpdateTimer = new Timer { Interval = 60000 };
            autoUpdateTimer.Tick += (s, e) => LoadRatesAsync();
            autoUpdateTimer.Start();
        }

        private async void LoadRatesAsync()
        {
            try
            {
                await rateService.FetchRatesAsync("USD");
                UpdateRatesDisplay();
            }
            catch { /* Ошибки обрабатываются в событиях сервиса */ }
        }

        private void UpdateRatesDisplay()
        {
            currentRatesLabel.Text = $"Курсы: {converter.GetCurrentRateInfo("USD", "EUR")} | " +
                        $"{converter.GetCurrentRateInfo("EUR", "USD")} | " +
                        $"Обновлено: {rateService.LastUpdate:HH:mm}";
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            convertButton.Enabled = false;
            refreshButton.Enabled = false;

            await converter.RefreshRatesAsync();
            UpdateRatesDisplay();

            convertButton.Enabled = true;
            refreshButton.Enabled = true;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для конвертации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Неверный формат суммы! Введите число.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fromCurrency = fromCurrencyComboBox.SelectedItem?.ToString();
            string toCurrency = toCurrencyComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(fromCurrency) || string.IsNullOrEmpty(toCurrency))
            {
                MessageBox.Show("Выберите валюты для конвертации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            autoUpdateTimer?.Stop();
            autoUpdateTimer?.Dispose();
            
            base.OnFormClosing(e);
        }
    }
}