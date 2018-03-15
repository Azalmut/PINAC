using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PINAC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListConsultation : ContentPage
	{
		public ListConsultation ()
		{
            InitializeComponent();
            //chargerListeDossier(2);
		}

        async private void chargerListeDossier(string id)
        {
            Task<string> getStringTask = Claude.getDossierPatient(id);
            string responseSOAP = await getStringTask;

            XElement xml = XElement.Parse(responseSOAP);

            // await DisplayAlert("Response SOAP", responseSOAP, "OK");

            if(xml.Descendants("Success").FirstOrDefault().Value == "true")
            {
                string data = xml.Descendants("Data").FirstOrDefault().Value;
                XElement xmlData = XElement.Parse(data);
                var query = from item in xmlData.Descendants("PAT_Consult")
                            select new DossierPatient
                            {
                                idDossier = item.Element("id").Value,
                                idPatient = item.Element("PatientId").Value,
                                dateConsultation = Convert.ToDateTime(item.Element("DateConsult").Value),
                                motif = item.Element("Motif").Value,
                                examClinique = item.Element("ExamClinique").Value,
                                diagnostic = item.Element("Diagnostic").Value
                            };

                await DisplayAlert("Alert consultation", responseSOAP, "OK");

                this.listConsultation.ItemsSource = query;
            }
        }

        private void searchDossierPatient_SearchButtonPressed(object sender, EventArgs e)
        {
            chargerListeDossier(this.searchDossierPatient.Text);
        }
    }
}