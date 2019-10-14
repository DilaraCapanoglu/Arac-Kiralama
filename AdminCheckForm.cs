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
    public partial class AdminCheckForm : Form
    {
        public AdminCheckForm()
        {
            InitializeComponent();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            adm.Adm_nick = txtKulAdi.Text;
            adm.Adm_pass = txtSifre.Text;
            
            

            AdminDao aDao = new AdminDao();
            var check = aDao.adminCheck(adm.Adm_nick,adm.Adm_pass);

            if( check != null)
            {
                AdminForm admForm = new AdminForm();
                admForm.Show();
            } else
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ GİRİLDİ.");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
