namespace FAMassDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.CapchaText = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.CapchaPic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CapchaPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Телефон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // PasswordMaskedTextBox
            // 
            this.PasswordMaskedTextBox.Location = new System.Drawing.Point(100, 35);
            this.PasswordMaskedTextBox.Name = "PasswordMaskedTextBox";
            this.PasswordMaskedTextBox.PasswordChar = '*';
            this.PasswordMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordMaskedTextBox.TabIndex = 2;
            this.PasswordMaskedTextBox.UseSystemPasswordChar = true;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(100, 2);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.LoginTextBox.TabIndex = 1;
            // 
            // CapchaText
            // 
            this.CapchaText.Location = new System.Drawing.Point(99, 122);
            this.CapchaText.Name = "CapchaText";
            this.CapchaText.Size = new System.Drawing.Size(100, 20);
            this.CapchaText.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(99, 148);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(128, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Начать скачивание";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CapchaPic
            // 
            this.CapchaPic.Location = new System.Drawing.Point(15, 61);
            this.CapchaPic.Name = "CapchaPic";
            this.CapchaPic.Size = new System.Drawing.Size(265, 50);
            this.CapchaPic.TabIndex = 9;
            this.CapchaPic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Защитный код";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(205, 122);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 11;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 190);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CapchaPic);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CapchaText);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.PasswordMaskedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MegaParser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CapchaPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox PasswordMaskedTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox CapchaText;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox CapchaPic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Timer timer1;
    }
}

