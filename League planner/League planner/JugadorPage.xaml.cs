using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace League_planner
{
    /// <summary>
    /// Lógica de interacción para JugadorPage.xaml
    /// </summary>
    public partial class JugadorPage : Page
    {
        Page previousPage;
        Jugador jugador;

        public Jugador Jugador{get; set;}

        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="j">Jugador que será editado</param>
        /// <param name="previous"> Pagina desde la cual se llama a esta página</param>
        public JugadorPage(Jugador j, Page previous)
        {
            
            InitializeComponent();
         
            this.jugador = j;
            this.previousPage = previous;

            DataContext = jugador;

           
        }


        /// <summary>
        /// Cancela la edicion y regresa a la página anterior
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>
        public void Cancelar(object sender, EventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
        }


        /// <summary>
        /// Acepta los cambios realizados en el jugador, ya sea nuevo o editado y lo inserta o actualiza en la base de datos
        /// siempre y cuando se proporcionen los datos necesarios, en caso de ser así regresa a la pagina anterior 
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>
        public void Aceptar(object sender, EventArgs e)
        {
            if (nombre != null && paterno != null && materno != null)
            {

                
                App.JugadorController.Save(jugador);
                Window.GetWindow(this).Content = previousPage;

            }
            else
                MessageBox.Show("Complete todos los campos para el alumno");
        }
    }
}
