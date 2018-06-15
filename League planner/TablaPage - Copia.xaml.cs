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
    public partial class GoleoPage : Page
    {
        private Page previous;
        public GoleoPage(Page prev)
        {
            previous = prev;
            InitializeComponent();

            List<Jugador> jugadores = App.JugadorController.GetAll();
            List<Gol> goles = App.GolController.GetAll();
            List<Equipo> equipos = App.EquipoController.GetAll();
            List<JugShow> jugShowList = new List<JugShow>();

            foreach (Jugador jugador in jugadores)
            {
                JugShow  jug = new JugShow();
                jug.Goles = goles.FindAll(x => x.clave_jugador == jugador.id).Count;
                jug.Nombre = jugador.Nombre+ " "+jugador.ApellidoPaterno+" "+jugador.ApellidoMaterno;
                jug.Equipo = equipos.Find(x => x.id == jugador.Equipo).Nombre;
                jugShowList.Add(jug);
            }

             IEnumerable<JugShow>  jordered = jugShowList.OrderByDescending(x => x.Goles);

            int i = 1;
            foreach(JugShow j in jordered) 
            {
                j.Pos = i;
                i++;
            }
             tabla.ItemsSource = jordered;

          

           
           
            
        }


        internal class JugShow
        {
            public String Nombre { get; set; }
            public string Equipo { get; set; }
            public int Goles { get; set; }
            public int Pos { get; set; }

            public JugShow(string name,string equipo, int goles)
            {
                Nombre = name;
                this.Equipo = equipo;
                this.Goles = goles;
            }
            public JugShow()
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
