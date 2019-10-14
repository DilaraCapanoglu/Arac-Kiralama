using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class Admin
    {

        private int adm_id;
        private String adm_nick;
        private String adm_pass;

        public int Adm_id
        {
            get
            {
                return adm_id;
            }

            set
            {
                adm_id = value;
            }
        }

        public string Adm_nick
        {
            get
            {
                return adm_nick;
            }

            set
            {
                adm_nick = value;
            }
        }

        public string Adm_pass
        {
            get
            {
                return adm_pass;
            }

            set
            {
                adm_pass = value;
            }
        }
        

    }
}
