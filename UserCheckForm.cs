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
    public partial class UserCheckForm : Form
    {
        public UserCheckForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Entity.User u = new Entity.User();
            u.Ad = txtKulAdi.Text;
            u.Soyad = txtSoyad.Text;
            u.User_adi = txtKulAdi.Text;
            u.Sifre = txtSifre.Text;
            u.Email = txtMail.Text;
            Facade f = new Facade();

            if (f.Sistem2Girisİzni(u.Email)==true)
            {
                UserDao uDao = new UserDao();
                var check = uDao.userCheck(u.Ad, u.Soyad, u.User_adi, u.Sifre, u.Email);

                if (check != null)
                {
                    MisafirForm msfForm = new MisafirForm();
                    msfForm.Show();
                }
                else
                {
                    MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ GİRİLDİ.");
                }
            }
            else
            {
                MessageBox.Show("KARA LİSTEDESİN.");
            }
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            Entity.User u = new Entity.User();
            u.Ad = txtAd.Text;
            u.Soyad = txtSoyad.Text;
            u.User_adi = txtKulAdi.Text;
            u.Sifre = txtSifre.Text;
            u.Email = txtMail.Text;

            Facade f = new Facade();
            f.Sistem2UyeEkle(u.Ad, u.Soyad, u.User_adi, u.Sifre, u.Email);
        }
    }
}
