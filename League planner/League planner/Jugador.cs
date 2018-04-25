using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{
    public class Jugador
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get => Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } 

        public Jugador(long id, string nombre,string apellidoPaterno,string apellidoMaterno)
        {
            this.id = id;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
        }

        public Jugador(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
        }
        public Jugador()
        {
        }


    }
}
