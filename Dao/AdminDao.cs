using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    class AdminDao
    {
        private Admin admin;
        private List<Admin> adminList;
        
        public Admin adminCheck(String adm_nick, String adm_pass)
        {

            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = Connection.Connect();

            komut.CommandText = "SELECT * FROM public.admin WHERE adm_nick='" + adm_nick + "' and adm_pass='" + adm_pass + "' ";
            Connection.open();
            NpgsqlDataReader dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                this.Admin = new Admin();
                dr.Read();
                this.Admin.Adm_nick = dr["adm_nick"].ToString();
                this.Admin.Adm_pass = dr["adm_pass"].ToString();
                Connection.close();
                return this.Admin;
            }
            else
            {
                Connection.close();
                return null;
            }

        }

        internal Admin Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }

        internal List<Admin> AdminList
        {
            get
            {
                return adminList;
            }

            set
            {
                adminList = value;
            }
        }
    }
}
