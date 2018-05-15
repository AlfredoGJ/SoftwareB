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
    /// Lógica de interacción para EquipoEstadisticasPage.xaml
    /// </summary>
    public partial class EquipoEstadisticasPage : Page
    {
        private Page previous;
        public EquipoEstadisticasPage(Page prevPage)
        {
            previous = prevPage;
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released)
                Window.GetWindow(this).DragMove();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previous;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState= WindowState.Minimized;
        }
    }
}
