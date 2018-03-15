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
	public partial class FichePatient : ContentPage
	{
		public FichePatient ()
		{
			InitializeComponent ();
		}

        public FichePatient(Patient patient)
        {
            InitializeComponent();
            this.BindingContext = patient;
        }
    }
}