using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Otopark_otomasyon
{
    class Musteriler
    {
        private int musteri_id;
        private string musteri_adi_soyadi;
        private string musteri_adres;
        private string musteri_tel;


        public int Musteri_id
        {
            get
            {
                return musteri_id;
            }
            set
            {
                musteri_id = value;
            }
        }
        public string Musteri_adi_soyadi
            {
            get
            {
                return musteri_adi_soyadi;
            }
            set
            {
                musteri_adi_soyadi = value;
            }
        
        }
        public string Musteri_adres
        {
            get
            {
                return  musteri_adres;
            }
            set
            {
                musteri_adres= value;
            }

        }
        public string Musteri_tel
        {
            get
            {
                return musteri_tel;
            }
            set
            {
                musteri_tel = value;
            }

        }
        SqlConnection baglanti = new SqlConnection
             ("Data Source=FURKAN;Initial Catalog=dbOtopark;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public void Ekle()
        {
            komut = new SqlCommand("INSERT INTO tbl_musteriler (musteri_adi_soyadi,musteri_adres,musteri_tel) VALUES (@ad,@adres,@tel)", baglanti);
            komut.Parameters.AddWithValue("@ad", this.musteri_adi_soyadi);
            komut.Parameters.AddWithValue("@adres", this.musteri_adres);
            komut.Parameters.AddWithValue("@tel", this.musteri_tel);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }



        public void Sil()
        {
            komut = new SqlCommand("DELETE FROM tbl_musteriler where musteri_id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", this.musteri_id);

            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        public void Guncelle()
        {

            komut = new SqlCommand("UPDATE tbl_musteriler SET musteri_adi_soyadi=@ad,musteri_adres=@adres,musteri_tel=@tel where musteri_id=@id", baglanti);
            komut.Parameters.AddWithValue("@ad", this.musteri_adi_soyadi);
            komut.Parameters.AddWithValue("@adres", this.musteri_adres);
            komut.Parameters.AddWithValue("@tel", this.musteri_tel);
            komut.Parameters.AddWithValue("@id", this.musteri_id);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public DataTable Tbl_Musteriler()
        {

            komut = new SqlCommand("SELECT * FROM tbl_musteriler", baglanti);
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

