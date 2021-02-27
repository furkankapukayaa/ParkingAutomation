using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Otopark_otomasyon
{
    class Hizmetler
    {

        private DateTime aracgiris_saati;
        private DateTime araccikis_saati;
        private int hizmet_id;
        private string arac_plaka;
        private string musteri_adi_soyadi;
        private string ucret;
        private string abonelik_tipi;
        private string m_combo;
        private string a_combo;

        public int Hizmet_id
        {
            get
            {
                return hizmet_id;
            }
            set
            {
                hizmet_id = value;
            }
        }

        public string Arac_plaka
        {
            get
            {
                return arac_plaka;
            }
            set
            {
                arac_plaka = value;
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
        public DateTime Aracgiris_saati
        {
            get
            {
                return aracgiris_saati;
            }
            set
            {
                aracgiris_saati = value;
            }
        }

        public DateTime Araccikis_saati
        { 
            get
            {
                return araccikis_saati;
            }
            set
            {
                araccikis_saati = value;
            }
        }
        public string Ucret
        {
            get
            {
                return ucret;
            }
            set
            {
                ucret= value;
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
                abonelik_tipi= value;
            }
        }
        public string A_combo
        {
            get
            {
                return a_combo;
            }
            set
            {
                a_combo = value;
            }
        }
        public string M_combo
        {
            get
            {
                return m_combo;
            }
            set
            {
                m_combo = value;
            }
        }
            SqlConnection baglanti = new SqlConnection
               ("Data Source=FURKAN;Initial Catalog=dbOtopark;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public void Ekle()
        {
            komut = new SqlCommand("INSERT INTO tbl_hizmet (arac_plaka,musteri_adi_soyadi,aracgiris_saati,araccikis_saati,ucret,abonelik_tipi) VALUES (@plaka,@ad,@giris,@cikis,@ucret,@tip)", baglanti);
            komut.Parameters.AddWithValue("@plaka", this.arac_plaka);
            komut.Parameters.AddWithValue("@ad", this.musteri_adi_soyadi);
            komut.Parameters.AddWithValue("@giris", this.aracgiris_saati);
            komut.Parameters.AddWithValue("@cikis", this.araccikis_saati);
            komut.Parameters.AddWithValue("@ucret", this.ucret);
            komut.Parameters.AddWithValue("@tip", this.abonelik_tipi);
            


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }



        public void Sil()
        {
            komut = new SqlCommand("DELETE FROM tbl_hizmet where hizmet_id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", this.hizmet_id);

            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        public void Guncelle()
        {

            komut = new SqlCommand("UPDATE tbl_hizmet SET arac_plaka=@plaka,musteri_adi_soyadi=@ad,aracgiris_saati=@giris,araccikis_saati=@cikis,ucret=@ucret,abonelik_tipi=@tip where hizmet_id=@id", baglanti);
            komut.Parameters.AddWithValue("@plaka", this.arac_plaka);
            komut.Parameters.AddWithValue("@ad", this.musteri_adi_soyadi);
            komut.Parameters.AddWithValue("@giris", this.aracgiris_saati);
            komut.Parameters.AddWithValue("@cikis", this.araccikis_saati);
            komut.Parameters.AddWithValue("@ucret", this.ucret);
            komut.Parameters.AddWithValue("@tip", this.abonelik_tipi);
            komut.Parameters.AddWithValue("@id", this.hizmet_id);

        

            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

            public DataTable Tbl_Hizmetler()
        {
            komut = new SqlCommand("SELECT * FROM tbl_hizmet", baglanti);
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
