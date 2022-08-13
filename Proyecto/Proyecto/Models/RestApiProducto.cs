using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{

    public static class UrlApiProducto
    {
        public static string ip = "johnlopezweb.com";
        public static string web = "Floristeria";


        //Apis clase sitios
        public static string getEndPoint = "ListaProducto.php"; //GET

    }

    public static class RestApiProducto
    {
        public static string GETProductoList = string.Format("http://{0}/{1}/{2}", UrlApiProducto.ip, UrlApiProducto.web, UrlApiProducto.getEndPoint);

    }

    public class productos
    {
        public string idProducto { get; set; }
        public string productName { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        public string imagenProducto { get; set; }
    }

    public class ProductoRoot
    {
        public IList<productos> product { get; set; }
    }
}
