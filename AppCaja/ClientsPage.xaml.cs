using AppCaja.Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public ClientsPage()
        {
            InitializeComponent();
        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        public async void Save_Clicked(object sender, EventArgs e)
        {
            Cliente clientes = new Cliente();
            clientes.Cliente1 = Nombre.Text;
            clientes.Correo = Correo.Text;
            clientes.Telefono = Telefono.Text;
            clientes.Calle = Calle.Text;
            clientes.Hab = Hab.Text;
            clientes.Ciudad = Ciudad.Text;
            clientes.Estado = Provincia.Text;
            clientes.Zip = Int16.Parse(Zip.Text);
            clientes.Celular = Celular.Text;
            Repositorio repo = new Repositorio();

            try
            {

                Cliente cliente = repo.postCliente(clientes).Result;
                Dialogs.ShowLoading("Cliente Registrado"); ;
                await Task.Delay(2000);
                Dialogs.HideLoading();
                ClientsPage myHomePage = new ClientsPage();
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