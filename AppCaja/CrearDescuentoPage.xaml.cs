using Acr.UserDialogs;
using AppCaja.Conexiones;
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
    public partial class CrearDescuentoPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public CrearDescuentoPage()
        {
            InitializeComponent();
        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        public async void Save_Clicked(object sender, EventArgs e)
        {
            Descuento descuentor = new Descuento();
            descuentor.Descuento1 = Nombre.Text;
            descuentor.Porcentaje = Double.Parse(Porcen.Text);
            Repositorio repo = new Repositorio();
            try
            {

                Descuento descuento = repo.postDescuento(descuentor).Result;
                Dialogs.ShowLoading("Descuento Creado");
                await Task.Delay(2000);
                Dialogs.HideLoading();
                CrearDescuentoPage myHomePage = new CrearDescuentoPage();
                NavigationPage.SetHasNavigationBar(myHomePage, false);
                await Navigation.PushModalAsync(myHomePage);
            }

            catch (Exception ex)
            {
                await DisplayAlert("Registrarse Error", ex.Message, "Gracias");
            }
        }
    }
}