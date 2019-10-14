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
    public partial class MotosikletForm : Form
    {
        public MotosikletForm()
        {
            InitializeComponent();
        }

        Motosiklet moto = new Motosiklet();

        //NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");

        private void btnCreate_Click(object sender, EventArgs e)
        {
            setEdici(txtModel.Text, cmbKategori.Text, txtRenk.Text, txtYakitTipi.Text, int.Parse(txtYakitKapasite.Text), int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text), txtMarka.Text, txtVites.Text, int.Parse(txtSeleYuks.Text), txtZincir.Text);
            //setEdiciFac(txtModel.Text, cmbKategori.Text, txtRenk.Text, txtYakitTipi.Text, int.Parse(txtYakitKapasite.Text), int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text));

            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();
                NpgsqlCommand sql2 = new NpgsqlCommand();
                NpgsqlCommand sql3 = new NpgsqlCommand();



                sql.Connection = Connection.Connect();
                sql2.Connection = Connection.Connect();
                sql3.Connection = Connection.Connect();
                Connection.open();

                sql.CommandText = "insert into arac (ar_id, kat_id, model, renk, yakittipi, yakitkapasite, yolcukapasite, uretimyili, agirlik, fiyat) "
                               + " values (" + txtAr_Id.Text + " ,(select kat_id from kategori where kat_adi = '" + this.moto.Kat_adi + "') , '" + this.moto.Model + "',"
                               + " '" + this.moto.Renk + "','" + this.moto.YakitTipi + "'," + this.moto.YakitKapasite + "," + this.moto.YolcuKapasite + ", " + this.moto.UretimYili + ", "
                               + " " + this.moto.Agirlik + ", " + this.moto.Fiyat + " )";

                sql.ExecuteNonQuery();

                sql2.CommandText = " insert into karaarac ( k_ar_id,ar_id,marka,vites) values ( " + txtK_ar_id.Text + "," + txtAr_Id.Text + ",'" + this.moto.Marka + "','" + this.moto.Vites + "' )";
                sql2.ExecuteNonQuery();

                sql3.CommandText = "insert into motosiklet ( moto_id,k_ar_id,sele_yuksekligi,zincir ) values ( " + txtMotoid.Text + "," + txtK_ar_id.Text + ",'" + this.moto.SeleYukseklik + "', '" + this.moto.Zincir + "' )";
                sql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Connection.close();
            motoListele();
            temizlikGorevlisi();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            setEdici(txtModel.Text, cmbKategori.Text, txtRenk.Text, txtYakitTipi.Text, int.Parse(txtYakitKapasite.Text), int.Parse(txtYolcuKapasite.Text), int.Parse(txtUretimYili.Text), int.Parse(txtAgirlik.Text), int.Parse(txtFiyat.Text), txtMarka.Text, txtVites.Text, int.Parse(txtSeleYuks.Text), txtZincir.Text);
            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();
                NpgsqlCommand sql2 = new NpgsqlCommand();
                NpgsqlCommand sql3 = new NpgsqlCommand();

                sql.Connection = Connection.Connect();
                sql2.Connection = Connection.Connect();
                sql3.Connection = Connection.Connect();
                Connection.open();
                sql.CommandText = " update arac set kat_id=(select kat_id from kategori where kat_adi = '" + this.moto.Kat_adi + "'), model='" + this.moto.Model + "',renk='" + this.moto.Renk + "',"
                    + " yakittipi='" + this.moto.YakitTipi + "', yakitkapasite=" + this.moto.YakitKapasite + ", yolcukapasite=" + this.moto.YolcuKapasite + ", uretimyili=" + this.moto.UretimYili + " , agirlik=" + this.moto.Agirlik + " , "
                    + " fiyat=" + this.moto.Fiyat + " where ar_id=" + txtAr_Id.Text;
                sql.ExecuteNonQuery();

                sql2.CommandText = "update karaarac set marka='" + this.moto.Marka + "',vites='" + this.moto.Vites + "' where k_ar_id =" + txtK_ar_id.Text + " ";
                sql2.ExecuteNonQuery();

                sql3.CommandText = " update motosiklet set moto_id = " + txtMotoid.Text + ", sele_yuksekligi = '" + this.moto.SeleYukseklik + "', zincir='" + this.moto.Zincir + "' where moto_id =" + txtMotoid.Text;
                sql3.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Connection.close();
            motoListele();
            temizlikGorevlisi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();
                NpgsqlCommand sql2 = new NpgsqlCommand();
                NpgsqlCommand sql3 = new NpgsqlCommand();

                sql.Connection = Connection.Connect();
                sql2.Connection = Connection.Connect();
                sql3.Connection = Connection.Connect();
                Connection.open();
                sql.CommandText = "DELETE FROM motosiklet WHERE moto_id=" + txtMotoid.Text;
                sql2.CommandText = "DELETE FROM karaarac WHERE k_ar_id=" + txtK_ar_id.Text;
                sql3.CommandText = "DELETE FROm arac WHERE ar_id=" + txtAr_Id.Text;

                sql.ExecuteNonQuery();
                sql2.ExecuteNonQuery();
                sql3.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Connection.close();
            motoListele();
            temizlikGorevlisi();

        }

        private void motoListele()
        {
            MotosikletDao motoDao = new MotosikletDao();
            gridMoto.DataSource = motoDao.findAll();
        }

        private void MotosikletForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbKategori.Text);
            motoListele();
            
        }
       
        private void gridMoto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            String arac_id = gridMoto.Rows[rowIndex].Cells[0].Value.ToString();
            String kategori_id = gridMoto.Rows[rowIndex].Cells[8].Value.ToString();

            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.open();
            komut.Connection = Connection.Connect();
            komut.CommandText = "SELECT a.ar_id, ka.kat_adi,a.model,a.renk,a.yakittipi,a.yakitkapasite,a.yolcukapasite,a.uretimyili,a.agirlik,a.fiyat,k.k_ar_id,k.marka,k.vites,m.moto_id,m.sele_yuksekligi,m.zincir"
                + " FROM arac a LEFT OUTER JOIN karaarac k ON a.ar_id=k.ar_id "
                + "LEFT OUTER JOIN motosiklet m ON k.k_ar_id=m.k_ar_id "
                + "LEFT OUTER JOIN kategori ka ON ka.kat_id = a.kat_id"
                + " WHERE m.moto_id=" + arac_id + " and ka.kat_adi = (select kat_adi from kategori where kat_id=" + kategori_id + ") ";
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
                txtMotoid.Text = dr["moto_id"].ToString();
                txtSeleYuks.Text = dr["sele_yuksekligi"].ToString();
                txtZincir.Text = dr["zincir"].ToString();

            }
            Connection.close();

        }

        private void temizlikGorevlisi()
        {

            txtAr_Id.Text = "";
            cmbKategori.Text = "Motosiklet";
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

            txtMotoid.Text = "";
            txtSeleYuks.Text = "";
            txtZincir.Text = "";

        }

        public void setEdici(String model, String cmbKategori, String renk, String yakitTipi, int yakitKapasite, int yolcuKapasite, int uretimYili, int agirlik, int fiyat, String marka, String vites, int seleYuks, String zincir)
        {
            this.moto.Model = model;
            this.moto.Kat_adi = cmbKategori;
            this.moto.Renk = renk;
            this.moto.YakitTipi = yakitTipi;
            this.moto.YakitKapasite = yakitKapasite;
            this.moto.YolcuKapasite = yolcuKapasite;
            this.moto.UretimYili = uretimYili;
            this.moto.Agirlik = agirlik;
            this.moto.Fiyat = fiyat;

            this.moto.Marka = marka;
            this.moto.Vites = vites;

            this.moto.SeleYukseklik = seleYuks;
            this.moto.Zincir = zincir;
        }

        private void MotosikletForm_DoubleClick(object sender, EventArgs e)
        {
            temizlikGorevlisi();
        }

        private void txtK_ar_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMoto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRenk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
