using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PINAC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultationPage : ContentPage
	{
		public ConsultationPage()
		{
			InitializeComponent ();
		}

        public ConsultationPage(RDV leRendezVous)
        {
            InitializeComponent();
            this.BindingContext = leRendezVous;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculIMC();
        }

        private void calculIMC()
        {
            double poids;
            int taille;
            double imc;

            poids = Convert.ToDouble(this.txtPoids.Text);
            taille = Convert.ToInt32(this.txtTaille.Text);

            imc = poids * (taille * taille);
            this.lblIMC.Text = "IMC: " + imc;
        }

        private void txtPoids_Completed(object sender, EventArgs e)
        {
            calculIMC();
        }
    }
}