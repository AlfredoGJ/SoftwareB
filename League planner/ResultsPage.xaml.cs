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
    public partial class ResultsPage : Page
    {
        private Page previous;
        public ResultsPage(Page prev)
        {
            previous = prev;
            InitializeComponent();

            List<Result> resultados= new List<Result>() ;
            List<Calendario> partidos = App.CalendarioController.GetAll();
            List<Equipo> equipos = App.EquipoController.GetAll();
            long idVisitante = 0;
            long idLocal = 0;
            
           

            foreach (Calendario partido in partidos)
            {
                Result r = new Result();
                for (int i = 0; i < equipos.Count; i++)
                {
                    if (equipos[i].Nombre == partido.local)
                    {
                        idLocal = equipos[i].id;
                    }

                    if (equipos[i].Nombre == partido.visitante)
                    {
                        idVisitante = equipos[i].id;
                    }
                }

                r.Local = partido.local;
                r.Visitante = partido.visitante;
                r.GolesLocal = App.GolController.GetAll().FindAll(x => x.equipo == idLocal);
                r.GolesVisitante = App.GolController.GetAll().FindAll(x => x.equipo == idVisitante);
                r.GolesL = r.GolesLocal.Count;
                r.GolesV = r.GolesVisitante.Count;

                r.TarjetasLocal = App.TarjetaController.GetAll().FindAll(x=>x.equipo==idLocal);
                r.TarjetasVisitante = App.TarjetaController.GetAll().FindAll(x => x.equipo == idVisitante);



                resultados.Add(r);

            }
            










            tabla.ItemsSource = resultados;

        }


        internal class Result
        {
            public string Local { get; set; }
            public string Visitante { get; set; }
            public List<Gol> GolesLocal { get; set; }
            public List<Gol> GolesVisitante { get; set; }
            public List<Tarjeta> TarjetasLocal { get; set; }
            public List<Tarjeta> TarjetasVisitante { get; set; }
            public int GolesL { get; set; }
            public int GolesV { get; set; }
           
            public Result()
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
