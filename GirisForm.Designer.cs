namespace AracGaleri
{
    partial class GirisForm
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
            this.btnMisafir = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMisafir
            // 
            this.btnMisafir.Location = new System.Drawing.Point(55, 44);
            this.btnMisafir.Name = "btnMisafir";
            this.btnMisafir.Size = new System.Drawing.Size(216, 61);
            this.btnMisafir.TabIndex = 0;
            this.btnMisafir.Text = "MİSAFİR GİRİŞİ";
            this.btnMisafir.UseVisualStyleBackColor = true;
            this.btnMisafir.Click += new System.EventHandler(this.btnMisafir_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(55, 153);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(216, 59);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "YETKİLİ GİRİŞİ";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 289);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnMisafir);
            this.Name = "GirisForm";
            this.Text = "GirisForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMisafir;
        private System.Windows.Forms.Button btnAdmin;
    }
}