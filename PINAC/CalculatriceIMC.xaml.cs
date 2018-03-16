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
	public partial class CalculatriceIMC : ContentPage
	{
		public CalculatriceIMC ()
		{
			InitializeComponent ();
		}

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculIMC();
        }

        private void calculIMC()
        {
            double poids;
            double taille;
            double imc;

            poids = Convert.ToDouble(this.txtPoids.Text);
            taille = Convert.ToDouble(this.txtTaille.Text) / 100;

            imc = poids / (taille * taille);

            if (poids < 51)
            {
                //this.couleurIMC.BackgroundColor = Color.Violet;
                this.messageIMC.Text = "famine";
            }
            else if (poids < 57)
            {
                //this.couleurIMC.BackgroundColor = Color.Indigo;
                this.messageIMC.Text = "maigreur";
            }
            else if (poids < 77)
            {
                //this.couleurIMC.BackgroundColor = Color.Blue;
                this.messageIMC.Text = "corpulence normale";
            }
            else if (poids < 93)
            {
                //this.couleurIMC.BackgroundColor = Color.Green;
                this.messageIMC.Text = "surpoids";
            }
            else if (poids < 108)
            {
                //this.couleurIMC.BackgroundColor = Color.Yellow;
                this.messageIMC.Text = "obésité modérée";
            }
            else if (poids < 124)
            {
                //this.couleurIMC.BackgroundColor = Color.Orange;
                this.messageIMC.Text = "obésité sévère";
            }
            else if (poids > 124)
            {
                //this.couleurIMC.BackgroundColor = Color.Red;
                this.messageIMC.Text = "obésité mordbide";
            }

            this.lblIMC.Text = "IMC: " + imc;
        }

        private void txtPoids_Completed(object sender, EventArgs e)
        {
            calculIMC();
        }
    }
}