using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Otopark_otomasyon
{
    class Abonelik
    {
        private int abonelik_id;
        private string abonelik_tipi;
        private DateTime abonelik_baslangic_tarihi;
        private DateTime abonelik_bitis_tarihi;

        public int Abonelik_id
        {
            get
            {
                return abonelik_id;
            }
            set
            {
                abonelik_id =value;
            }
        }
        public string Abonelik_tipi 
        {
            get
            {
                return abonelik_tipi;
            }
            set
            {
                abonelik_tipi = value;
            }
        }
        public DateTime Abonelik_baslangic_tarihi 
        {
            get
            {
                return abonelik_baslangic_tarihi;
            }
            set
            {
                abonelik_baslangic_tarihi = value;
            }
        }
        public DateTime Abonelik_bitis_tarihi 
        {
            get
            {
                return abonelik_bitis_tarihi ;
            }
            set
            {
                abonelik_bitis_tarihi = value;
            }
        }

        SqlConnection baglanti = new SqlConnection
              ("Data Source=FURKAN;Initial Catalog=dbOtopark;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public void Ekle()
        {
            komut = new SqlCommand("INSERT INTO tbl_abonelik (abonelik_tipi,abonelik_baslangic_tarihi,abonelik_bitis_tarihi) VALUES (@tip,@bas,@bit)", baglanti);
            komut.Parameters.AddWithValue("@tip", this.abonelik_tipi);
            komut.Parameters.AddWithValue("@bas", this.abonelik_baslangic_tarihi);
            komut.Parameters.AddWithValue("@bit", this.abonelik_bitis_tarihi);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }



        public void Sil()
        {
            komut = new SqlCommand("DELETE FROM tbl_abonelik where abonelik_id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", this.abonelik_id);

            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        public void Guncelle()
        {

            komut = new SqlCommand("UPDATE tbl_abonelik SET abonelik_tipi=@tip,abonelik_baslangic_tarihi=@bas,abonelik_bitis_tarihi=@bit where abonelik_id=@id", baglanti);
            komut.Parameters.AddWithValue("@tip", this.abonelik_tipi);
            komut.Parameters.AddWithValue("@bas", this.abonelik_baslangic_tarihi);
            komut.Parameters.AddWithValue("@bit", this.abonelik_bitis_tarihi);
            komut.Parameters.AddWithValue("@id", this.abonelik_id);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataTable Tbl_Abonelik()
        {
            komut = new SqlCommand("SELECT * FROM tbl_abonelik", baglanti);
            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();
            }
            oku = komut.ExecuteReader();
            DataTable tablo = new DataTable();

            if (oku.HasRows)
            {
                tablo.Load(oku);
            }
            baglanti.Close();

            return tablo;
        }
    }
}

