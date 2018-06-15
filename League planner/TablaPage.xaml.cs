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

            List<Equipo> equipos = App.EquipoController.GetAll();
            List<Eq> eq_show = new List<Eq>() ;
            List<Calendario> partidos = App.CalendarioController.GetAll().FindAll(x=>x.ganador!=0);
            List<Gol> goles = App.GolController.GetAll();

            foreach (Equipo E in equipos)
            {
                Eq eq = new Eq();
                List<Gol> myGoles = goles.FindAll(x=>x.equipo== E.id);
                List<Calendario> myMatches = partidos.FindAll(X => X.local == E.Nombre || X.visitante == E.Nombre);
                List<Gol> golesOnMyP = new List<Gol>();

                foreach (Calendario partido in myMatches)
                {
                    golesOnMyP.AddRange(goles.FindAll(z=> z.clave_partido==partido.id ));
                }
                
                eq.Nombre = E.Nombre;
                eq.PartidosJ = myMatches.Count;
                eq.PartidosG = myMatches.FindAll(x => x.ganador == E.id).Count;
                eq.PartidosE = myMatches.FindAll(x => x.ganador == -1).Count;
                eq.PartidosP = eq.PartidosJ - eq.PartidosE - eq.PartidosG;

                eq.Puntos = eq.PartidosG * 3 + eq.PartidosE;
                eq.Golesf = myGoles.Count;
                eq.Golesc = golesOnMyP.FindAll(x => x.equipo != E.id).Count;
                eq.Diferencia = eq.Golesf - eq.Golesc;

                eq_show.Add(eq);



            }

            IEnumerable<Eq> eordered=  eq_show.OrderByDescending(z => z.Puntos);

            int i = 1;
            foreach (Eq equipo in eordered)
            {
                equipo.Pos = i;
                i++;
            }


            tabla.ItemsSource = eq_show;

            
        }


        internal class Eq
        {
            public int Pos { get; set; }
            public String Nombre { get; set; }
            public int Puntos { get; set; }
            public int Diferencia { get; set; }
            public int Golesf { get; set; }
            public int Golesc { get; set; }
            public int PartidosJ{ get; set; }
            public int PartidosG { get; set; }
            public int PartidosE { get; set; }
            public int PartidosP { get; set; }



            public Eq(string name,int puntos, int dif)
            {
                Nombre = name;
                Puntos = puntos;
                Diferencia = dif;
            }
            public Eq()
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
