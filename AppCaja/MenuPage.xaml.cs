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
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void clientesClicked(object sender, EventArgs e)
        {
            ListaClientesPage myHomePage = new ListaClientesPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private async void backClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void categoriaClicked(object sender, EventArgs e)
        {
            CrearCategoriaPage myHomePage = new CrearCategoriaPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private void descuentoClicked(object sender, EventArgs e)
        {
            CrearDescuentoPage myHomePage = new CrearDescuentoPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private void articulosClicked(object sender, EventArgs e)
        {
            ArtticuloPage myHomePage = new ArtticuloPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private void tecladoClicked(object sender, EventArgs e)
        {
            MainPage myHomePage = new MainPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
    }
}