using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace AracGaleri
{
     class Arac
    {

        private int ar_id;
        private String kat_adi;
        private String model;
        private String renk;
        private String yakitTipi;
        private int yakitKapasite;
        private int yolcuKapasite;
        private int uretimYili;
        private int agirlik;
        private int fiyat;

       
        

        public int Ar_id
        {
            get
            {
                return ar_id;
            }

            set
            {
                ar_id = value;
            }
        }

        public string Kat_adi
        {
            get
            {
                return kat_adi;
            }

            set
            {
                kat_adi = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Renk
        {
            get
            {
                return renk;
            }

            set
            {
                renk = value;
            }
        }

        public string YakitTipi
        {
            get
            {
                return yakitTipi;
            }

            set
            {
                yakitTipi = value;
            }
        }

        public int YakitKapasite
        {
            get
            {
                return yakitKapasite;
            }

            set
            {
                yakitKapasite = value;
            }
        }

        public int YolcuKapasite
        {
            get
            {
                return yolcuKapasite;
            }

            set
            {
                yolcuKapasite = value;
            }
        }

        public int UretimYili
        {
            get
            {
                return uretimYili;
            }

            set
            {
                uretimYili = value;
            }
        }

        public int Agirlik
        {
            get
            {
                return agirlik;
            }

            set
            {
                agirlik = value;
            }
        }

        public int Fiyat
        {
            get
            {
                return fiyat;
            }

            set
            {
                fiyat = value;
            }
        }
    }
}
