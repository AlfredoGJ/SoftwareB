using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_planner
{
    public class Gol
    {
        public long id { get; set; }
        public int clave_jugador { get; set; }
        public int clave_partido { get; set; }
        public int favor_o_contra { get; set; }
        

        public string desc
        {
            get
            {
                string jugador = App.JugadorController.GetPlayer(clave_jugador)[0].NombreCompleto;
                return "Gol: " + jugador;
            }
        }
        
        public Gol(long id, int clave_jugador, int clave_partido, int favor_o_contra)
        {
            this.id = id;
            this.clave_jugador = clave_jugador;
            this.clave_partido = clave_partido;
            this.favor_o_contra = favor_o_contra;
          

        }

        public Gol(int clave_jugador, int clave_partido, int favor_o_contra)
        {
            this.clave_jugador = clave_jugador;
            this.clave_partido = clave_partido;
            this.favor_o_contra = favor_o_contra;
            this.id = 0;
            
        }
        public Gol()
        { }
        

       
    }
}
