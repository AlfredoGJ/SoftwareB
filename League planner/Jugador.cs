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
        public DateTime FechaDeNacimiento { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public int Equipo { get; set; }
        public bool Eliminado { get; set; }
        public string NombreCompleto;// { get => Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } 

        public Jugador(long id, string nombre,string apellidoPaterno,string apellidoMaterno,DateTime nacimiento,long tel,string mail, bool eliminado, int equipo)
        {
            this.id = id;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            FechaDeNacimiento = nacimiento;
            Telefono = tel;
            Email = mail;
            Equipo = equipo;
            Eliminado = eliminado;
        }

        public Jugador(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime nacimiento, long tel, string mail, bool eliminado, int equipo)
        {
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            FechaDeNacimiento = nacimiento;
            Telefono = tel;
            Email = mail;
            Equipo = equipo;
            Eliminado = eliminado;

        }
        public Jugador()
        {
        }


    }
}
