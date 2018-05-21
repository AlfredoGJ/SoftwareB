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
    /// Lógica de interacción para IncidenciasPage.xaml
    /// </summary>
    public partial class IncidenciasPage : Page
    {
        Page previousPage;
        Gol gol;
        public Gol Gol { get; set; }
        public IncidenciasPage(Page previous, Gol gol)
        {
            this.gol = gol;
            this.previousPage = previous;
            DataContext = gol;
            InitializeComponent();
        }
        /**********************************************************************************************************************************
         *                                  Metodos de botones de ventana
         **********************************************************************************************************************************/
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
        }
        /*********************************************************************************************************/

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Eventos.ItemsSource = App.CalendarioController.GetAll();
            jugadorLocal.ItemsSource = App.JugadorController.GetAll();
            jugadorVisitane.ItemsSource = App.JugadorController.GetAll();
        }

        private void Eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Eventos.SelectedItem != null)
            {
                Calendario evento = (Eventos.SelectedItem as Calendario);
                local.Content = evento.local;
                visitante.Content = evento.visitante;
            }
        }

        private void button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (golLocal != null && golVisitante != null)
            {
              
            }
        }

        private void jugadorLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(jugadorLocal.SelectedItem != null)
            {
                Jugador local = (jugadorLocal.SelectedItem as Jugador);
                gol.clave_jugador = Convert.ToInt32(local.id);
            }
        }

        private void jugadorVisitane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(jugadorVisitane.SelectedItem != null)
            {
                Jugador visitante = (jugadorVisitane.SelectedItem as Jugador);
                gol.clave_jugador = Convert.ToInt32(visitante.id);
            }
        }
    }
}
