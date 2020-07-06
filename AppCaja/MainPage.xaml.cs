using Acr.UserDialogs;
using AppCaja.Conexiones;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppCaja
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : CarouselPage
    {
        Articulo[] Lista;
        Cliente[] Listados;
        Descuento[] Listatres;
        string valorind;
        string montoind;
        double totalsum;
        decimal totalbd;
        double totalfinal;
        bool detectaopreacion = true;
        int N;
        string D;
        string M;
        string VENTA;
        string FECHA;
        IUserDialogs Dialogs = UserDialogs.Instance;
        public MainPage()
        {
            InitializeComponent();
            Repositorio repo = new Repositorio();
            Articulo[] listaarticulo = repo.getArticulo();
            ListaArticulos.ItemsSource = listaarticulo;
            Lista = listaarticulo;
            Cliente[] listacliente = repo.getCliente();
            ListaClientes.ItemsSource = listacliente;
            Listados = listacliente;
            Descuento[] listadescuento = repo.getDescuento();
            ListaDescuentos.ItemsSource = listadescuento;
            Listatres = listadescuento;

        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            Repositorio repo = new Repositorio();
            Articulo[] listaarticulo = repo.getArticulo();
            List<Articulo> lst = listaarticulo.OfType<Articulo>().ToList();
            var ArticuloSearched = lst.Where(l => l.Articulo1.Contains(SearchBar.Text));
            ListaArticulos.ItemsSource = ArticuloSearched;
        }
        void Handle_SearchButtonPresseddos(object sender, System.EventArgs e)
        {
            Repositorio repo = new Repositorio();
            Cliente[] listacliente = repo.getCliente();
            List<Cliente> lst = listacliente.OfType<Cliente>().ToList();
            var ArticuloSearched = lst.Where(l => l.Cliente1.Contains(SearchBar2.Text));
            ListaClientes.ItemsSource = ArticuloSearched;
        }
        void Handle_SearchButtonPressedtres(object sender, System.EventArgs e)
        {
            Repositorio repo = new Repositorio();
            Descuento[] listadescuento = repo.getDescuento();
            List<Descuento> lst = listadescuento.OfType<Descuento>().ToList();
            var DescuentoSearched = lst.Where(l => l.Descuento1.Contains(SearchBar3.Text));
            ListaDescuentos.ItemsSource = DescuentoSearched;
        }
        protected override void OnAppearing()
        {

            if (montoind != "0")
            {
                indicador.Text = valorind;
                total.Text = "Cobrar $a " + montoind + "";
                indicadordos.Text = valorind;
                totaldos.Text = "Cobrar $a " + montoind + "";
                indicadortres.Text = valorind;
                totaltres.Text = "Cobrar $a " + montoind + "";
                totalcuatro.Text = "" + montoind + "";
            }
            else
            {
                montoind = "0";
                valorind = "NINGUNA VENTA";
                indicador.Text = valorind;
                indicadordos.Text = valorind;
                indicadortres.Text = valorind;
                monto.Text = "" + montoind + "";
            }

        }
        public void ceroClicked(object sender, EventArgs e)
        {
            if (monto.Text == "0")
            {
                return;

            }
            else
            {
                monto.Text = monto.Text + "0";
            }

        }
        public void unoClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "1";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "1";
            }
        }
        public void dosClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "2";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "2";
            }
        }
        public void tresClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "3";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "3";
            }
        }
        public void cuatroClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "4";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "4";
            }
        }
        public void cincoClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "5";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "5";
            }
        }
        public void seisClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "6";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "6";
            }
        }
        public void sieteClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "7";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "7";
            }
        }
        public void ochoClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "8";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "8";
            }
        }
        public void nueveClicked(object sender, EventArgs e)
        {
            if (detectaopreacion)
            {
                monto.Text = "";
                monto.Text = "9";
                detectaopreacion = false;

            }
            else
            {
                monto.Text = monto.Text + "9";
            }
        }
        private ObservableCollection<Linea> _linea;
        public ObservableCollection<Linea> Lineas
        {
            get
            {
                return _linea ?? (_linea = new ObservableCollection<Linea>());
            }
        }
        private void masClicked(object sender, EventArgs e)
        {



            detectaopreacion = true;
            totalsum = double.Parse(monto.Text);
            totalbd = decimal.Parse(monto.Text);
            totalfinal = totalfinal + totalsum;
            montoind = totalfinal.ToString();
            total.Text = "Cobrar $a " + montoind + "";
            totaldos.Text = "Cobrar $a " + montoind + "";
            totaltres.Text = "Cobrar $a " + montoind + "";
            totalcuatro.Text = "" + montoind + "";
            monto.Text = "0";
            N = N + 1;
            M = N.ToString();
            valorind = "VENTA EN CURSO " + M + "";
            indicador.Text = valorind;
            indicadordos.Text = valorind;
            indicadortres.Text = valorind;
            var linea = new Linea()
            {
                Renglon = M,
                Nota = nota.Text,
                Precio = totalsum.ToString()
            };
            Lineas.Add(linea);
            Factura.ItemsSource = Lineas;
            FacturaFinal.ItemsSource = Lineas;
            Repositorio repositorio = new Repositorio();
            if (N == 1)
            {
                Cabecera cabecera = new Cabecera();
                cabecera.Venta = DateTime.Now.Ticks.ToString();
                VENTA = cabecera.Venta;
                cabecera.Fecha = DateTime.Now;
                FECHA = DateTime.Now.ToString();
                try
                {

                    Cabecera cabecerar = repositorio.postCabecera(cabecera).Result;

                }
                catch
                {
                }
            }
            Lineas lineas = new Lineas();
            lineas.Renglon = N;
            lineas.Articulo = nota.Text;
            lineas.Precio = Decimal.Parse(totalsum.ToString());
            lineas.Cantidad = 1;
            lineas.Venta = VENTA;
            try
            {

                Lineas lienar = repositorio.postLinea(lineas).Result;
                nota.Text = "";
            }
            catch
            {
            }
        }
        private void cClicked(object sender, EventArgs e)
        {
            montoind = "0";
            monto.Text = "" + montoind + "";
        }
        private void ventaClicked(object sender, EventArgs e)
        {
            CurrentPage = venta;
        }
        private void tecladoClicked(object sender, EventArgs e)
        {
            CurrentPage = teclado;
        }
        private void libreriaClicked(object sender, EventArgs e)
        {
            CurrentPage = libreria;
        }
        private void CobrarClicked(object sender, EventArgs e)
        {
            fechafactura.Text = FECHA;
            CurrentPage = Subtotal;
        }
        private void ClienteClicked(object sender, EventArgs e)
        {
            CurrentPage = clientes;
        }
        private void DescuentoClicked(object sender, EventArgs e)
        {
            CurrentPage = descuentospage;
        }
        private void menuClicked(object sender, EventArgs e)
        {
            MenuPage myHomePage = new MenuPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private void crearClicked(object sender, EventArgs e)
        {
            CrearArticuloPage myHomePage = new CrearArticuloPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);
        }
        private void EventClicked(object s, SelectedItemChangedEventArgs e)
        {
            var obj = (Articulo)e.SelectedItem;
            string id = obj.SKU;
            decimal? precio = obj.Precio;
            string articulo = obj.Articulo1;
            detectaopreacion = true;
            totalsum = double.Parse(precio.ToString());
            totalfinal = totalfinal + totalsum;
            montoind = totalfinal.ToString();
            total.Text = "Cobrar $a " + montoind + "";
            totaldos.Text = "Cobrar $a " + montoind + "";
            totaltres.Text = "Cobrar $a " + montoind + "";
            totalcuatro.Text = "" + montoind + "";
            monto.Text = "0";
            N = N + 1;
            M = N.ToString();
            valorind = "VENTA EN CURSO " + M + "";
            indicador.Text = valorind;
            indicadordos.Text = valorind;
            indicadortres.Text = valorind;
            var linea = new Linea()
            {
                Renglon = M,
                Nota = articulo,
                Precio = totalsum.ToString()
            };
            Lineas.Add(linea);
            Factura.ItemsSource = Lineas;
            Repositorio repositorio = new Repositorio();
            if (N == 1)
            {
                Cabecera cabecera = new Cabecera();
                cabecera.Venta = DateTime.Now.Ticks.ToString();
                VENTA = cabecera.Venta;
                cabecera.Fecha = DateTime.Now;
                FECHA = DateTime.Now.ToString();
                try
                {

                    Cabecera cabecerar = repositorio.postCabecera(cabecera).Result;
                }
                catch
                {
                }
            }
            Lineas lineas = new Lineas();
            lineas.Renglon = N;
            lineas.Articulo = articulo;
            lineas.Precio = Decimal.Parse(totalsum.ToString());
            lineas.Cantidad = 1;
            lineas.Venta = VENTA;
            try
            {

                Lineas lienar = repositorio.postLinea(lineas).Result;
            }
            catch
            {
            }
        }
        private void EventdosClicked(object s, SelectedItemChangedEventArgs e)
        {
            var obj = (Cliente)e.SelectedItem;
            string id = obj.Cliente1;
            clientefactura.Text = id;            
            CurrentPage = Subtotal;

        }
        private void EventtresClicked(object s, SelectedItemChangedEventArgs e)
        {            
            var obj = (Descuento)e.SelectedItem;
            double descuento = Double.Parse(obj.Porcentaje.ToString());            
            double totalprecio = Double.Parse(montoind);
            double preciofinal = totalprecio * ((100 - descuento)/100);
            totalcinco.Text = preciofinal.ToString();
            D = obj.Descuento1;            
            CurrentPage = Subtotal;
        }
        private async void mercadopagoClicked(object sender, EventArgs e)
        {
            Repositorio repositorio = new Repositorio();
            Cabecera cabecera = new Cabecera();
            cabecera.Cliente = clientefactura.Text;
            cabecera.Venta = VENTA;
            cabecera.Fecha = DateTime.Parse(FECHA);
            Decimal subtotal = Decimal.Parse(totalcuatro.Text);
            cabecera.Subtotal = subtotal;
            Decimal total = Decimal.Parse(totalcinco.Text);
            cabecera.Total = total;
            cabecera.Descuento = D;
            Cabecera cabecerar = repositorio.putCabecera(cabecera).Result;            
            Dialogs.ShowLoading("VENTA EXITOSA"); 
            await Task.Delay(2000);
            Dialogs.HideLoading();
            
        }
        private async void efectivoClicked(object sender, EventArgs e)
        {
            Repositorio repositorio = new Repositorio();
            Cabecera cabecera = new Cabecera();
            cabecera.Cliente = clientefactura.Text;
            cabecera.Venta = VENTA;
            cabecera.Fecha = DateTime.Parse(FECHA);
            Decimal subtotal = Decimal.Parse(totalcuatro.Text);
            cabecera.Subtotal = subtotal;
            Decimal total = Decimal.Parse(totalcinco.Text);
            cabecera.Total = total;
            cabecera.Descuento = D;            
            Cabecera cabecerar = repositorio.putCabecera(cabecera).Result;            
            Dialogs.ShowLoading("VENTA EXITOSA"); 
            await Task.Delay(2000);
            Dialogs.HideLoading();
        }
    }
   
}
