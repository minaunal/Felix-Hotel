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
    public partial class FrmOyun : Form
    {
        public FrmOyun()
        {
            InitializeComponent();
        }
        

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        Random rnd = new Random();

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            int width1 = pictureBox1.Width;
            int width2 = pictureBox2.Width;
            int width3 = pictureBox3.Width;
            int yol = label4.Left;

            pictureBox1.Left = pictureBox1.Left + rnd.Next(5, 15);
            pictureBox2.Left = pictureBox2.Left + rnd.Next(5, 15);
            pictureBox3.Left = pictureBox3.Left + rnd.Next(5, 15);

            if (pictureBox1.Left > pictureBox2.Left + 5 && pictureBox1.Left > pictureBox3.Left + 5)
            {
                label5.Text = "1 numaralı at rakiplerini geçiyor!";
            }

            if (pictureBox2.Left > pictureBox1.Left + 5 && pictureBox2.Left > pictureBox3.Left + 5)
            {
                label5.Text = "2 numaralı ezip geçiyor!";
            }

            if (pictureBox3.Left > pictureBox2.Left + 5 && pictureBox3.Left > pictureBox1.Left + 5)
            {
                label5.Text = "3 numaralı at atağa geçti!";
            }



            if (width1 + pictureBox1.Left >= yol)
            {
                timer1.Enabled = false;
                if (comboBox1.Text == "1.at")
                    label5.Text = "tahmininizi kazandiniz!";
                else
                    label5.Text = "yanlış tahmin, kazanan at:1 numara oldu!";
            }


            if (width2 + pictureBox2.Left >= yol)
            {
                timer1.Enabled = false;
                if (comboBox1.Text == "2.at")
                    label5.Text = "tahmininizi kazandiniz!";
                else
                    label5.Text = "yanlış tahmin, kazanan at:2 numara oldu!";
            }

            if (width3 + pictureBox3.Left >= yol)
            {
                timer1.Enabled = false;
                if (comboBox1.Text == "3.at")
                    label5.Text = "tahmininizi kazandiniz!";
                else
                    label5.Text = "yanlış tahmin, kazanan at:3 numara oldu!";
            }

        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaForm yeni = new FrmAnaForm();
            yeni.ShowDialog();
        }
    }
}
