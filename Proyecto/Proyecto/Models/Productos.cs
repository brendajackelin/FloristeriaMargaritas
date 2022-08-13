using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Newtonsoft.Json;

namespace Proyecto.Models
{
    public class Productos
    {
        public string idProducto { get; set; }
        public string productName { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        //public string imagenProducto { get; set; }
    }

}
