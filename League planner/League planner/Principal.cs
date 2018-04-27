using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace League_planner
{
    public partial class Principal : Form
    {
       
        public Principal()
        {
            InitializeComponent();
        }
    
        /******************************************************************************************
         * Metodo encargado para entrar a la ventan del programa, en este boton entran todos los 
         * usuarios normales.
         * ***************************************************************************************/
        private void empieza(object sender, EventArgs e)
        {

            Interfaz i = new Interfaz();
            i.Show();
            Timer t = new Timer();
            t.Interval = 1000;
            t.Start();
            this.Close();
            this.Dispose();
            this.DestroyHandle();
            
           

        }

        private void abreCatalogo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            App.StablishConnection();
            MainWindow Content = new MainWindow(true);
            this.Close();

        }
    }
}
