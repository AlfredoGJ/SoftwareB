using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**********************************************************************************
 * Nombres: Granja Jalomo Alfredo, Hernández Alonso
 * Proyecto:  League Planner 1.0
 * Equipo: 8
 * Fecha: 02/ Marzo/ 2018
 * Funcionalidad: Programa que utiliza Access para la obtención y modificación
 *                de información de equipos de futbol soccer.
 *              
 * ********************************************************************************/

namespace league_planner
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /***********************************************************************
         * Metodo Load -> se encarga de obtener la información dada la base 
         * de datos, se adquiere al momento que carga el programa
         ************************************************************************/ 
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'leagueplannerDataSet.Goles' Puede moverla o quitarla según sea necesario.
            this.golesTableAdapter.Fill(this.leagueplannerDataSet.Goles);
            // TODO: esta línea de código carga datos en la tabla 'leagueplannerDataSet.Partidos' Puede moverla o quitarla según sea necesario.
            this.partidosTableAdapter.Fill(this.leagueplannerDataSet.Partidos);
            // TODO: esta línea de código carga datos en la tabla 'leagueplannerDataSet.Tarjetas' Puede moverla o quitarla según sea necesario.
            this.tarjetasTableAdapter.Fill(this.leagueplannerDataSet.Tarjetas);
            // TODO: esta línea de código carga datos en la tabla 'leagueplannerDataSet.Jugadores' Puede moverla o quitarla según sea necesario.
            this.jugadoresTableAdapter.Fill(this.leagueplannerDataSet.Jugadores);
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        // TextBox del ID
        private void button6_Click(object sender, EventArgs e)
        {
            jugadoresBindingSource.MoveFirst();
            int index = jugadoresBindingSource.Position;
          
           

        }
        //Clic en boton guardar donde añade un nuevo registro.
        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            this.jugadoresBindingSource.AddNew();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


 



    
    }


}