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
    /// Lógica de interacción para IncidenciasCatalogo.xaml
    /// </summary>
    public partial class IncidenciasCatalogo : Page
    {
        Page previousPage;
        Gol gol;

        public IncidenciasCatalogo(Page previous, Gol gol)
        {
            this.previousPage = previous;
            this.gol = gol;
            InitializeComponent();
        }
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

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new IncidenciasPage(this,new Gol());
        }

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
           //     golLocal.Content = gol.gol;

            }
        }
    }
}
