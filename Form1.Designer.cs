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
            this.SuspendLayout();
            // 
            // fromCurrencyComboBox
            // 
            this.fromCurrencyComboBox.FormattingEnabled = true;
            this.fromCurrencyComboBox.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.fromCurrencyComboBox.Location = new System.Drawing.Point(12, 12);
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
            this.toCurrencyComboBox.Location = new System.Drawing.Point(152, 12);
            this.toCurrencyComboBox.Name = "toCurrencyComboBox";
            this.toCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.toCurrencyComboBox.TabIndex = 1;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(12, 39);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(261, 20);
            this.amountTextBox.TabIndex = 2;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 65);
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
            this.resultLabel.Location = new System.Drawing.Point(12, 91);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(60, 13);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.toCurrencyComboBox);
            this.Controls.Add(this.fromCurrencyComboBox);
            this.Name = "Form1";
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
    }
}