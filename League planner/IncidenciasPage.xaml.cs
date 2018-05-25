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
        List<Equipo> equipos = new List<Equipo>();
        List<Calendario> cals = new List<Calendario>();
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
        }

        private void Eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Eventos.SelectedItem != null)
            {
                Calendario evento = (Eventos.SelectedItem as Calendario);
                local.Content = evento.local;
                visitante.Content = evento.visitante;

                equipos = App.EquipoController.GetAll();

                long idLocal = 0;
                int i, clave;
                for (i = 0; i < equipos.Count; i++)
                {
                    if (equipos[i].Nombre == local.Content.ToString())
                    {
                        idLocal = equipos[i].id;
                    }
                }
                //MessageBox.Show("id equipo -> " + idLocal);
                clave = Convert.ToInt32(idLocal);
                jugadorLocal.ItemsSource = App.JugadorController.GetAll();// GetPlayer(clave);
                jugadorVisitane.ItemsSource = App.JugadorController.GetAll();



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

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Calendario evento = (Eventos.SelectedItem as Calendario);
            int gLocal, gVisitante;
            if (Eventos.SelectedItem != null && jugadorLocal.SelectedItem != null && jugadorVisitane.SelectedItem != null && golLocal.Text != null && golVisitante.Text != null)
            {
                try{
                    gLocal = Convert.ToInt32(golLocal.Text);
                    gVisitante = Convert.ToInt32(golVisitante.Text);
                    
                }
                catch (Exception exception){

                    MessageBox.Show("Error I-02\nEscriba en los goles el formato correspondiente");
                }
                gol.clave_partido = Convert.ToInt32(evento.id);

            }
            else
            {
                MessageBox.Show("Error I-01\nComplete todos los campos");
            }
        }

  
    }
}
