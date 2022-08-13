using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace Proyecto.Models
{
    public class User
    {
        [JsonProperty("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("apellido")]
        public string apellido { get; set; }

        [JsonProperty("correo")]
        public string correo { get; set; }

        [JsonProperty("telefono")]
        public string telefono { get; set; }
        
    }
}
