using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    class Sistem1Kontrol
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");
        public bool karaListeKontrol(String mail)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = con;

            komut.CommandText = "select * from karaliste where email='" + mail + "' ";
            con.Open();
            NpgsqlDataReader dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                return true;
                con.Close();
            }
            else
            {
                con.Close();
                return false;
            }



        }
    }
}
