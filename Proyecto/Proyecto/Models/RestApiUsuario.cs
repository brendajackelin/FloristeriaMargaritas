using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    
        public static class UrlApiUsuario
        {
            public static string ip = "johnlopezweb.com";
            public static string web = "Floristeria";


        //Apis clase sitios
            public static string getEndPoint = "listasitios.php"; //GET
            public static string postEndPoint = "CreateUsuario.php"; //POST
            public static string updateEndPoint = "actualizarsitio.php"; //UPDATE
            public static string deleteEndPoint = "eliminarsitio.php"; //DELETE

        }
    //SelectionChanged="CvListaProductos_SelectionChanged"
    public static class RestApiUsuario
        {
            public static string GETSitioList = string.Format("http://{0}/{1}/{2}", UrlApiUsuario.ip, UrlApiUsuario.web, UrlApiUsuario.getEndPoint);
            public static string POSTUsuarioList = string.Format("http://{0}/{1}/{2}", UrlApiUsuario.ip, UrlApiUsuario.web, UrlApiUsuario.postEndPoint);
            public static string UPDATESitioList = string.Format("http://{0}/{1}/{2}", UrlApiUsuario.ip, UrlApiUsuario.web, UrlApiUsuario.updateEndPoint);
            public static string DELETESitioList = string.Format("http://{0}/{1}/{2}", UrlApiUsuario.ip, UrlApiUsuario.web, UrlApiUsuario.deleteEndPoint);

        }

        public class Usuario
        {
            public string id { get; set; }
            public string correo { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string telefono { get; set; }
        }

        public class SitioRootUsuario
        {
            public IList<Usuario> user { get; set; }
        }
    
}
