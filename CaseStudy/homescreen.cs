using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy
{
    public partial class homescreen : Form
    {

        public homescreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        

        private async void button1_Click(object sender, EventArgs e)
        {
            //Hier maken we gebruik van een trycatch om de error op te vangen.
            try
            {
                //Dit is de url die we nodig hebben om onze api data op te halen. Achter deze url hebben we een parameter. D
                //deze parameter is het symbool/company dat de gebruiker opvraagt.
                HttpClient client = new HttpClient();
                string url = string.Format("http://api.marketstack.com/v1/eod?access_key=c76c4ad0c1f69b7bbcddc4b2c0c555ce&symbols={0}", textBox1.Text);
                string apiString = await client.GetStringAsync(url);



                //Hier converteren we apistring in een json format. Zodat we later hier data uit kunnen halen.

                JObject json = JObject.Parse(apiString);



                infostock info = new infostock(json);
                info.Show();
                Visible = false;
            }
            catch
            {
                MessageBox.Show("Deze stock symbool bestaat niet. Probeer nogmaals");
            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void homescreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void titel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Als de gebruiker zijn watchlist wilt zien dan klikt hij op deze knop en wordt hij naar de listed scherm gestuurd.
            listed listed = new listed();
            listed.Show();
            Visible = false;
        }
    }
}
