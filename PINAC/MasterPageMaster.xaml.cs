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
	public partial class MasterPageMaster : ContentPage
	{
        public Button Button1
        {
            get
            {
                return this.Bt1;
            }
        }

        public Button Button2
        {
            get
            {
                return this.Bt2;
            }
        }

        public Button Button3
        {
            get
            {
                return this.Bt3;
            }
        }

        public Button Button4
        {
            get
            {
                return this.Bt4;
            }
        }

        public MasterPageMaster ()
		{
			InitializeComponent ();
		}
	}
}