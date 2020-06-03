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
    public partial class CrearCategoriaPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public CrearCategoriaPage()
        {
            InitializeComponent();
        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        public async void Save_Clicked(object sender, EventArgs e) 
        {
            Categoria categoriar = new Categoria();
            categoriar.Categoria1 = Categoria.Text;
            Repositorio repo = new Repositorio();
            try
            {

                Categoria categoria = repo.postCategoria(categoriar).Result;
                Dialogs.ShowLoading("Categoria Creada");
                await Task.Delay(2000);
                Dialogs.HideLoading();
                CrearCategoriaPage myHomePage = new CrearCategoriaPage();
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