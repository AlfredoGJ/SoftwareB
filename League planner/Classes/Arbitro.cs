using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{
    /// <summary>
    /// Clase Que sirve para guardar los datos de un jugador como: id, Nombre, apellido materno, apellido paterno, fecha de nacimiento, telefono y e-mail.
    /// </summary>
    public class Arbitro
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Equipo { get; set; }
        public bool Eliminado { get; set; }
        public string NombreCompleto { get => Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } 


        public Arbitro(long id, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime nacimiento,string tel)
        {
            this.id = id;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            FechaDeNacimiento = nacimiento;
            this.Telefono = tel;
                 
        }
        public Arbitro(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime nacimiento, string tel)
        {
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            FechaDeNacimiento = nacimiento;
            Telefono = tel;
            

        }
        public Arbitro() { }


    }
}

