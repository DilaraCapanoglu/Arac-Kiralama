using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class Kategori
    {
        private int kat_id;
        private String kat_adi;

        public int Kat_id
        {
            get
            {
                return kat_id;
            }

            set
            {
                kat_id = value;
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
    }
}
