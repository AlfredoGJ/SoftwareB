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

        List<object> incidenciasLocal = new List<object>();
        List<object> incidenciasVisitante = new List<object>();

        int golesLocal=0, golesVisitante=0;
        int IDVisitante;
        int IDLocal;

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
                ILocal.ItemsSource = null;
                IVisitante.ItemsSource = null;
                incidenciasLocal.Clear();
                incidenciasVisitante.Clear();
                Calendario evento = (Eventos.SelectedItem as Calendario);
                local.Content = evento.local;
                visitante.Content = evento.visitante;

                equipos = App.EquipoController.GetAll();


                long idVisitante = 0;
                long idLocal = 0;
                int i, clave;
                for (i = 0; i < equipos.Count; i++)
                {
                    if (equipos[i].Nombre == local.Content.ToString())
                    {
                        idLocal = equipos[i].id;
                    }

                    if (equipos[i].Nombre == visitante.Content.ToString())
                    {
                        idVisitante = equipos[i].id;
                    }
                }
                IDVisitante = (int)idVisitante;
                IDLocal = (int)idLocal;

                //MessageBox.Show("id equipo -> " + idLocal);
                clave = Convert.ToInt32(idLocal);
                jugadorLocal.ItemsSource = App.JugadorController.GetAll().FindAll(x => x.Equipo==idLocal);
                jugadorLocal_Copy.ItemsSource= App.JugadorController.GetAll().FindAll(x => x.Equipo == idLocal);
                jugadorVisitante.ItemsSource = App.JugadorController.GetAll().FindAll(x => x.Equipo==idVisitante);
                jugadorVisitante_Copy.ItemsSource= App.JugadorController.GetAll().FindAll(x => x.Equipo == idVisitante);

                
                List <Gol> goles=App.GolController.GetAll().FindAll(z => z.clave_partido == evento.id);
                List<Tarjeta> tarjetas = App.TarjetaController.GetAll().FindAll(t => t.Partido == evento.id);



                incidenciasLocal.AddRange( goles.FindAll(x => x.equipo == IDLocal));
                golesLocal = incidenciasLocal.Count;
                golesL.Content = golesLocal;
                incidenciasLocal.AddRange(tarjetas.FindAll(t=>t.equipo==IDLocal));

                incidenciasVisitante.AddRange(goles.FindAll(x => x.equipo == IDVisitante));
                golesVisitante = incidenciasVisitante.Count;
                golesV.Content = golesVisitante;
                incidenciasVisitante.AddRange(tarjetas.FindAll(x => x.equipo == IDVisitante));

                
                ILocal.ItemsSource = incidenciasLocal;
                IVisitante.ItemsSource = incidenciasVisitante;



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
            if(jugadorVisitante.SelectedItem != null)
            {
                Jugador visitante = (jugadorVisitante.SelectedItem as Jugador);
                gol.clave_jugador = Convert.ToInt32(visitante.id);
            }
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (object Incidencia in incidenciasLocal) 
            {
                if (Incidencia.GetType() == typeof(Gol))
                {

                    App.GolController.Save((Incidencia as Gol));
                }

                if (Incidencia.GetType() == typeof(Tarjeta))
                {

                    App.TarjetaController.Save((Incidencia as Tarjeta));
                }

            }

            foreach (object Incidencia in incidenciasVisitante)
            {
                if (Incidencia.GetType() == typeof(Gol))
                {

                    App.GolController.Save((Incidencia as Gol));
                }

                if (Incidencia.GetType() == typeof(Tarjeta))
                {

                    App.TarjetaController.Save((Incidencia as Tarjeta));
                }

            }

        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            
            Jugador j = (jugadorLocal.SelectedItem as Jugador);
            Calendario c = (Eventos.SelectedItem as Calendario);

            if (c != null)
            {
                if (j != null)
                {
                    Gol g = new Gol((int)j.id, (int)c.id, 0, IDLocal);
                    incidenciasLocal.Add(g);
                    ILocal.ItemsSource = null;
                    ILocal.ItemsSource = incidenciasLocal;
                    App.GolController.Save(g);
                    golesLocal++;
                    golesL.Content = golesLocal;
                    updateWinner();


                }

                else
                    MessageBox.Show("Seleccione un jugador para agregar un gol");
            }
            else
                MessageBox.Show("Debe seleccionar un partido para agregar incidencias");


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Jugador j = (jugadorLocal_Copy.SelectedItem as Jugador);
            Calendario c = (Eventos.SelectedItem as Calendario);


            if (c != null)
            {
                if (j != null)
                {
                    if (!String.IsNullOrEmpty(tipoTLocal.Text))
                    {
                        Tarjeta T = new Tarjeta((int)j.id, tipoTLocal.Text, (int)c.id,IDLocal);
                        incidenciasLocal.Add(T);
                        ILocal.ItemsSource = null;
                        ILocal.ItemsSource = incidenciasLocal;
                        App.TarjetaController.Save(T);
                    }
                    else
                        MessageBox.Show("Seleccione el tipo de tarjeta");

                }
                else
                    MessageBox.Show("Seleccione un jugador para agregar una tarjeta");
            }
            else
                MessageBox.Show("Debe seleccionar un partido para agregar incidencias");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Jugador j = (jugadorVisitante.SelectedItem as Jugador);
            Calendario c = (Eventos.SelectedItem as Calendario);

            if (c != null)
            {
                if (j != null)
                {
                    Gol G = new Gol((int)j.id, (int)c.id, 0,IDVisitante);
                    incidenciasVisitante.Add(G);
                    IVisitante.ItemsSource = null;
                    IVisitante.ItemsSource = incidenciasVisitante;
                    App.GolController.Save(G);
                    golesVisitante++;
                    golesV.Content = golesVisitante;
                    updateWinner();
                }
                else
                    MessageBox.Show("Seleccione un jugador para agregar un gol");
            }
            else
                MessageBox.Show("Debe seleccionar un partido para agregar incidencias");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Jugador j = (jugadorVisitante_Copy.SelectedItem as Jugador);
            Calendario c = (Eventos.SelectedItem as Calendario);


            if (c != null)
            {
                if (j != null)
                {
                    if (!String.IsNullOrEmpty(tipoTVisitante.Text))
                    {
                        Tarjeta T = new Tarjeta((int)j.id, tipoTVisitante.Text, (int)c.id,IDVisitante);
                        incidenciasVisitante.Add(T);
                        IVisitante.ItemsSource = null;
                        IVisitante.ItemsSource = incidenciasVisitante;
                        App.TarjetaController.Save(T);
                    }
                    else
                        MessageBox.Show("Seleccione el tipo de tarjeta");

                }
                else
                    MessageBox.Show("Seleccione un jugador para agregar una tarjeta");
            }
            else
                MessageBox.Show("Debe seleccionar un partido para agregar incidencias");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (IVisitante.SelectedItem != null)
            {

                if (MessageBox.Show("Esta seguro que quiere eliminar Este Elemento?", "Confirmar eliminación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

                {
                    if (IVisitante.SelectedItem.GetType() == typeof(Gol))
                    {
                        Gol g = (IVisitante.SelectedItem as Gol);
                        App.GolController.Delete(g);
                        golesVisitante--;
                        golesV.Content = golesVisitante;
                        updateWinner();
                    }

                    if (IVisitante.SelectedItem.GetType() == typeof(Tarjeta))
                    {
                        Tarjeta t = (IVisitante.SelectedItem as Tarjeta);
                        App.TarjetaController.Delete(t);
                    }

                    incidenciasVisitante.Remove(IVisitante.SelectedItem);
                    IVisitante.ItemsSource = null;
                    IVisitante.ItemsSource = incidenciasVisitante;

                }
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (ILocal.SelectedItem != null)
            {
                if (MessageBox.Show("Esta seguro que quiere eliminar Este Elemento?", "Confirmar eliminación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

                {
                    if (ILocal.SelectedItem.GetType() == typeof(Gol))
                    {
                        Gol g = (ILocal.SelectedItem as Gol);
                        App.GolController.Delete(g);
                        golesLocal--;
                        golesL.Content = golesLocal;
                        updateWinner();
                    }

                    if (ILocal.SelectedItem.GetType() == typeof(Tarjeta))
                    {
                        Tarjeta t = (ILocal.SelectedItem as Tarjeta);
                        App.TarjetaController.Delete(t);
                    }

                    incidenciasLocal.Remove(ILocal.SelectedItem);
                    ILocal.ItemsSource = null;
                    ILocal.ItemsSource = incidenciasLocal;
                }
                
            }
        }

        private void updateWinner()
        {

            Calendario evento = (Eventos.SelectedItem as Calendario);
            if (golesLocal > golesVisitante)   
                evento.ganador = IDLocal;
            else if (golesLocal < golesVisitante)
                evento.ganador = IDVisitante;
            else
                evento.ganador = -1;


            App.CalendarioController.Save(evento);

        }
    }
}
