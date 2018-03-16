using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PINAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listePatient : ContentPage
    {
        public listePatient()
        {
            InitializeComponent();
            chargerListe("");
        }

        async private void chargerListe(string criteria)
        {
            Task<string> getStringTask = Claude.getPatients(criteria);
            string responseSOAP = await getStringTask;

            XElement xml = XElement.Parse(responseSOAP);

            if (xml.Descendants("Success").FirstOrDefault().Value == "true")
            {
                string data = xml.Descendants("Data").FirstOrDefault().Value;
                XElement xmlData = XElement.Parse(data);
                var query = from item in xmlData.Descendants("PAT_Patient")
                            select new Patient
                            {
                                nom = item.Element("Nom").Value,
                                prenom = item.Element("Prenom").Value,
                                dateNaiss = item.Element("DateNaiss").Value,
                                sexe = Convert.ToInt16(item.Element("Sexe").Value),
                                CP = item.Element("CodePostal").Value,
                                adresse = item.Element("Adresse").Value,
                                ville = item.Element("Ville").Value,
                                telFixe = item.Element("TelFixe").Value,
                                portable = item.Element("TelMobile").Value,
                                email = item.Element("Email").Value,

                            };
                await DisplayAlert("Reponse SOAP", responseSOAP, "ok");

                this.laListe.ItemsSource = query;
            }
        }

        async private void laListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new FichePatient((sender as ListView).SelectedItem as Patient), true);
        }

        private void searchPatient_SearchButtonPressed(object sender, EventArgs e)
        {
            chargerListe(this.searchPatient.Text);
        }
    }
}