using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{
    public class Equipo
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public string NombreCompleto;


        public Equipo(long id, string nombre)
        {
            this.id = id;
            this.Nombre = nombre;
        }
        public Equipo(string nombre)
        {
            this.Nombre = nombre;
        }
        public Equipo() { }
    }
}
