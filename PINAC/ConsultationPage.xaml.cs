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
            InitializeComponent();
        }

        public ConsultationPage(RDV leRDV)
        {
            InitializeComponent();
            this.BindingContext = leRDV;
        }

        private void commencerConsultation_Clicked(object sender, System.EventArgs e)
        {

        }

        async private void retourAgenda_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}