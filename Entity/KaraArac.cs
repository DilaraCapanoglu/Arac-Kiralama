using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class KaraArac:Arac
    {


        private int k_ar_id;
        private String marka;
        private String vites;
        private String cekis;
        

        

        public int K_ar_id
        {
            get
            {
                return k_ar_id;
            }

            set
            {
                k_ar_id = value;
            }
        }

        public string Marka
        {
            get
            {
                return marka;
            }

            set
            {
                marka = value;
            }
        }

        public string Vites
        {
            get
            {
                return vites;
            }

            set
            {
                vites = value;
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
