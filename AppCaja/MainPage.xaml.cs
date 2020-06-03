using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCaja
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : CarouselPage
    {
        string valorind;
        string montoind;
        double totalsum;
        decimal totalbd;
        double totalfinal;
        bool detectaopreacion = true;
        int N;
        string M;

        public MainPage()
        {
            InitializeComponent();
            

        }
        protected override void OnAppearing()
        {
            montoind = "0";
            valorind = "NINGUNA VENTA";
            indicador.Text = valorind;
            total.Text = "Cobrar $a "+montoind+"";
            monto.Text = "" + montoind + "";
            indicadordos.Text = valorind;
            totaldos.Text = "Cobrar $a " + montoind + "";
            indicadortres.Text = valorind;
            totaltres.Text = "Cobrar $a " + montoind + "";
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
            monto.Text = "0";
            N = N + 1;
            M = N.ToString();
            valorind = "VENTA EN CURSO "+M+"";
            indicador.Text = valorind;
            indicadordos.Text = valorind;
            var linea = new Linea()
            {
                Renglon = M,
                Nota = nota.Text,
                Precio = totalsum.ToString()
            };
            Lineas.Add(linea);
            Factura.ItemsSource = Lineas;
            Lineas lineas = new Lineas()
            {
                Articulo = nota.Text,
                Precio = totalbd,
                Venta = "op123",
                Renglon = N,
                Cantidad = N,
            };

            //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            //conn.CreateTable<Lineas>();
            //int rows = conn.Insert(linea);
            //conn.Close();

            //if (rows > 0)
            //    DisplayAlert("Success", "Experience succesfully inserter", "Ok");
            //else
            //    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");



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


    }
   
}
