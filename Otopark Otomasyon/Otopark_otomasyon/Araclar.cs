using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Otopark_otomasyon
{
    class Araclar
    {
        private int arac_id;
        private string arac_plaka;
        private string renk;
        private string model;
        private string yil;

        public int Arac_id
        {
            get
            {
                return arac_id;
            }
            set
            {
                arac_id = value;

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
        public string Renk
        {
            get
            {
                return renk;
            }
            set
            {
                renk = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string Yil
        {
            get
            {
                return yil;
            }
            set
            {
                yil = value;
            }
        }

        SqlConnection baglanti = new SqlConnection
              ("Data Source=FURKAN;Initial Catalog=dbOtopark;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public void Ekle()
        {
            komut = new SqlCommand("INSERT INTO tbl_araclar (arac_plaka,renk,model,yil) VALUES (@plaka,@renk,@model,@yil)", baglanti);
            komut.Parameters.AddWithValue("@plaka", this.arac_plaka);
            komut.Parameters.AddWithValue("@renk", this.renk);
            komut.Parameters.AddWithValue("@model", this.model);
            komut.Parameters.AddWithValue("@yil", this.yil);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();
                
            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        

    
        public void Sil()
        {
            komut = new SqlCommand("DELETE FROM tbl_araclar where arac_id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", this.arac_id);

            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        
    }
        public void Guncelle()
        {

            komut = new SqlCommand("UPDATE tbl_araclar SET arac_plaka=@plaka,renk=@renk,model=@model,yil=@yil where arac_id=@id", baglanti);
            komut.Parameters.AddWithValue("@plaka", this.arac_plaka);
            komut.Parameters.AddWithValue("@renk", this.renk);
            komut.Parameters.AddWithValue("@model", this.model);
            komut.Parameters.AddWithValue("@yil", this.yil);
            komut.Parameters.AddWithValue("@id", this.arac_id);


            if ((baglanti.State == ConnectionState.Closed))
            {
                baglanti.Open();

            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public DataTable Tbl_Araclar()
        {
            komut = new SqlCommand("SELECT * FROM tbl_araclar", baglanti);
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
