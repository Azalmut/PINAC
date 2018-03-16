using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PINAC
{
    public partial class MainPage : MasterDetailPage
    {
        RDV leRendezVous;

        public MainPage()
        {
            InitializeComponent();
            this.Navigation.PushModalAsync(new loginPage(), true);
            MasterPage.Button1.Clicked += new EventHandler(Button_Clicked);
            MasterPage.Button2.Clicked += new EventHandler(Button_Clicked);
            MasterPage.Button3.Clicked += new EventHandler(Button_Clicked);
            MasterPage.Button4.Clicked += new EventHandler(Button_Clicked);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(button.Text == "Gestion Patients")
            {
                var page = new listePatient();
                page.Title = button.Text;

                this.Detail = new NavigationPage(page);
            }
            else if(button.Text == "Gestion Agenda")
            {
                var page = new Agenda();
                page.Title = button.Text;

                this.Detail = new NavigationPage(page);
            }
            else if(button.Text == "IMC")
            {
                var page = new CalculatriceIMC();
                page.Title = button.Text;

                this.Detail = new NavigationPage(page);
            }
            else if (button.Text == "Risque Cardio Vasculaire")
            {
                var page = new CalculatriceESC();
                page.Title = button.Text;

                this.Detail = new NavigationPage(page);
            }
        }

    }
}