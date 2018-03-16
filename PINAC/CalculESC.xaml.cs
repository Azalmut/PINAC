using Score;
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
	public partial class CalculESC : ContentPage
	{
		public CalculESC ()
		{
			InitializeComponent ();
            this.entryTension.Text = this.stepTension.Value.ToString();
            this.entryChol.Text = this.stepChol.Value.ToString();
            this.entryAge.Text = this.stepAge.Value.ToString();
        }

        private void stepTension_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.entryTension.Text = this.stepTension.Value.ToString();
            calcul();
        }

        private void stepChol_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.entryChol.Text = this.stepChol.Value.ToString();
            calcul();
        }

        private void stepAge_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.entryAge.Text = this.stepAge.Value.ToString();
            calcul();
        }

        public void calcul()
        {
            ScoreESC scoreESC = new ScoreESC();
            int sexe;
            int tabac;
            int score;

            if (this.switchSexe.IsToggled)
                sexe = 1;
            else
                sexe = 2;

            if (this.switchTabac.IsToggled)
                tabac = 1;
            else
                tabac = 0;

            score = scoreESC.calculateScoreCVD(sexe, tabac, Convert.ToInt32(this.stepAge.Value), Convert.ToInt32(this.stepTension.Value), Convert.ToInt32(this.stepChol.Value));
            this.lblScore.Text = "Score: " + score;
            this.lblScore.BackgroundColor = scoreESC.getColorFromScore(score);

        }

        private void switchSexe_Toggled(object sender, ToggledEventArgs e)
        {
            calcul();
        }

        private void switchTabac_Toggled(object sender, ToggledEventArgs e)
        {
            calcul();
        }
    }
}