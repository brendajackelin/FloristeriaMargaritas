using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Essentials;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    class ApiUsuario
    {

        

        public class RestApiUsuario
        {
            public const String CrearUsuario = "https://johnlopezweb.com/Floristeria/CreateUsuario.php";
        }

        //METODO POST
        public async static Task CrearUsuario(Models.User usuario)
        {
            String json = JsonConvert.SerializeObject(usuario);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient cliente = new HttpClient())
            {
                //Crear el usuario en MySQL
                response = await cliente.PostAsync(Models.RestApiUsuario.POSTUsuarioList, content);
                
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sitio Guardado");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }

        private static readonly string URL_SITIOS = "https://johnlopezweb.com/Floristeria/";
        private static HttpClient client = new HttpClient();

        public static async Task<Models.User> GetUsuario(Models.User usuario)
        {
            List<Models.User> ListaUsuarios = new List<Models.User>();
            try
            {
                var uri = new Uri(URL_SITIOS + "ConsultaUsuario.php?nombre=" + usuario.nombre);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    ListaUsuarios = JsonConvert.DeserializeObject<List<Models.User>>(content);
                    return ListaUsuarios[0];
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ListaUsuarios[0];
        }


    }
}
