using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto.Models;
using System.Diagnostics;


namespace Proyecto.Controllers
{
    public class ApiProducto
    {
        /* public class RestApiProducto
         {
             public const String ObtenerProducto = "https://johnlopezweb.com/Floristeria/ListaProducto.php";
         }

         //METODO GET

         public async static Task<List<Models.productos>> GetListProducto()
         {
             List<Models.productos> listproduct = new List<Models.productos>();
             using (HttpClient client = new HttpClient())
             {
                 var response = await client.GetAsync(Models.RestApiProducto.GETProductoList);

                 if (response.IsSuccessStatusCode)
                 {
                     var JsonContent = response.Content.ReadAsStringAsync().Result;
                     var ProductDes = JsonConvert.DeserializeObject<Models.ProductoRoot>(JsonContent);
                     listproduct = ProductDes.product as List<Models.productos>;
                 }
             }
             return listproduct;
         }*/
        /*
        private static readonly string URL_SITIOS = "https://johnlopezweb.com/Floristeria/";
        private static HttpClient client = new HttpClient();


        public static async Task<List<Productos>> GetTransferencias()
        {
            List<Productos> transferencias = new List<Productos>();

            try
            {
                var uri = new Uri(URL_SITIOS + "ListaProducto.php");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    transferencias = JsonConvert.DeserializeObject<List<Productos>>(content);
                    return transferencias;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transferencias;
        }*/
        /*
        private static readonly string URL_SITIOS = "https://johnlopezweb.com/Floristeria/";
        private static HttpClient client = new HttpClient();

        public static async Task<Dictionary<string, Productos>> GetAllProductos()
        {
            Dictionary<string, Productos> oObject = new Dictionary<string, Productos>();
            try
            {
                var uri = new Uri(URL_SITIOS + "ListaProducto.php");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Productos>>(jsonstring);
                    }
                    return oObject;
                }
                else
                {
                    oObject = null;
                    return oObject;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                oObject = null;
                return oObject;
            }

        }
        /*
        public static async Task<Dictionary<string, Productos>> ObtenerProductos()
        {
            Dictionary<string, Productos> oObject = new Dictionary<string, Productos>();
            try
            {
                HttpClient client = new HttpClient();
                string apiurlformat = string.Concat(AppSettings.ApiFirebase, "dbalmacen/categoria/{0}/productos.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    if (jsonstring != "null")
                    {
                        oObject = JsonConvert.DeserializeObject<Dictionary<string, Productos>>(jsonstring);
                    }
                    return oObject;
                }
                else
                {
                    oObject = null;
                    return oObject;
                }
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                oObject = null;
                return oObject;
            }

        }*/

        public class RestApiProducto
        {
            public const String CrearSitio = "https://johnlopezweb.com/Floristeria/ListaProducto.php";
        }

        public async static Task<List<Models.productos>> GetListProducts()
        {
            List<Models.productos> listsitio = new List<Models.productos>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Models.RestApiProducto.GETProductoList);

                if (response.IsSuccessStatusCode)
                {
                    var JsonContent = response.Content.ReadAsStringAsync().Result;
                    var SitioDes = JsonConvert.DeserializeObject<Models.ProductoRoot>(JsonContent);
                    listsitio = SitioDes.product as List<Models.productos>;
                }
            }
            return listsitio;
        }

    }

}

