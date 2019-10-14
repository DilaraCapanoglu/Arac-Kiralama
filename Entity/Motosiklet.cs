using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class Motosiklet:KaraArac
    {

        private int moto_id;
        private int seleYukseklik;
        private String zincir;

        public int Moto_id
        {
            get
            {
                return moto_id;
            }

            set
            {
                moto_id = value;
            }
        }

        public int SeleYukseklik
        {
            get
            {
                return seleYukseklik;
            }

            set
            {
                seleYukseklik = value;
            }
        }

        public string Zincir
        {
            get
            {
                return zincir;
            }

            set
            {
                zincir = value;
            }
        }
    }
}
