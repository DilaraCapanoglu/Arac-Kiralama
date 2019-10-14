using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace AracGaleri
{
    class OtomobilDao
    {

        private Otomobil oto;

        

        public List<Otomobil> findAll()
        {
            List<Otomobil> otoList = new List<Otomobil>();

            
            //NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");


            NpgsqlCommand sql = new NpgsqlCommand();


            sql.Connection = Connection.Connect();
            sql.CommandText = " select * from otomobil o, karaarac k, arac a where o.k_ar_id = k.k_ar_id and a.ar_id = k.ar_id ";
            Connection.open();
            NpgsqlDataReader dr = sql.ExecuteReader();

            while (dr.Read())
            {
                this.Oto = new Otomobil();

                Oto.Ar_id = int.Parse(dr["ar_id"].ToString());
                Oto.Kat_adi = (dr["kat_id"].ToString());
                Oto.Model = (dr["model"].ToString());
                Oto.Renk = (dr["renk"].ToString());
                Oto.YakitTipi = (dr["yakittipi"].ToString());
                Oto.YakitKapasite = int.Parse(dr["yakitkapasite"].ToString());
                Oto.YolcuKapasite = int.Parse(dr["yolcukapasite"].ToString());
                Oto.UretimYili = int.Parse(dr["uretimyili"].ToString());
                Oto.Agirlik = int.Parse(dr["agirlik"].ToString());
                Oto.Fiyat = int.Parse(dr["fiyat"].ToString());

                Oto.K_ar_id = int.Parse(dr["k_ar_id"].ToString());
                Oto.Marka = dr["marka"].ToString();
                Oto.Vites = dr["vites"].ToString();


                Oto.Oto_id = int.Parse(dr["oto_id"].ToString());
                Oto.HavaYastigi= (dr["hava_yastigi"].ToString());
                Oto.Cekis = dr["cekis"].ToString();

                otoList.Add(Oto);
            }
            /*Connection c = new Connection();
            c.*/
            Connection.close();

            return otoList;
        }



        internal Otomobil Oto
        {
            get
            {
                return oto;
            }

            set
            {
                oto = value;
            }
        }




    }

}
