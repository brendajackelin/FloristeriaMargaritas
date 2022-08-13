using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    public class Persistencia
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
