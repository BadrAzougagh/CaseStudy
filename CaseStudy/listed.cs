using CaseStudy.DAL;
using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CaseStudy
{
    public partial class listed : Form
    {
        public listed()
        {
            InitializeComponent();
        }

        private void listed_Load(object sender, EventArgs e)
        {
            //Hier maken we een object aan om daarna de methode getcompanies te gebruiken.
            CompanyRepository companyRepository = new CompanyRepository();

            SortedSet<favoritestock> stocks = new SortedSet<favoritestock>(companyRepository.GetCompanies());

            //Hier laten we alle symbolen zien die door de gebruiker is toegevoegd
            foreach (var company in stocks)
            {
                favoriteListbox.Items.Add(company.Symbol);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Als de gebruiker op deze knop drukt wordt hij naar de homepage gestuurd.
            homescreen home = new homescreen();
            home.Show();
            Visible = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CompanyRepository companyRepository = new CompanyRepository();

            SortedSet<favoritestock> stocks = new SortedSet<favoritestock>(companyRepository.GetCompanies());

           //Zoals u ziet, maken we hier weer een object om de methode getcompanies en deletecompany te gebruiken.
           //De methode deletecompany wordt pas toegepast als de checkbox is aangeduid. Anders komt er een popup dat de gebruiker niets heeft geselecteerd.
            if (favoriteListbox.CheckedItems.Count != 0)
            {
                string deletestock;
                for (int x = 0; x < favoriteListbox.CheckedItems.Count; x++)
                {
                    deletestock = favoriteListbox.CheckedItems[x].ToString();
                    companyRepository.DeleteCompany(deletestock);
                    listed listed = new listed();
                    listed.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("U heeft niets geselecteerd!");
            }
          

           

        }

     
    }
}
