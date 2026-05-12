namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fromCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.toCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.fromCurrencyLabel = new System.Windows.Forms.Label();
            this.toCurrencyLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.currentRatesLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SuspendLayout();
            // 
            // fromCurrencyComboBox
            // 
            this.fromCurrencyComboBox.FormattingEnabled = true;
            this.fromCurrencyComboBox.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.fromCurrencyComboBox.Location = new System.Drawing.Point(12, 18);
            this.fromCurrencyComboBox.Name = "fromCurrencyComboBox";
            this.fromCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromCurrencyComboBox.TabIndex = 0;
            // 
            // toCurrencyComboBox
            // 
            this.toCurrencyComboBox.FormattingEnabled = true;
            this.toCurrencyComboBox.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.toCurrencyComboBox.Location = new System.Drawing.Point(152, 17);
            this.toCurrencyComboBox.Name = "toCurrencyComboBox";
            this.toCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.toCurrencyComboBox.TabIndex = 1;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(12, 65);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(261, 20);
            this.amountTextBox.TabIndex = 2;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 91);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(261, 23);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Конвертировать";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 117);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(62, 13);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат:";
            // 
            // fromCurrencyLabel
            // 
            this.fromCurrencyLabel.AutoSize = true;
            this.fromCurrencyLabel.Location = new System.Drawing.Point(12, 2);
            this.fromCurrencyLabel.Name = "fromCurrencyLabel";
            this.fromCurrencyLabel.Size = new System.Drawing.Size(66, 13);
            this.fromCurrencyLabel.TabIndex = 5;
            this.fromCurrencyLabel.Text = "Из валюты:";
            // 
            // toCurrencyLabel
            // 
            this.toCurrencyLabel.AutoSize = true;
            this.toCurrencyLabel.Location = new System.Drawing.Point(161, 2);
            this.toCurrencyLabel.Name = "toCurrencyLabel";
            this.toCurrencyLabel.Size = new System.Drawing.Size(56, 13);
            this.toCurrencyLabel.TabIndex = 6;
            this.toCurrencyLabel.Text = "В валюту:";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(12, 49);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(44, 13);
            this.amountLabel.TabIndex = 7;
            this.amountLabel.Text = "Сумма:";
            // 
            // currentRatesLabel
            // 
            this.currentRatesLabel.AutoSize = true;
            this.currentRatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.currentRatesLabel.ForeColor = System.Drawing.Color.Gray;
            this.currentRatesLabel.Location = new System.Drawing.Point(12, 145);
            this.currentRatesLabel.Name = "currentRatesLabel";
            this.currentRatesLabel.Size = new System.Drawing.Size(89, 13);
            this.currentRatesLabel.TabIndex = 8;
            this.currentRatesLabel.Text = "Загрузка курсов...";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(280, 115);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 23);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "🔄 Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 170);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(400, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 192);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.currentRatesLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.toCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyLabel);
            this.Controls.Add(this.toCurrencyLabel);
            this.Controls.Add(this.amountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер валют";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox fromCurrencyComboBox;
        private System.Windows.Forms.ComboBox toCurrencyComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label fromCurrencyLabel;
        private System.Windows.Forms.Label toCurrencyLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label currentRatesLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}