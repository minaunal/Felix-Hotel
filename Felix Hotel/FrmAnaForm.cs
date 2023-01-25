using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felix_Hotel
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void BtnMusteriKayit_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri gecis=new FrmYeniMusteri();
            gecis.Show();
            this.Hide();
        }

        

        private void btnMusteriBilgi_Click(object sender, EventArgs e)
        {
            FrmMusteriBilgiler gecis=new FrmMusteriBilgiler();
            gecis.Show();
            this.Hide();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnGiderler_Click(object sender, EventArgs e)
        {
            FrmGiderler gecis=new FrmGiderler();
            gecis.Show();
            this.Hide();
        }

        private void BtnDegerlendirme_Click(object sender, EventArgs e)
        {
            FrmMesaj gecis=new FrmMesaj();
            gecis.Show();
            this.Hide();
        }

        private void BtnHavaDurumu_Click(object sender, EventArgs e)
        {
            FrmHavaDurumu gecis=new FrmHavaDurumu();
            gecis.Show();
            this.Hide();
        }

        private void BtnOyun_Click(object sender, EventArgs e)
        {
            FrmOyun gecis=new FrmOyun();
            gecis.Show();
            this.Hide();
        }

       
    }
}
