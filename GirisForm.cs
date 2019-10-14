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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminCheckForm g = new AdminCheckForm();
            g.Show();
        }

        private void btnMisafir_Click(object sender, EventArgs e)
        {
            UserCheckForm m = new UserCheckForm();
            m.ShowDialog();
        }
    }
}
