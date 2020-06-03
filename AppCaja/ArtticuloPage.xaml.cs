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
    public partial class ArtticuloPage : ContentPage
    {
        Articulo[] Lista;
        public ArtticuloPage()
        {
            InitializeComponent();
            Repositorio repo = new Repositorio();
            Articulo[] listaarticulo = repo.getArticulo();
            ListaArticulos.ItemsSource = listaarticulo;
            Lista = listaarticulo;
        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            Repositorio repo = new Repositorio();
            Articulo[] listaarticulo = repo.getArticulo();
            List<Articulo> lst = listaarticulo.OfType<Articulo>().ToList();
            var ArticuloSearched = lst.Where(l => l.Articulo1.Contains(SearchBar.Text));
            ListaArticulos.ItemsSource = ArticuloSearched;
        }
        private void crearClicked(object sender, EventArgs e)
        {
            CrearArticuloPage myHomePage = new CrearArticuloPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
    }
}