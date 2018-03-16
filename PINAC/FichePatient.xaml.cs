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
	public partial class FichePatient : ContentPage
	{
		public FichePatient ()
		{
			InitializeComponent ();
            
		}

        public FichePatient(Patient patient)
        {
            InitializeComponent();
            chargerDossier(patient.id);
            this.BindingContext = patient;
        }

        async private void chargerDossier(string id)
        {
            Task<string> getDossier = Claude.getDossierPatient(id);
            string responseDossier = await getDossier;

            XElement xml = XElement.Parse(responseDossier);
            if (xml.Descendants("Success").FirstOrDefault().Value == "true")
            {
                string data = xml.Descendants("Data").FirstOrDefault().Value;
                XElement xmlData = XElement.Parse(data);
                //await DisplayAlert("Response Dossier", responseDossier, "OK");
                //var query = from item in xmlData.Descendants("PAT_Atcd")
                //            select new Patient
                //            {
                //                antePerso = item.Element("Libelle").Value,
                //            };
            }
        }
    }
}