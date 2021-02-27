using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otopark_otomasyon
{


    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

        }

        int id = 0;
        int secilen;


        private void Form1_Load(object sender, EventArgs e)
        {
          
            Araclar arac = new Araclar();
            DataTable tbl_araclar = arac.Tbl_Araclar();

            Musteriler musteri = new Musteriler();
            DataTable tbl_musteriler = musteri.Tbl_Musteriler();

            Hizmetler hizmet = new Hizmetler();
            DataTable tbl_hizmetler = hizmet.Tbl_Hizmetler();

            Abonelik abon = new Abonelik();
            DataTable tbl_abonelik = abon.Tbl_Abonelik();

            data_Araclar.DataSource = tbl_araclar;
            data_Musteriler.DataSource = tbl_musteriler;
            data_Hizmetler.DataSource = tbl_hizmetler;
            data_Abonelikler.DataSource = tbl_abonelik;

            data_H_arac.DataSource = tbl_araclar;
            data_H_musteri.DataSource = tbl_musteriler;

        }

        //----------ARACLAR--------------//

        private void button1_Click(object sender, EventArgs e)
        {
            Araclar arac = new Araclar();
            arac.Arac_plaka = tb_plaka.Text;
            arac.Renk = tb_renk.Text;
            arac.Model = tb_model.Text;
            arac.Yil = tb_yil.Text;
            arac.Ekle();

            Form1_Load(sender,e);

            MessageBox.Show("EKLENDİ");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Araclar arac = new Araclar();
            arac.Arac_plaka = tb_plaka.Text;
            arac.Renk = tb_renk.Text;
            arac.Model = tb_model.Text;
            arac.Yil = tb_yil.Text;
            arac.Arac_id = id;
            arac.Guncelle();

            Form1_Load(sender, e);

            MessageBox.Show("GÜNCELLENDİ");
        }
        
        private void aracbtn_sil_Click(object sender, EventArgs e)
        {
            Araclar arac = new Araclar();
            arac.Arac_id = id;
            arac.Sil();

            Form1_Load(sender, e);

            MessageBox.Show("SİLİNDİ");
        }
        private void data_Araclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = data_Araclar.Rows[e.RowIndex];
            id = int.Parse(row.Cells[0].Value.ToString());

            secilen = data_Araclar.SelectedCells[0].RowIndex;

            tb_plaka.Text = data_Araclar.Rows[secilen].Cells[1].Value.ToString();
            tb_renk.Text = data_Araclar.Rows[secilen].Cells[2].Value.ToString();
            tb_model.Text = data_Araclar.Rows[secilen].Cells[3].Value.ToString();
            tb_yil.Text = data_Araclar.Rows[secilen].Cells[4].Value.ToString();
        }
        

        //----------MUSTERİLER--------------//

        private void m_btnEkle_Click(object sender, EventArgs e)
        {

            Musteriler musteri = new Musteriler();
            musteri.Musteri_adi_soyadi = m_tbAd.Text;
            musteri.Musteri_adres = m_tbAdres.Text;
            musteri.Musteri_tel = m_tbTel.Text;
            musteri.Ekle();

            Form1_Load(sender, e);

            MessageBox.Show("EKLENDİ");
        }

        private void m_btnSil_Click(object sender, EventArgs e)
        {
            Musteriler musteri = new Musteriler();
            musteri.Musteri_id = id;

            musteri.Sil();

            Form1_Load(sender, e);

            MessageBox.Show("SİLİNDİ");
        }

        private void m_btnGuncelle_Click(object sender, EventArgs e)
        {

            Musteriler musteri = new Musteriler();
            musteri.Musteri_adi_soyadi = m_tbAd.Text;
            musteri.Musteri_adres = m_tbAdres.Text;
            musteri.Musteri_tel = m_tbTel.Text;
            musteri.Musteri_id = id;
            musteri.Guncelle();

            Form1_Load(sender, e);

            MessageBox.Show("GÜNCELLENDİ");
        }
        private void data_Musteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = data_Musteriler.Rows[e.RowIndex];

            id = int.Parse(row.Cells[0].Value.ToString());

            secilen = data_Musteriler.SelectedCells[0].RowIndex;

            m_tbAd.Text = data_Musteriler.Rows[secilen].Cells[1].Value.ToString();
            m_tbAdres.Text = data_Musteriler.Rows[secilen].Cells[2].Value.ToString();
            m_tbTel.Text = data_Musteriler.Rows[secilen].Cells[3].Value.ToString();
        }
        

        //----------ABONELİK--------------//

        private void a_btnEkle_Click(object sender, EventArgs e)
        {

            Abonelik abon = new Abonelik();
            abon.Abonelik_tipi = a_tbAbontip.Text;
            abon.Abonelik_baslangic_tarihi = DateTime.Parse(a_tbAbonbas.Text);
            abon.Abonelik_bitis_tarihi = DateTime.Parse(a_tbAbonbit.Text);
            abon.Ekle();

            Form1_Load(sender, e);

            MessageBox.Show("EKLENDİ");
        }

        private void a_btnGuncelle_Click(object sender, EventArgs e)
        {
            Abonelik abon = new Abonelik();
            abon.Abonelik_tipi = a_tbAbontip.Text;
            abon.Abonelik_baslangic_tarihi = DateTime.Parse(a_tbAbonbas.Text);
            abon.Abonelik_bitis_tarihi = DateTime.Parse(a_tbAbonbit.Text);
            abon.Abonelik_id = id;
            abon.Guncelle();

            Form1_Load(sender, e);

            MessageBox.Show("GÜNCELLENDİ");
        }

        private void a_btnSil_Click(object sender, EventArgs e)
        {
            Abonelik abon = new Abonelik();
            abon.Abonelik_id = id;
            abon.Sil();

            Form1_Load(sender, e);

            MessageBox.Show("SİLİNDİ");
        }
        private void data_Abonelikler_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = data_Abonelikler.Rows[e.RowIndex];

            id = int.Parse(row.Cells[0].Value.ToString());

            secilen = data_Abonelikler.SelectedCells[0].RowIndex;

            a_tbAbontip.Text = data_Abonelikler.Rows[secilen].Cells[1].Value.ToString();
            a_tbAbonbas.Text = data_Abonelikler.Rows[secilen].Cells[2].Value.ToString();
            a_tbAbonbit.Text = data_Abonelikler.Rows[secilen].Cells[3].Value.ToString();
        }
        

        //----------HİZMETLER--------------//

        private void h_btnEkle_Click(object sender, EventArgs e)
        {

            Hizmetler hizmet = new Hizmetler();
            hizmet.Aracgiris_saati = DateTime.Parse(h_tbGirsaat.Text);
            hizmet.Araccikis_saati = DateTime.Parse(h_tbCiksaat.Text);
            hizmet.Arac_plaka = h_tbPlaka.Text;
            hizmet.Musteri_adi_soyadi = h_tbAd.Text;
            hizmet.Abonelik_tipi = h_tbAbon.Text;
            hizmet.Ucret = h_tbUcret.Text;
            

            hizmet.Ekle();

            Form1_Load(sender, e);

            MessageBox.Show("EKLENDİ");
        }

        private void h_btnSil_Click(object sender, EventArgs e)
        {
            Hizmetler hizmet = new Hizmetler();
            hizmet.Hizmet_id = id;

            hizmet.Sil();

            Form1_Load(sender, e);

            MessageBox.Show("SİLİNDİ");
        }

        private void h_btnGuncelle_Click(object sender, EventArgs e)
        {

            Hizmetler hizmet = new Hizmetler();
            hizmet.Arac_plaka = h_tbPlaka.Text;
            hizmet.Musteri_adi_soyadi = h_tbAd.Text;
            hizmet.Aracgiris_saati = DateTime.Parse(h_tbGirsaat.Text);
            hizmet.Araccikis_saati = DateTime.Parse(h_tbCiksaat.Text);
            hizmet.Abonelik_tipi = h_tbAbon.Text;
            hizmet.Ucret = h_tbUcret.Text;
            hizmet.Hizmet_id = id;

            hizmet.Guncelle();

            Form1_Load(sender, e);

            MessageBox.Show("GÜNCELLENDİ");

        }
        private void data_Hizmetler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = data_Hizmetler.Rows[e.RowIndex];

            id = int.Parse(row.Cells[0].Value.ToString());

            secilen = data_Hizmetler.SelectedCells[0].RowIndex;

            h_tbGirsaat.Text = data_Hizmetler.Rows[secilen].Cells[1].Value.ToString();
            h_tbCiksaat.Text = data_Hizmetler.Rows[secilen].Cells[2].Value.ToString();
            h_tbUcret.Text = data_Hizmetler.Rows[secilen].Cells[3].Value.ToString();
            h_tbAbon.Text = data_Hizmetler.Rows[secilen].Cells[1].Value.ToString();
            h_tbAd.Text = data_Hizmetler.Rows[secilen].Cells[2].Value.ToString();
            h_tbPlaka.Text = data_Hizmetler.Rows[secilen].Cells[3].Value.ToString();
        }
        private void data_H_arac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = data_H_arac.SelectedCells[0].RowIndex;

            h_tbPlaka.Text = data_H_arac.Rows[secilen].Cells[1].Value.ToString();
        }

        private void data_H_musteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = data_H_musteri.SelectedCells[0].RowIndex;

            h_tbAd.Text = data_H_musteri.Rows[secilen].Cells[1].Value.ToString();
        }
        
    }
}
    
    
