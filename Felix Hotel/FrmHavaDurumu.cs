using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Felix_Hotel
{
    public partial class FrmHavaDurumu : Form
    {
        public FrmHavaDurumu()
        {
            InitializeComponent();
        }
       

        private void FrmHavaDurumu_Load(object sender, EventArgs e)
        {
            string api = "18bebda6a1bf82251282d8b3e23365f9";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=antalya&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument hava= XDocument.Load(connection);

            var temp = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label1.Text = temp.ToString() + "°";

            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            label2.Text = durum.ToString();

            var konum=hava.Descendants("city").ElementAt(0).Attribute("name").Value;
            labelkonum.Text= konum.ToString();

            if (durum.Contains("bulutlu"))
            {
                picboxbulut.Visible = true;
            }

            else if (durum.Contains("güneş"))
            {
                picboxbulut.Visible = false;
                picboxgunes.Visible = true;
            }
            else
            {
                picboxgunes.Visible = false;
                picboxclear.Visible = true;
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
