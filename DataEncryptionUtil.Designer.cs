namespace WindowsFormsDemo
{
    partial class DataEncryptionUtil
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
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.progressBarEncrypt = new System.Windows.Forms.ProgressBar();
            this.labelEncryptProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(12, 12);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(178, 40);
            this.buttonEncrypt.TabIndex = 0;
            this.buttonEncrypt.Text = "Encrypt Data";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // progressBarEncrypt
            // 
            this.progressBarEncrypt.Location = new System.Drawing.Point(196, 12);
            this.progressBarEncrypt.Name = "progressBarEncrypt";
            this.progressBarEncrypt.Size = new System.Drawing.Size(326, 40);
            this.progressBarEncrypt.TabIndex = 1;
            // 
            // labelEncryptProgress
            // 
            this.labelEncryptProgress.AutoSize = true;
            this.labelEncryptProgress.Location = new System.Drawing.Point(313, 64);
            this.labelEncryptProgress.Name = "labelEncryptProgress";
            this.labelEncryptProgress.Size = new System.Drawing.Size(0, 13);
            this.labelEncryptProgress.TabIndex = 2;
            // 
            // DataEncryptionUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 88);
            this.Controls.Add(this.labelEncryptProgress);
            this.Controls.Add(this.progressBarEncrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Name = "DataEncryptionUtil";
            this.Text = "Data Encryption Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.ProgressBar progressBarEncrypt;
        private System.Windows.Forms.Label labelEncryptProgress;
    }
}

