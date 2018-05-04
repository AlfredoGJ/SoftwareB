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
    /// Lógica de interacción para ArbitrosCatalogo.xaml
    /// </summary>
    /// 
    public partial class ArbitrosCatalogo : Page
    {
        Page previousPage;
        public ArbitrosCatalogo(Page previous)
        {
            previousPage = previous;
            InitializeComponent();
        }
        /// <summary>
        /// Actualiza la vista de la lista de jugadores con de todos los registros
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>

        private void UpdateArbitros(object sender, RoutedEventArgs e)
        {
            listaArbitros.ItemsSource = App.ArbitroController.GetAll();
        }
        private void ArbitroNuevo(object sender, RoutedEventArgs e)
        {
            ArbitroPage arbitroPage = new ArbitroPage(new Arbitro(), this);
            Window.GetWindow(this).Content = arbitroPage;
        }
        private void SearchArbitros(object sender, RoutedEventArgs e)
        {
            listaArbitros.ItemsSource = App.JugadorController.search(searchboxArbitros.Text);
        }
        private void SeleccionaArbitro(object sender, SelectionChangedEventArgs e)
        {
            if (listaArbitros.SelectedItem != null)
            {
                Arbitro jugador = (listaArbitros.SelectedItem as Arbitro);
                id.Content = jugador.id.ToString();
                nombre.Content = jugador.Nombre;
                paterno.Content = jugador.ApellidoPaterno;
                materno.Content = jugador.ApellidoMaterno;
                nacimiento.Content = jugador.FechaDeNacimiento.ToShortDateString();
                telefono.Content = jugador.Telefono;
                
            }

        }
        private void EliminarArbitro(object sender, RoutedEventArgs e)
        {
            if (listaArbitros.SelectedItem != null)
            {
                App.JugadorController.Delete((listaArbitros.SelectedItem as Jugador).id);
                UpdateArbitros(sender, e);

                // Se resetean los campos del jugador seleccionado eliminado
                id.Content = "";
                nombre.Content = "";
                materno.Content = "";
                paterno.Content = "";
                nacimiento.Content = "";
                telefono.Content = "";
              

            }
        }
        private void EditarArbitro(object sender, RoutedEventArgs e)
        {
            if (listaArbitros.SelectedItem != null)
            {

                Window.GetWindow(this).Content= new JugadorPage((Jugador)listaArbitros.SelectedItem, this);
                
            }

        }
        private void BusquedaAlCambiarTexto(object sender, TextChangedEventArgs e)
        {

            listaArbitros.ItemsSource = App.JugadorController.search(searchboxArbitros.Text);
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



        private void GoToFirst(object sender, RoutedEventArgs e)
        {
            listaArbitros.SelectedItem = listaArbitros.Items[0];
        }

        private void GoToPrevious(object sender, RoutedEventArgs e)
        {
            int index = listaArbitros.Items.IndexOf(listaArbitros.SelectedItem);
            if (index > 0)
                listaArbitros.SelectedItem = listaArbitros.Items[index - 1];
        }

        private void GoToNext(object sender, RoutedEventArgs e)
        {
            int index = listaArbitros.Items.IndexOf(listaArbitros.SelectedItem);
            if (index < listaArbitros.Items.Count - 1)
                listaArbitros.SelectedItem = listaArbitros.Items[index + 1];
        }

        private void GoToLast(object sender, RoutedEventArgs e)
        {
            listaArbitros.SelectedItem = listaArbitros.Items[listaArbitros.Items.Count - 1];
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
        }
    }
}
