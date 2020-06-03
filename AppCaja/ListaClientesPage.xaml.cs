using AppCaja.Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaClientesPage : ContentPage
    {
        Cliente[] Lista;
        public ListaClientesPage()
        {
            InitializeComponent();
            
            
            Repositorio repo = new Repositorio();
            Cliente[] listacliente = repo.getCliente();
            ListaClientes.ItemsSource = listacliente;
            Lista = listacliente;
            


        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            Repositorio repo = new Repositorio();
            Cliente[] listacliente = repo.getCliente();
            List<Cliente> lst = listacliente.OfType<Cliente>().ToList();
            var ClienteSearched = lst.Where(l => l.Cliente1.Contains(SearchBar.Text));
            ListaClientes.ItemsSource = ClienteSearched;
        }
        
        private void crearClicked(object sender, EventArgs e)
        {
            ClientsPage myHomePage = new ClientsPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        
    }
}