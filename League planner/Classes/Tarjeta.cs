using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{
    public class Tarjeta
    {
        public int Jugador { get; set; }
        public string Tipo { get; set; }
        public int Partido {get;set;}
        public int id { get; set; }

        public Tarjeta(int jugador, string tipo, int partido)
        {
            Jugador = jugador;
            Tipo = tipo;
            Partido = partido;
        }

        public string desc
        {
            get
            {

                string jugador = App.JugadorController.GetPlayer(Jugador)[0].NombreCompleto;
                return "Tarjeta " + Tipo +": "+ jugador;
            }


        }

       
    }
}
