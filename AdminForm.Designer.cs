namespace AracGaleri
{
    partial class AdminForm
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
            this.btnOtomobil = new System.Windows.Forms.Button();
            this.btnMotosiklet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOtomobil
            // 
            this.btnOtomobil.Location = new System.Drawing.Point(33, 43);
            this.btnOtomobil.Name = "btnOtomobil";
            this.btnOtomobil.Size = new System.Drawing.Size(154, 49);
            this.btnOtomobil.TabIndex = 0;
            this.btnOtomobil.TabStop = false;
            this.btnOtomobil.Text = "Otomobil";
            this.btnOtomobil.UseVisualStyleBackColor = true;
            this.btnOtomobil.Click += new System.EventHandler(this.btnOtomobil_Click);
            // 
            // btnMotosiklet
            // 
            this.btnMotosiklet.Location = new System.Drawing.Point(208, 43);
            this.btnMotosiklet.Name = "btnMotosiklet";
            this.btnMotosiklet.Size = new System.Drawing.Size(154, 49);
            this.btnMotosiklet.TabIndex = 1;
            this.btnMotosiklet.TabStop = false;
            this.btnMotosiklet.Text = "Motosiklet";
            this.btnMotosiklet.UseVisualStyleBackColor = true;
            this.btnMotosiklet.Click += new System.EventHandler(this.btnMotosiklet_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 328);
            this.Controls.Add(this.btnMotosiklet);
            this.Controls.Add(this.btnOtomobil);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOtomobil;
        private System.Windows.Forms.Button btnMotosiklet;
    }
}