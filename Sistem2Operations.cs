using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    class Sistem2Operations
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");
        public void uyeEkle(String ad, String soyad, String kulAdi, String sifre, String email)
        {

            //insert işlemi
            //...

            NpgsqlCommand sql = new NpgsqlCommand();
            sql.Connection = con;
            con.Open();

            sql.CommandText = "insert into public.user (ad,soyad,user_adi,sifre,email) values ( '" + ad + "','" + soyad + "','" + kulAdi + "','" + sifre + "','" + email + "' )   ";
            sql.ExecuteNonQuery();

            con.Close();
        }
    }
}
