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
    public partial class FrmMesaj : Form
    {
        public FrmMesaj()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EICGI8C\\MSSQLSERVER01;Initial Catalog=FelixHotel;Integrated Security=True");
        private void listdata()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Mesaj", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["Mesajid"].ToString());
                
                item.SubItems.Add(oku["İsim"].ToString());
                item.SubItems.Add(oku["Mesaj"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Mesaj(İsim,Mesaj) values ('" + textBox1.Text + "','" + richTextBox1.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listdata();
        }

        private void FrmMesaj_Load(object sender, EventArgs e)
        {
           listdata();
        }
        int Musteriid = 0;


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Musteriid = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            richTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaForm yeni = new FrmAnaForm();
            yeni.ShowDialog();
        }
    }
}
