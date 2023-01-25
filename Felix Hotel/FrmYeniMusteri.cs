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
    public partial class FrmYeniMusteri : Form
    {
        public FrmYeniMusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EICGI8C\\MSSQLSERVER01;Initial Catalog=FelixHotel;Integrated Security=True");

        private void DtpCikis_ValueChanged(object sender, EventArgs e)
        {
            int ucret;
            DateTime giristarih = Convert.ToDateTime(DtpGiris.Text);
            DateTime cikistarih=Convert.ToDateTime(DtpCikis.Text);
            TimeSpan toplamgun = cikistarih - giristarih;
            ucret = (Convert.ToInt16(toplamgun.TotalDays))*300;
            TxtUcret.Text=ucret.ToString();
        }
        // müşteri kaydet
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            //müşteri kaydı
            SqlCommand komut = new SqlCommand("insert into Register(Adi,Soyadi,Cinsiyet,Telefon" +
                ",Mail,TC,OdaNo,Ucret," + "GirisTarihi,CikisTarihi) " +
                "values ('" + TxtAd.Text + "','" + TxtSoyad.Text + "','" + CmbBoxCinsiyet.Text + "','"
                + MskTxtTel.Text + "','" + TxtMail.Text + "','"
                + TxtKimlikNo.Text + "','" + comboBox1.Text + "','"
                + TxtUcret.Text + "','" + DtpGiris.Value.ToString("yyyy-MM-dd")
                + "','" + DtpCikis.Value.ToString("yyyy-MM-dd") + "')", baglanti);
            komut.ExecuteNonQuery();
           
            //müşteri kaydı yapılınca odalar tableına müşteriidyi ekleme
            SqlCommand komut1 = new SqlCommand("UPDATE odalar set musteriid=(select Musteriid from Register " +
                "where Register.OdaNo=@odno) where odano=@odno");
            komut1.Parameters.AddWithValue("@odno", comboBox1.Text);
            komut1.Connection = baglanti;
            komut1.ExecuteNonQuery();
            MessageBox.Show("müşteri kaydı başarıyla yapıldı.");

            baglanti.Close();


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaForm yeni = new FrmAnaForm();
            yeni.ShowDialog();
        }
        //bos dolu odaları gösterme
        public void odadurumu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odalar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                foreach (Control oda in this.groupBox2.Controls)
                {
                    if (oda is Button && oda.Name != "BtnKaydet")
                    {
                        
                        if (oku["odano"].ToString() == oda.Text && oku["musteriid"].ToString()!="")
                        {
                            oda.BackColor = Color.Red;
                            oda.Enabled = false;
                           
                        }
                       
                    }
                   
                }
                
            }
            baglanti.Close();
        }
        //comboboxtaki odaların doluluk boşluk durumuna göre gorunurlugunu değiştirme
        public void odasecme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odalar where musteriid is null");
            
            komut.CommandType = CommandType.Text;
            komut.Connection = baglanti;
            
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable data=new DataTable();
            adapter.Fill(data);
            baglanti.Close();


            foreach(DataRow row in data.Rows)
            {
                comboBox1.Items.Add(row["odano"].ToString());
            }
        } 
        

        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            odadurumu();
            odasecme();
        }
    }
}
