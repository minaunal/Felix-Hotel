using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Felix_Hotel
{
    public partial class FrmMusteriBilgiler : Form
    {
        public FrmMusteriBilgiler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EICGI8C\\MSSQLSERVER01;Initial Catalog=FelixHotel;Integrated Security=True");

        private void listdata()
        {   
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Register", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["Musteriid"].ToString()); 
                item.SubItems.Add(oku["Adi"].ToString());
                item.SubItems.Add(oku["Soyadi"].ToString());
                item.SubItems.Add(oku["Cinsiyet"].ToString());
                item.SubItems.Add(oku["Telefon"].ToString());
                item.SubItems.Add(oku["Mail"].ToString());
                item.SubItems.Add(oku["TC"].ToString());
                item.SubItems.Add(oku["OdaNo"].ToString());
                item.SubItems.Add(oku["Ucret"].ToString());
                item.SubItems.Add(oku["GirisTarihi"].ToString());
                item.SubItems.Add(oku["CikisTarihi"].ToString()); 

                listView1.Items.Add(item);
            }
            baglanti.Close();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            listdata();
        }
        int Musteriid = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Musteriid=Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAd.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            CmbBoxCinsiyet.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTel.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtKimlikNo.Text= listView1.SelectedItems[0].SubItems[6].Text;
            TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtUcret.Text= listView1.SelectedItems[0].SubItems[8].Text;
            DtpGiris.Text= listView1.SelectedItems[0].SubItems[9].Text;
            DtpCikis.Text=listView1.SelectedItems[0].SubItems[10].Text;
        } 

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update odalar set musteriid=null where odano=@odno");
            komut1.Parameters.AddWithValue("@odno", TxtOdaNo.Text);
            komut1.Connection = baglanti;
            komut1.ExecuteNonQuery();
            MessageBox.Show("müşteri başarıyla odadan silindi.");

            baglanti.Close();
            
        }


            private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAd.Clear();
            TxtSoyad.Clear();
            CmbBoxCinsiyet.Text = "";
            TxtMail.Clear();
            TxtKimlikNo.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            MskTxtTel.Clear();
            DtpGiris.Text = "";
            DtpCikis.Text = "";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Register set Adi='" + TxtAd.Text + "',Soyadi='" + TxtSoyad.Text + "',Cinsiyet='" + CmbBoxCinsiyet.Text + "',Telefon='" + MskTxtTel.Text + "',Mail='" + TxtMail.Text + "',TC='" + TxtKimlikNo.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGiris.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + DtpCikis.Value.ToString("yyyy-MM-dd") + "'where Musteriid=" + Musteriid + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listdata();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Register where Musteriid like '%" + textBox1.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
                
            }
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaForm yeni = new FrmAnaForm();
            yeni.ShowDialog();
        }
    }
}
