namespace SteamEquipmentToExcel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.info1 = new System.Windows.Forms.Label();
            this.text_Id = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.filePathButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.priceCheck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // info1
            // 
            this.info1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.info1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.info1.Location = new System.Drawing.Point(0, 39);
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(78, 13);
            this.info1.TabIndex = 0;
            this.info1.Text = "Podaj Id64";
            this.info1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_Id
            // 
            this.text_Id.Location = new System.Drawing.Point(12, 55);
            this.text_Id.Name = "text_Id";
            this.text_Id.Size = new System.Drawing.Size(269, 20);
            this.text_Id.TabIndex = 1;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(17, 172);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 2;
            this.generate.Text = "Zapisz";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Podaj scieżkę zapisu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(14, 103);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(177, 20);
            this.filePathBox.TabIndex = 4;
            // 
            // filePathButton
            // 
            this.filePathButton.Location = new System.Drawing.Point(206, 101);
            this.filePathButton.Name = "filePathButton";
            this.filePathButton.Size = new System.Drawing.Size(75, 23);
            this.filePathButton.TabIndex = 5;
            this.filePathButton.Text = "Wybierz";
            this.filePathButton.UseVisualStyleBackColor = true;
            this.filePathButton.Click += new System.EventHandler(this.filePathButton_Click);
            // 
            // statusBox
            // 
            this.statusBox.BackColor = System.Drawing.Color.Lime;
            this.statusBox.Enabled = false;
            this.statusBox.Location = new System.Drawing.Point(206, 146);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(19, 20);
            this.statusBox.TabIndex = 6;
            // 
            // priceCheck
            // 
            this.priceCheck.Location = new System.Drawing.Point(17, 146);
            this.priceCheck.Name = "priceCheck";
            this.priceCheck.Size = new System.Drawing.Size(100, 20);
            this.priceCheck.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(14, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cena od";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(295, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceCheck);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.filePathButton);
            this.Controls.Add(this.filePathBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.text_Id);
            this.Controls.Add(this.info1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label info1;
        private System.Windows.Forms.TextBox text_Id;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button filePathButton;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox priceCheck;
        private System.Windows.Forms.Label label2;
    }
}

