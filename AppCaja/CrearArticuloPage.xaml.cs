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
    public partial class CrearArticuloPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public CrearArticuloPage()
        {
            InitializeComponent();
            Repositorio repo = new Repositorio();
            Categoria[] listacategoria = repo.getCategoria();            
            foreach (var item in listacategoria)
            {
                Categoria.Items.Add(item.Categoria1);                
            }

        }
        public async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        public async void Save_Clicked(object sender, EventArgs e)
        {
            Articulo articulor = new Articulo();
            articulor.SKU = SKU.Text;
            articulor.Unidad = Unidad.SelectedItem.ToString();
            articulor.Categoria = Categoria.SelectedItem.ToString();
            articulor.Precio = Decimal.Parse(Precio.Text);            
            articulor.Articulo1 = Nombre.Text;
            articulor.Descripcion = Descripcion.Text;
            articulor.Existencia = Double.Parse(Cantiad.Text);
            Repositorio repo = new Repositorio();
            try
            {

                Articulo articulo = repo.postArticulo(articulor).Result;
                Dialogs.ShowLoading("Articulo Registrado"); ;
                await Task.Delay(2000);
                Dialogs.HideLoading();
                ArtticuloPage myHomePage = new ArtticuloPage();
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