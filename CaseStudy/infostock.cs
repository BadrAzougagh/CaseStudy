using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CaseStudy.DAL;
using CaseStudy.Models;
using Newtonsoft.Json.Linq;
namespace CaseStudy
{
    public partial class infostock : Form
    {

        

        JObject json;
         
        //Dit hebben we nodig om aan onze api te geraken.
        public infostock(JObject json)
        {
            this.json = json;
            InitializeComponent();
        }

        private void infostock_Load(object sender, EventArgs e) 
        {
            //We halen hier de gevraagde symbool uit onze api en printen dit op het scherm.
            label1.Text = ((string)json["data"][0]["symbol"] +" sloot laatst op "+ (string)json["data"][0]["close"]+"$.");
            label2.Text = ((string)json["data"][0]["symbol"] + " handelt op de " + (string)json["data"][0]["exchange"] + ".");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Als de gebruiker op 'go home' klikt dan wordt hij terug naar de homescreen gestuurt.
            homescreen home = new homescreen();
            home.Show();
            Visible = false;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
                //Ik maak hier een object en met de object kan ik de methode Insertcompany gebruiken. Zo kan ik het symbool toevoegen aan mijn repo.
                CompanyRepository companyRepository = new CompanyRepository();

           
            favoritestock favoritestock = new favoritestock { Symbol = (string)json["data"][0]["symbol"] };

                companyRepository.InsertCompany(favoritestock);

                MessageBox.Show("Stock is succesvol opgeslagen!");
            
         
        }
    }
}
