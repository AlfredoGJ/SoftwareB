using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*********************************************************
 *	Proyecto:		League Planner
 *	Integrantes:	Granja Jalomo, Hernández Alonso
 *	 
 *
 *
 *********************************************************/

namespace League_Planner
{
    public partial class Form1 : Form
    {
    	//Declaración de variables

    	private string usuario;
    	private string contraseña;
    	private Principal principal;

        public Form1()
        {
            InitializeComponent();

            usuario = "Administrador";
            contraseña = "holamundo";
        }

        //Metodo que permite mover la ventana con el mouse dando clic 
        

        // Clic en el boton "Iniciar Sesion"
        private void iniciaSesion_Click(object sender, EventArgs e)
        {
        	if(textBox1.Text == usuario || textBox2.Text == contraseña){
        		principal = new Principal(usuario);
        		principal.Show();
               
        	}
        	else{
        		MessageBox.Show("Error: \n nombre de usuario o contraseña incorrectas");
        	}

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
