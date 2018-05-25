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
    /// Lógica de interacción para EquipoPage.xaml
    /// </summary>
    public partial class EquipoPage : Page
    {
        Page previousPage;
        Equipo equipo;
        public Equipo Equipo { get; set; }

        public EquipoPage(Equipo e, Page previous)
        {
            InitializeComponent();
            this.equipo = e;
            this.previousPage = previous;

            DataContext = equipo;
        }
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
            if (nombre.Text != null  && nombre.Text != "")
            {
                equipo.Nombre = nombre.Text;
                App.EquipoController.Save(equipo);
                Window.GetWindow(this).Content = previousPage;

            }
            else
                MessageBox.Show("Error E-01\nComplete el campo nombre para el equipo");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

    }
}
