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
    /// Lógica de interacción para TablaPage.xaml
    /// </summary>
    public partial class TablaPage : Page
    {
        private Page previous;
        public TablaPage(Page prev)
        {
            previous = prev;
            InitializeComponent();
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
            tabla.Items.Add(new Eq("Cuervos", 23, 8));
        }
        internal class Eq
        {
            public String Nombre { get; set; }
            public int Puntos { get; set; }
            public int Diferencia { get; set;}


            public Eq(string name,int puntos, int dif)
            {
                Nombre = name;
                Puntos = puntos;
                Diferencia = dif;
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previous;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released)
                Window.GetWindow(this).DragMove();
        }
    }
}
