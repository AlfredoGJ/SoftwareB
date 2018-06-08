using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************************************************************************
 * Clase Calendario
 * Se encarga de obtener la fecha y los equipos que estarán jugando en dicha fecha.
 *********************************************************************************************************************************/
namespace League_planner
{
    public class Calendario
    {
    	// Declaración de variables usando get's y set's
    	public long 	id{get;set;}
    	public int 		dia{get;set;}
    	public string 	mes{get;set;}
    	public string 	local{get;set;}
    	public string 	visitante{get;set;}
        public DateTime fecha { get; set; }

    	// Constructor con id 
    	public Calendario(long id, DateTime fecha, string local, string visitante)
    	{
    		this.id = id;
            this.fecha = fecha;
    		this.local = local;
    		this.visitante = visitante;
    	}

    	// Constructor sin id
    	public Calendario(DateTime fecha,string local, string visitante)
    	{
            this.fecha = fecha;
    		this.local = local;
    		this.visitante = visitante;
    	}
    	public Calendario(){}
    }
}
