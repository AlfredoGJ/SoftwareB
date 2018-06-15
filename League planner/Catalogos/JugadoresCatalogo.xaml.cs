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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class JugadoresCatalogo : Page
    {
        Page previousPage;
        public JugadoresCatalogo(Page previous)
        {
            previousPage = previous;
            InitializeComponent();
           

        }


        /// <summary>
        /// Actualiza la vista de la lista de jugadores con de todos los registros
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>
        public void UpdateJugadores(object sender, RoutedEventArgs e)
        {
           
            listaJugadores.ItemsSource = App.JugadorController.GetAll();
        }

        /// <summary>
        /// Carga la pagina de edicion de jugador para agregar un nuevo
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void JugadorNuevo(object sender, RoutedEventArgs e)
        {
            JugadorPage jugadorPage = new JugadorPage(new Jugador(), this);
            Window.GetWindow(this).Content=jugadorPage;
            

        }

        /// <summary>
        /// Actualiza la vista de la lista de jugadores con los que coincidan con el texto de la caja de busqueda
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void SearchJugadores(object sender, RoutedEventArgs e)
        {
            listaJugadores.ItemsSource = App.JugadorController.search(searchboxjugadores.Text);
        }

        /// <summary>
        /// Vacia los datos del jugador seleccionado en la interfaz
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void SeleccionaJugador(object sender, SelectionChangedEventArgs e)
        {
            if (listaJugadores.SelectedItem != null)
            {
               
                    Jugador jugador = (listaJugadores.SelectedItem as Jugador);
                    id.Content = jugador.id.ToString();
                    nombre.Content = jugador.Nombre;
                    paterno.Content = jugador.ApellidoPaterno;
                    materno.Content = jugador.ApellidoMaterno;
                    DateTime nac = jugador.FechaDeNacimiento;
                    nacimiento.Content = nac.Day + "/" + nac.Month + "/" + nac.Year;
                    telefono.Content = jugador.Telefono;
                    email.Content = jugador.Email;
                    equipo.Content = App.EquipoController.GetAll().Find(x => x.id == jugador.Equipo).Nombre;
                
               
            }

        }


        /// <summary>
        /// Elimina El jugador actualmente seleccionado
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void EliminarJugador(object sender, RoutedEventArgs e)
        {
            if (listaJugadores.SelectedItem != null)
            {
                if (MessageBox.Show("Esta seguro que quiere eliminar Este Elemento?", "Confirmar eliminación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

                {
                    App.JugadorController.Delete((listaJugadores.SelectedItem as Jugador).id);
                    UpdateJugadores(sender, e);

                    // Se resetean los campos del jugador seleccionado eliminado
                    id.Content = "";
                    nombre.Content = "";
                    materno.Content = "";
                    paterno.Content = "";
                    nacimiento.Content = "";
                    telefono.Content = "";
                    email.Content = "";
                }

            }
        }

        /// <summary>
        /// Carga la pagina de edicion de jugador con los datos ddel jugador seleccionado para editarlos
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void EditarJugador(object sender, RoutedEventArgs e)
        {
            if (listaJugadores.SelectedItem != null)
            {

                Window.GetWindow(this).Content= new JugadorPage((Jugador)listaJugadores.SelectedItem, this);
                
            }

        }


        /// <summary>
        /// Actualiza la vista de la lista de jugadores con los que coincidan con el texto de la caja de busqueda cada que este cambia
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentos del evento (no controlado por el usuario)</param>
        private void BusquedaAlCambiarTexto(object sender, TextChangedEventArgs e)
        {
            
            listaJugadores.ItemsSource = App.JugadorController.search(searchboxjugadores.Text);
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
            Window.GetWindow(this).WindowState=WindowState.Minimized;
        }



        private void GoToFirst(object sender, RoutedEventArgs e)
        {
            listaJugadores.SelectedItem = listaJugadores.Items[0];
        }

        private void GoToPrevious(object sender, RoutedEventArgs e)
        {
            int index = listaJugadores.Items.IndexOf(listaJugadores.SelectedItem);
            if (index > 0)
                listaJugadores.SelectedItem = listaJugadores.Items[index - 1];
        }

        private void GoToNext(object sender, RoutedEventArgs e)
        {
            int index = listaJugadores.Items.IndexOf(listaJugadores.SelectedItem);
            if (index < listaJugadores.Items.Count-1)
                listaJugadores.SelectedItem = listaJugadores.Items[index + 1];
        }

        private void GoToLast(object sender, RoutedEventArgs e)
        {
            listaJugadores.SelectedItem = listaJugadores.Items[listaJugadores.Items.Count - 1];
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content= previousPage;
        }
    }
}


