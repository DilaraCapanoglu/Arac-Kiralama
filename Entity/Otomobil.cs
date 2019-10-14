using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class Otomobil:KaraArac
    {

        private int oto_id;
        private String havaYastigi;
        private String cekis;


        public int Oto_id
        {
            get
            {
                return oto_id;
            }

            set
            {
                oto_id = value;
            }
        }

        public string HavaYastigi
        {
            get
            {
                return havaYastigi;
            }

            set
            {
                havaYastigi = value;
            }
        }

        public string Cekis
        {
            get
            {
                return cekis;
            }

            set
            {
                cekis = value;
            }
        }
    }
}
