using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace AppCaja
{
    public class Datos
    {
    }
    public  class Articulo
    {
        public int Row { get; set; }
        [PrimaryKey]
        public string SKU { get; set; }
        public string Unidad { get; set; }
        public string Categoria { get; set; }
        public Nullable<double> Existencia { get; set; }
        [JsonProperty("Precio")]
        public Nullable<decimal> Precio { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        [JsonProperty("Articulo1")]
        public string Articulo1 { get; set; }
        public string Descripcion { get; set; }
    }
    public  class Cabecera
    {
        [PrimaryKey]
        public string Venta { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Cliente { get; set; }
        public int Row { get; set; }
        public string Descuento { get; set; }
    }
    public  class Categoria
    {
        [PrimaryKey]
        public string Categoria1 { get; set; }
        public int Row { get; set; }
    }
    public class Cliente
    {
        [JsonProperty("Cliente1")]
        public string Cliente1 { get; set; }
        [PrimaryKey]
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Hab { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public Nullable<int> Zip { get; set; }
        public int Row { get; set; }
        public string Celular { get; set; }
        public string ID { get; set; }
    }
    public class Descuento
    {
        [PrimaryKey]
        public string Descuento1 { get; set; }
        public Nullable<double> Porcentaje { get; set; }
        public int Row { get; set; }
    }
    public class Lineas
    {
        public string Venta { get; set; }
        public string Articulo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<int> Renglon { get; set; }
        [PrimaryKey, AutoIncrement]
        public int Row { get; set; }
    }
}
