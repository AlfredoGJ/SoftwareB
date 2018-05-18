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
    /// Lógica de interacción para CalendarioPage.xaml
    /// </summary>
    public partial class CalendarioPage : Page
    {
        Page previousPage;
        Calendario calendario;

        public Calendario Calendario{get; set;}
        public CalendarioPage(Calendario c, Page previous)
        {

            InitializeComponent();
            this.calendario = c;
            this.previousPage = previous;
            DataContext = calendario;  
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
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
        //Envia los datos capturados y los guarda en la base de datos
        private void button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            App.CalendarioController.Save(calendario);
            MessageBox.Show(calendario.id + calendario.dia + calendario.mes + calendario.local + calendario.visitante);
            Window.GetWindow(this).Content = previousPage;
        }
    }
}
