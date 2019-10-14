using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    class MotosikletDao
    {

        private Motosiklet moto;

        public List<Motosiklet> findAll()
        {

            try
            {

                List<Motosiklet> motoList = new List<Motosiklet>();

                //NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");

                NpgsqlCommand sql = new NpgsqlCommand();


                sql.Connection = Connection.Connect();
                Connection.open();
                sql.CommandText = " select * from motosiklet m, karaarac k, arac a where m.k_ar_id = k.k_ar_id and a.ar_id = k.ar_id ";
                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    this.Moto = new Motosiklet();

                    Moto.Ar_id = int.Parse(dr["ar_id"].ToString());
                    Moto.Kat_adi = (dr["kat_id"].ToString());
                    Moto.Model = (dr["model"].ToString());
                    Moto.Renk = (dr["renk"].ToString());
                    Moto.YakitTipi = (dr["yakittipi"].ToString());
                    Moto.YakitKapasite = int.Parse(dr["yakitkapasite"].ToString());
                    Moto.YolcuKapasite = int.Parse(dr["yolcukapasite"].ToString());
                    Moto.UretimYili = int.Parse(dr["uretimyili"].ToString());
                    Moto.Agirlik = int.Parse(dr["agirlik"].ToString());
                    Moto.Fiyat = int.Parse(dr["fiyat"].ToString());

                    Moto.K_ar_id = int.Parse(dr["k_ar_id"].ToString());
                    Moto.Marka = dr["marka"].ToString();
                    Moto.Vites = dr["vites"].ToString();


                    Moto.Moto_id = int.Parse(dr["moto_id"].ToString());
                    Moto.SeleYukseklik = int.Parse(dr["sele_yuksekligi"].ToString());
                    Moto.Zincir = dr["zincir"].ToString();

                    motoList.Add(Moto);
                }
                /*Connection c = new Connection();
                c.*/

                Connection.close();

                return motoList;
            }
            catch (Exception ex)
            {
                return new List<Motosiklet>();
            }
        }


        internal Motosiklet Moto
        {
            get
            {
                return moto;
            }

            set
            {
                moto = value;
            }
        }
    }
}
