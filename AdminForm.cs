using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracGaleri
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnOtomobil_Click(object sender, EventArgs e)
        {
            OtomobilForm otomf = new OtomobilForm();
            otomf.Show();
        }

        private void btnMotosiklet_Click(object sender, EventArgs e)
        {
            MotosikletForm motof = new MotosikletForm();
            motof.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
