using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace League_Planner
{
    public partial class Principal : Form
    {
    	private int posx,posy;
        private Jugador jugador;
        private List<Jugador> jug;

        private string nombre;
        private int id;
        private int edad;
        private string domicilio;
        private string equipo;
        private string apodo;
        private int i,j;
        public Principal(string nombre)
        {
            InitializeComponent();
            posx = 0;
            posy = 0;
            i = 0;
            nombreU.Text = nombre;
            jug = new List<Jugador>();
            
        }
        # region ventana
        //Metodo que permite mover la ventana con el mouse dando clic 
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        	if(e.Button != MouseButtons.Left){
        		posx = e.X;
        		posy = e.Y;
        	}
        	else{
        		Left = Left + (e.X - posx);
        		Top  = Top  + (e.Y - posy);
        	}
        }
        //Metodo que cierra la ventana
        private void cierrate(object sender, EventArgs e)
        {
            this.Close();   
        }
        //Metodo que minimiza la ventana
        private void minimizate(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion  

        private void agregaJugador(object sender, EventArgs e)
        {
            nombre = textBox1.Text;
            id = Convert.ToInt32(textBox2.Text);
            edad = Convert.ToInt32(textBox3.Text);
            domicilio = textBox4.Text;
            equipo = textBox5.Text;
            apodo = textBox6.Text;
            jugador = new Jugador(nombre, id, edad, domicilio, equipo, apodo);
            jug.Add(jugador);
            textBox7.Text = Convert.ToString(jug.Count);
            i = jug.Count;
        }
        private void imprimeCatalogo(List<Jugador> jug, int pos)
        {
            textBox1.Text = jug[pos].dameNombre();
            textBox2.Text = Convert.ToString(jug[pos].dameId());
            textBox3.Text = Convert.ToString(jug[pos].dameEdad());
            textBox4.Text = jug[pos].dameDomicilio();
            textBox5.Text = jug[pos].dameEquipo();
            textBox6.Text = jug[pos].dameApodo();
        }
        private void siguiente(object sender, EventArgs e)
        {
            if (i < jug.Count-1)
            {
                i++;
                imprimeCatalogo(jug, i);
                textBox8.Text = Convert.ToString(i) + "," + Convert.ToString(jug.Count-1);
            }
            
        }

        private void anterior(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                imprimeCatalogo(jug, i);
                textBox8.Text = Convert.ToString(i) + "," + Convert.ToString(jug.Count-1);
            }
        }

        private void primero(object sender, EventArgs e)
        {
            imprimeCatalogo(jug, 0);
            textBox8.Text = Convert.ToString(0) + "," + Convert.ToString(jug.Count-1);
        }

        private void ultimo(object sender, EventArgs e)
        {
            imprimeCatalogo(jug, jug.Count-1);
            textBox8.Text = Convert.ToString(jug.Count-1) + "," + Convert.ToString(jug.Count-1);
        }

        private void eliminaJugador(object sender, EventArgs e)
        {
            jug.RemoveAt(i);
            
        }
    }
}
