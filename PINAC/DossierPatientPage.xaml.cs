using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PINAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DossierPatientPage : ContentPage
    {
        public DossierPatientPage()
        {
            InitializeComponent();
        }

        public DossierPatientPage(DossierPatient leDossier)
        {
            InitializeComponent();
            this.BindingContext = leDossier;
        }
    }
}