using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppCaja.Conexiones
{
    class Repositorio
    {
        
        public Cliente[] getCliente()
        {
            try
            {
                Cliente[] cliente;
                var URLWebAPI = "https://www.caja.somee.com/api/Clientes";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    cliente = Newtonsoft.Json.JsonConvert.DeserializeObject<Cliente[]>(JSON.Result);
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Descuento[] getDescuento()
        {
            try
            {
                Descuento[] descuento;
                var URLWebAPI = "https://www.caja.somee.com/api/Descuentoes";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    descuento = Newtonsoft.Json.JsonConvert.DeserializeObject<Descuento[]>(JSON.Result);
                }

                return descuento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Articulo[] getArticulo()
        {
            try
            {
                Articulo[] articulo;
                var URLWebAPI = "https://www.caja.somee.com/api/Articuloes";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    articulo = Newtonsoft.Json.JsonConvert.DeserializeObject<Articulo[]>(JSON.Result);
                }

                return articulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Cliente> postCliente(Cliente cliente)
        {
            Cliente clienter = new Cliente();
            clienter.Cliente1 = cliente.Cliente1;
            clienter.Correo = cliente.Correo;
            clienter.Telefono = cliente.Telefono;
            clienter.Calle = cliente.Calle;
            clienter.Hab = cliente.Hab;
            clienter.Ciudad = cliente.Ciudad;
            clienter.Estado = cliente.Estado;
            clienter.Zip = cliente.Zip;
            clienter.Celular = cliente.Celular;
            clienter.ID = System.Guid.NewGuid().ToString();
            var jsonObj = JsonConvert.SerializeObject(clienter);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://www.caja.somee.com/api/Clientes"),
                    Method = HttpMethod.Post,
                    Content = content
                };                
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Cliente result = JsonConvert.DeserializeObject<Cliente>(dataResult);
                return result;
            }
        }
        public async Task<Articulo> postArticulo(Articulo articulo)
        {
            Articulo articulor = new Articulo();
            articulor.SKU = articulo.SKU;
            articulor.Unidad = articulo.Unidad;
            articulor.Categoria = articulo.Categoria;
            articulor.Precio = articulo.Precio;
            articulor.FechaCreacion = DateTime.Now;
            articulor.Articulo1 = articulo.Articulo1;
            articulor.Descripcion = articulo.Descripcion;
            articulor.Existencia = articulo.Existencia;
            var jsonObj = JsonConvert.SerializeObject(articulor);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://www.caja.somee.com/api/Articuloes"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Articulo result = JsonConvert.DeserializeObject<Articulo>(dataResult);
                return result;
            }
        }
        public Categoria[] getCategoria()
        {
            try
            {
                Categoria[] categoria;
                var URLWebAPI = "https://caja.somee.com/api/Categorias";
                using (var Client = new System.Net.Http.HttpClient())
                {
                    var JSON = Client.GetStringAsync(URLWebAPI);
                    categoria = Newtonsoft.Json.JsonConvert.DeserializeObject<Categoria[]>(JSON.Result);
                }

                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Categoria> postCategoria(Categoria categoria)
        {
            Categoria categoriar = new Categoria();
            categoriar.Categoria1 = categoria.Categoria1;
            var jsonObj = JsonConvert.SerializeObject(categoriar);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://www.caja.somee.com/api/Categorias"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Categoria result = JsonConvert.DeserializeObject<Categoria>(dataResult);
                return result;
            }
        }
        public async Task<Descuento> postDescuento(Descuento descuento)
        {
            Descuento descuentor = new Descuento();
            descuentor.Descuento1 = descuento.Descuento1;
            descuentor.Porcentaje = descuento.Porcentaje;
            var jsonObj = JsonConvert.SerializeObject(descuentor);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://www.caja.somee.com/api/Descuentoes"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Descuento result = JsonConvert.DeserializeObject<Descuento>(dataResult);
                return result;
            }
        } 
        public async Task<Lineas> postLinea(Lineas linea)
        {
            Lineas linear = new Lineas();
            linear.Articulo = linea.Articulo;
            linear.Cantidad = linea.Cantidad;
            linear.Precio = linea.Precio;
            linear.Renglon = linea.Renglon;
            linear.Venta = linea.Venta;
            var jsonObj = JsonConvert.SerializeObject(linear);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://caja.somee.com/api/Lineas"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Lineas result = JsonConvert.DeserializeObject<Lineas>(dataResult);
                return result;
            }
        }
        public async Task<Cabecera> postCabecera(Cabecera cabecera)
        {
            Cabecera cabecerar = new Cabecera();
            cabecerar.Cliente = cabecera.Cliente;
            cabecerar.Venta = cabecera.Venta;
            cabecerar.Fecha = cabecera.Fecha;
            cabecerar.Descuento = cabecera.Descuento;
            cabecerar.Subtotal = cabecera.Subtotal;
            cabecerar.Total = cabecera.Total;
            var jsonObj = JsonConvert.SerializeObject(cabecerar);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://caja.somee.com/api/Cabeceras"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Cabecera result = JsonConvert.DeserializeObject<Cabecera>(dataResult);
                return result;
            }
        }
        public async Task<Cabecera> putCabecera(Cabecera cabecera)
        {

            string iD = cabecera.Venta;
            Cabecera cabecerar = new Cabecera();
            cabecerar.Cliente = cabecera.Cliente;
            cabecerar.Venta = cabecera.Venta;
            cabecerar.Fecha = cabecera.Fecha;
            cabecerar.Descuento = cabecera.Descuento;
            cabecerar.Subtotal = cabecera.Subtotal;
            cabecerar.Total = cabecera.Total;
            var jsonObj = JsonConvert.SerializeObject(cabecerar);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://caja.somee.com/api/Cabeceras/"+iD+""),
                    Method = HttpMethod.Put,
                    Content = content
                };
                var response = await client.SendAsync(request).ConfigureAwait(false);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Cabecera result = cabecerar;                
                return result;
            }
        }
    }
}
