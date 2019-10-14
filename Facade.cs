using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracGaleri
{
    class Facade
    {

        Sistem1Kontrol s1 = new Sistem1Kontrol();
        Sistem2Operations s2 = new Sistem2Operations();

        public void Sistem2UyeEkle(String ad, String soyad, String kulAdi, String sifre, String mail)
        {
            if (s1.karaListeKontrol(mail) == false)
            {
                s2.uyeEkle(ad, soyad, kulAdi, sifre, mail);
            }
            else
            {
                MessageBox.Show("KARA LİSTEDESİN.");
            }
        }

        public bool Sistem2Girisİzni(String mail)
        {
            if (s1.karaListeKontrol(mail) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
