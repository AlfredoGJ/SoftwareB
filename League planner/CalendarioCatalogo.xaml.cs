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
using System.Data.SQLite;
using System.IO;

namespace League_planner
{
    /// <summary>
    /// Lógica de interacción para CalendarioCatalogo.xaml
    /// </summary>
    public partial class CalendarioCatalogo : Page
    {
        Page previousPage;
        public CalendarioCatalogo(Page previous)
        {
            previousPage = previous;
            InitializeComponent();

            if (listaEventos.SelectedItem != null)
            {
                Calendario calendario = (listaEventos.SelectedItem as Calendario);
                dia.Content = calendario.dia;
                mes.Content = calendario.mes;
                local.Content = calendario.local;
                visitante.Content = calendario.visitante;
            }
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
           

            CalendarioPage calendarioPage = new CalendarioPage(new Calendario(), this);
            Window.GetWindow(this).Content = calendarioPage;
        }

        private void listaEventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
