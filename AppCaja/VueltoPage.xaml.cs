using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VueltoPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public VueltoPage(Cabecera cabecera)
        {
            InitializeComponent();
            monto.Text = cabecera.Total.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            monto.Text = (Double.Parse(vuelto.Text)  - Double.Parse(monto.Text)).ToString();
            bool answer = await DisplayAlert("EL VUELTO ES "+monto.Text+"", "¿Desea ticket o recibo?", "TICKET", "RECIBO");
        }
    }
}