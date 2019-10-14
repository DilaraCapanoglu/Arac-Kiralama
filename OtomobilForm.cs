using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace AracGaleri
{
    public partial class OtomobilForm : Form
    {
        public OtomobilForm()
        {
            InitializeComponent();
        }

        Otomobil otoFac = (Otomobil)AracFactory.createArac("Otomobil");
        

        Otomobil oto = new Otomobil();
        
        //NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");

        //---------------------------( CRUD )--------------------------------------
        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            setEdici(txtModel.Text,cmbKategori.Text ,txtRenk.Text,txtYakitTipi.Text,int.Parse(txtYakitKapasite.Text),int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text),txtMarka.Text,txtVites.Text,txtHavaYastigi.Text,txtCekis.Text);
            //setEdiciFac(txtModel.Text, cmbKategori.Text, txtRenk.Text, txtYakitTipi.Text, int.Parse(txtYakitKapasite.Text), int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text));

            try { 
            NpgsqlCommand sql = new NpgsqlCommand();
            NpgsqlCommand sql2 = new NpgsqlCommand();
            NpgsqlCommand sql3 = new NpgsqlCommand();

            

            sql.Connection = Connection.Connect();
            sql2.Connection = Connection.Connect();
            sql3.Connection = Connection.Connect();
            Connection.open();
            sql.CommandText = "insert into arac (ar_id, kat_id, model, renk, yakittipi, yakitkapasite, yolcukapasite, uretimyili, agirlik, fiyat) "
                           +" values (" + txtAr_Id.Text + " ,(select kat_id from kategori where kat_adi = '" + this.oto.Kat_adi + "') , '"+this.oto.Model+"',"
                           +" '"+ this.oto.Renk+ "','"+this.oto.YakitTipi+ "',"+ this.oto.YakitKapasite+ ","+this.oto.YolcuKapasite+ ", "+ this.oto.UretimYili+ ", "
                           +" "+ this.oto.Agirlik+ ", "+ this.oto.Fiyat+ " )" ;

            sql.ExecuteNonQuery();

            sql2.CommandText = " insert into karaarac ( k_ar_id,ar_id,marka,vites) values ( "+txtK_ar_id.Text+","+txtAr_Id.Text + ",'"+ this.oto.Marka + "','"+ this.oto.Vites + "' )" ;
            sql2.ExecuteNonQuery();

            sql3.CommandText = "insert into otomobil ( oto_id,k_ar_id,hava_yastigi,cekis ) values ( "+txtOto_id.Text+","+txtK_ar_id.Text+",'"+ this.oto.HavaYastigi+ "', '"+ this.oto.Cekis + "' )" ;
            sql3.ExecuteNonQuery();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            Connection.close();
            otoListele();
            temizlikGorevlisi();
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            setEdici(txtModel.Text, cmbKategori.Text, txtRenk.Text, txtYakitTipi.Text, int.Parse(txtYakitKapasite.Text), int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text), txtMarka.Text, txtVites.Text, txtHavaYastigi.Text, txtCekis.Text);
            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();
                NpgsqlCommand sql2 = new NpgsqlCommand();
                NpgsqlCommand sql3 = new NpgsqlCommand();
                
                sql.Connection = Connection.Connect();
                sql2.Connection = Connection.Connect();
                sql3.Connection = Connection.Connect();
                Connection.open();
                sql.CommandText = " update arac set kat_id=(select kat_id from kategori where kat_adi = '" + this.oto.Kat_adi + "'), model='"+ this.oto.Model + "',renk='"+ this.oto.Renk+ "',"
                    +" yakittipi='"+ this.oto.YakitTipi + "', yakitkapasite="+ this.oto.YakitKapasite + ", yolcukapasite="+ this.oto.YolcuKapasite + ", uretimyili="+ this.oto.UretimYili + " , agirlik="+ this.oto.Agirlik + " , "
                    +" fiyat="+ this.oto.Fiyat + " where ar_id="+txtAr_Id.Text ;
                sql.ExecuteNonQuery();

                sql2.CommandText = "update karaarac set marka='" + this.oto.Marka + "',vites='" + this.oto.Vites + "' where k_ar_id =" + txtK_ar_id.Text + " ";
                sql2.ExecuteNonQuery();

                sql3.CommandText = " update otomobil set oto_id = "+txtOto_id.Text+", hava_yastigi = '"+this.oto.HavaYastigi+"', cekis='"+this.oto.Cekis+"' where oto_id ="+txtOto_id.Text;
                sql3.ExecuteNonQuery();
                
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            Connection.close();
            otoListele();
            temizlikGorevlisi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try { 
            NpgsqlCommand sql = new NpgsqlCommand();
            NpgsqlCommand sql2 = new NpgsqlCommand();
            NpgsqlCommand sql3 = new NpgsqlCommand();
                
            sql.Connection = Connection.Connect();
            sql2.Connection = Connection.Connect();
            sql3.Connection = Connection.Connect();
            Connection.open();
            sql.CommandText = "DELETE FROM otomobil WHERE oto_id=" + txtOto_id.Text;
            sql2.CommandText = "delete from karaarac where k_ar_id=" + txtK_ar_id.Text;
            sql3.CommandText = "delete from arac where ar_id=" + txtAr_Id.Text;

            sql.ExecuteNonQuery();
            sql2.ExecuteNonQuery();
            sql3.ExecuteNonQuery();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            Connection.close();
            otoListele();
            temizlikGorevlisi();
        }
        //---------------------------( CRUD END )--------------------------------------



        //Kategori combobox'ına veritabanındaki kategori isimlerini getiren kod parçası
        private void cmbKategori_Click(object sender, EventArgs e)
        {
            cmbKategori.Items.Clear();

            NpgsqlCommand sql = new NpgsqlCommand();

            sql.CommandText = "SELECT * FROM kategori";
            sql.Connection = Connection.Connect();
            Connection.open();
            NpgsqlDataReader dr;

            dr = sql.ExecuteReader();
            while (dr.Read()) {
                cmbKategori.Items.Add(dr["kat_adi"]);
            }

            Connection.close();
        }

        private void OtomobilForm_DoubleClick(object sender, EventArgs e)
        {

            temizlikGorevlisi();
            
        }

        private void temizlikGorevlisi()
        {
            
            txtAr_Id.Text = "";
            cmbKategori.Text = "Otomobil";
            txtModel.Text = "";
            txtRenk.Text = "";
            txtYakitTipi.Text = "";
            txtYakitKapasite.Text = "";
            txtYolcuKapasite.Text = "";
            txtUretimYili.Text = "";
            txtAgirlik.Text = "";
            txtFiyat.Text = "";

            txtK_ar_id.Text = "";
            txtMarka.Text = "";
            txtVites.Text = "";

            txtOto_id.Text = "";
            txtHavaYastigi.Text = "";
            txtCekis.Text = "";

        }
       /* public void setEdiciFac(String model, String cmbKategori, String renk, String yakitTipi, int yakitKapasite, int yolcuKapasite, int uretimYili, int agirlik, int fiyat)
        {
            this.otoFac.Model = model;
            this.otoFac.Kat_adi = cmbKategori;
            this.otoFac.Renk = renk;
            this.otoFac.YakitTipi = yakitTipi;
            this.otoFac.YakitKapasite = yakitKapasite;
            this.otoFac.YolcuKapasite = yolcuKapasite;
            this.otoFac.UretimYili = uretimYili;
            this.otoFac.Agirlik = agirlik;
            this.otoFac.Fiyat = fiyat;
           
        }*/

        public void setEdici(String model, String cmbKategori, String renk, String yakitTipi, int yakitKapasite, int yolcuKapasite, int uretimYili, int agirlik, int fiyat, String marka, String vites ,String havaYastigi , String cekis)
        {
            this.oto.Model=model;
            this.oto.Kat_adi = cmbKategori;
            this.oto.Renk = renk;
            this.oto.YakitTipi = yakitTipi;
            this.oto.YakitKapasite = yakitKapasite;
            this.oto.YolcuKapasite = yolcuKapasite;
            this.oto.UretimYili = uretimYili;
            this.oto.Agirlik = agirlik;
            this.oto.Fiyat = fiyat;

            this.oto.Marka = marka;
            this.oto.Vites = vites;

            this.oto.HavaYastigi = havaYastigi;
            this.oto.Cekis = cekis;
        }

        private void otoListele()
        {

            OtomobilDao otoDao = new OtomobilDao();
            gridOtomobil.DataSource = otoDao.findAll();


            /*NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select * from arac a ,karaarac k ,otomobil o where a.ar_id=k.ar_id and k.k_ar_id=o.k_ar_id ", Connection.Connect());
            DataSet ds = new DataSet();
            da.Fill(ds, "arac,karaarac,otomobil");
            gridOtomobil.DataSource = ds.Tables["arac,karaarac,otomobil"];
            Connection.Connect().Close();*/
        }

        private void OtomobilForm_Load(object sender, EventArgs e)
        {
            otoListele();  
        }

        private void gridOtomobil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void gridOtomobil_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowIndex = e.RowIndex;
                String arac_id = gridOtomobil.Rows[rowIndex].Cells[6].Value.ToString();
                String kategori_id = gridOtomobil.Rows[rowIndex].Cells[7].Value.ToString();

                NpgsqlCommand komut = new NpgsqlCommand();
                komut.Connection = Connection.Connect();
                Connection.open();
                komut.CommandText = "SELECT a.ar_id, ka.kat_adi,a.model,a.renk,a.yakittipi,a.yakitkapasite,a.yolcukapasite,a.uretimyili,a.agirlik,a.fiyat,k.k_ar_id,k.marka,k.vites,o.oto_id,o.hava_yastigi,o.cekis"
                    + " FROM arac a LEFT OUTER JOIN karaarac k ON a.ar_id=k.ar_id "
                    + "LEFT OUTER JOIN otomobil o ON k.k_ar_id=o.k_ar_id "
                    + "LEFT OUTER JOIN kategori ka ON ka.kat_id = a.kat_id"
                    + " WHERE a.ar_id=" + arac_id + " and ka.kat_adi = (select kat_adi from kategori where kat_id=" + kategori_id + ") ";
                komut.ExecuteNonQuery();

                NpgsqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    txtAr_Id.Text = dr["ar_id"].ToString();
                    cmbKategori.Text = dr["kat_adi"].ToString();
                    txtModel.Text = dr["model"].ToString();
                    txtRenk.Text = dr["renk"].ToString();
                    txtYakitTipi.Text = dr["yakittipi"].ToString();
                    txtYakitKapasite.Text = dr["yakitkapasite"].ToString();
                    txtYolcuKapasite.Text = dr["yolcukapasite"].ToString();
                    txtUretimYili.Text = dr["uretimyili"].ToString();
                    txtAgirlik.Text = dr["agirlik"].ToString();
                    txtFiyat.Text = dr["fiyat"].ToString();
                    txtK_ar_id.Text = dr["k_ar_id"].ToString();
                    txtMarka.Text = dr["marka"].ToString();
                    txtVites.Text = dr["vites"].ToString();
                    txtOto_id.Text = dr["oto_id"].ToString();
                    txtHavaYastigi.Text = dr["hava_yastigi"].ToString();
                    txtCekis.Text = dr["cekis"].ToString();

                }
                Connection.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

      
    }
}


