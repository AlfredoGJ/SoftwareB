using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{

    /// <summary>
    /// Clase que se encarga de guardar los datos de cada tarjeta tales como: id, clave del jugador sancionado, clave del partido en que fue sancionado, tipo de tarjeta y el equipo al que se cuenta la tarjeta. 
    /// </summary>
    public class Tarjeta
    {
        public int Jugador { get; set; }
        public string Tipo { get; set; }
        public int Partido {get;set;}
        public long id { get; set; }
        public int equipo { get; set; }

        public Tarjeta(int jugador, string tipo, int partido, int equipo)
        {
            Jugador = jugador;
            Tipo = tipo;
            Partido = partido;
            this.equipo = equipo;
        }

        public Tarjeta(long id, int jugador, string tipo, int partido, int equipo)
        {
            Jugador = jugador;
            Tipo = tipo;
            Partido = partido;
            this.equipo = equipo;
            this.id = id;
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
