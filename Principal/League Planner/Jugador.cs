using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace League_Planner
{
    class Jugador
    {
        private string nombre;
        private int id;
        private int edad;
        private string domicilio;
        private string equipo;
        private string apodo;

        public Jugador()
        {

        }
        public Jugador(string nombre, int id, int edad, string dom, string equipo, string apodo)
        {
            this.nombre = nombre;
            this.id = id;
            this.edad = edad;
            this.domicilio = dom;
            this.equipo = equipo;
            this.apodo = apodo;
        }
        public string dameNombre()
        {
            return nombre;
        }
        public int dameId()
        {
            return id;
        }
        public int dameEdad()
        {
            return edad;
        }
        public string dameDomicilio()
        {
            return domicilio;
        }
        public string dameEquipo()
        {
            return equipo;
        }
        public string dameApodo(){
            return apodo;
        }
    }
}
