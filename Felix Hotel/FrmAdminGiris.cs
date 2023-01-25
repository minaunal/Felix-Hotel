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
    public partial class FrmAdminGiris : Form
    {
        private string text;
        private int len;
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {   if (TxtKullaniciAdi.Text == "felix" && TxtSifre.Text == "2022")
            {
                FrmAnaForm gecis = new FrmAnaForm();
                gecis.Show();
                this.Hide();
            }
            else MessageBox.Show("hatalı kullanıcı adı ya da şifre.");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {   
                    label3.Text = label3.Text + text.ElementAt(len);
                    len++;
                
            }
            else
                timer1.Stop();
        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {
            TxtKullaniciAdi.Text = "kullanıcı adınız";
            TxtKullaniciAdi.ForeColor = Color.Gray;
            TxtSifre.Text = "şifreniz";
            TxtSifre.ForeColor=Color.Gray;
            label3.BackColor = System.Drawing.Color.Transparent;

            //kayan yazı
            text =label3.Text;
            label3.Text = "";
            timer1.Start();

        }
        private void TxtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (TxtKullaniciAdi.Text == "kullanıcı adınız")
            {

                TxtKullaniciAdi.Text = "";
            }
        }
        


        private void TxtSifre_Enter(object sender, EventArgs e)
        {
            if (TxtSifre.Text == "şifreniz")
            {

                TxtSifre.Text = "";
            }
        }
      

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TxtSifre.UseSystemPasswordChar = false;
        }
    }
}
