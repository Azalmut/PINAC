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
	public partial class Agenda : ContentPage
	{
		public Agenda()
		{
            InitializeComponent();
            
            //chargerListeDossier("");
        }

        //async private void chargerListeDossier(string id)
        //{
        //    Task<string> getStringTask = Claude.getDossierPatient(id);
        //    string responseSOAP = await getStringTask;

        //    XElement xml = XElement.Parse(responseSOAP);

        //    if(xml.Descendants("Success").FirstOrDefault().Value == "true")
        //    {
        //        string data = xml.Descendants("Data").FirstOrDefault().Value;
        //        XElement xmlData = XElement.Parse(data);
        //        var query = from item in xmlData.Descendants("PAT_Consult")
        //                    select new DossierPatient
        //                    {
        //                        idDossier = item.Element("id").Value,
        //                        idPatient = item.Element("PatientId").Value,
        //                        dateConsultation = Convert.ToDateTime(item.Element("DateConsult").Value),
        //                        motif = item.Element("Motif").Value,
        //                        examClinique = item.Element("ExamClinique").Value,
        //                        diagnostic = item.Element("Diagnostic").Value
        //                    };

        //        //var query2 = from item in xmlData.Descendants("PAT_Patient")
        //        //             where item.Element("id") == item.Element("PatientId")
        //        //             select new Patient
        //        //             {

        //        //             };

        //        await DisplayAlert("Alert consultation", responseSOAP, "OK");

        //        this.listRDV.ItemsSource = query;
        //    }
        //}

        async private void chargerListeRDV(DateTime date)
        {
            Task<string> getStringTask = Claude.getRDV(date);
            string responseSOAP = await getStringTask;

            XElement xml = XElement.Parse(responseSOAP);

            //if (xml.Descendants("Success").FirstOrDefault().Value == "true")
            //{
            //    string data = xml.Descendants("Data").FirstOrDefault().Value;
            //    XElement xmlData = XElement.Parse(data);
            //    var query = from item in xmlData.Descendants("PAT_Consult")
            //                select new DossierPatient
            //                {
            //                    idDossier = item.Element("id").Value,
            //                    idPatient = item.Element("PatientId").Value,
            //                    dateConsultation = Convert.ToDateTime(item.Element("DateConsult").Value),
            //                    motif = item.Element("Motif").Value,
            //                    examClinique = item.Element("ExamClinique").Value,
            //                    diagnostic = item.Element("Diagnostic").Value
            //                };

                await DisplayAlert("Alert consultation", responseSOAP, "OK");

               //this.listRDV.ItemsSource = query;
            }
        }

        private void searchRDV_SearchButtonPressed(object sender, EventArgs e)
        {
        chargerListeRDV(this.searchRDV.Text);
        }

        async private void listRDV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new ConsultationPage((sender as ListView).SelectedItem as RDV), true);
        }
    }
}