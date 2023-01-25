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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EICGI8C\\MSSQLSERVER01;Initial Catalog=FelixHotel;Integrated Security=True");
       
        private void listdata()
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Giderler", baglanti);
            SqlDataReader oku= komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item=new ListViewItem(oku["Elektrik"].ToString());
                
                item.SubItems.Add(oku["Su"].ToString());
                item.SubItems.Add(oku["Yakit"].ToString());
                item.SubItems.Add(oku["İnternet"].ToString());
                item.SubItems.Add(oku["Gida"].ToString());
                item.SubItems.Add(oku["Temizlik"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }
       
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
           listdata();
        }

        private void BtnKaydet1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Giderler(Elektrik,Su,Yakit,İnternet,Gida,Temizlik) values('" + TxtElektrik.Text + "','" + TxtSu.Text + "','" + TxtYakit.Text + "','" + TxtNet.Text + "','" + TxtGida.Text + "','" + TxtTemizlik.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaForm yeni=new FrmAnaForm();
            yeni.ShowDialog();
        }

        
    }
}
