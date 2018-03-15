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
	public partial class loginPage : ContentPage
	{
		public loginPage ()
		{
			InitializeComponent ();
		}

        async private void btnLogin_Clicked(object sender, EventArgs e)
        {
            string login = this.entryLogin.Text;
            string password = this.entryPassword.Text;

            Task<string> getStringTask = Claude.userLogin(login, password);
            string responseSOAP = await getStringTask;

            if(login == "house" && password == "aaaaaa")
                await Navigation.PushModalAsync(new ListConsultation(), true);
            else
                await DisplayAlert("Réponse SOAP", responseSOAP, "OK");
        }
    }
}