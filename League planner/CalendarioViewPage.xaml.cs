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
    /// Lógica de interacción para CalendarioViewPage.xaml
    /// </summary>
    public partial class CalendarioViewPage : Page
    {
        private Page previous;
        public CalendarioViewPage(Page prev)
        {
            previous = prev;
            InitializeComponent();

            List<Calendario> partidos = App.CalendarioController.GetAll();
            List<PartidoShow> p_show = new List<PartidoShow>();

            foreach (Calendario partido in partidos)
            {
                PartidoShow p = new PartidoShow();
                p.Dia = partido.fecha.Day.ToString();
                p.Mes = partido.fecha.Month.ToString();
                p.Año = partido.fecha.Year.ToString();
                p.Hora = partido.fecha.Hour.ToString()+" : "+partido.fecha.Minute +"Hrs";
                p.Local = partido.local;
                p.Visitante = partido.visitante;

                p_show.Add(p);
                
                

            }


            tabla.ItemsSource = p_show;


        }

        internal class PartidoShow
        {
            public string Dia { get; set; }
            public string Mes { get; set; }
            public string Año { get; set; }
            public string Hora { get; set; }
            public string Local { get; set; }
            public string Visitante { get; set; }
            

            public PartidoShow()
            {

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
