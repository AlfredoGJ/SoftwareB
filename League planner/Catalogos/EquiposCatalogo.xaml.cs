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
    /// Lógica de interacción para EquiposCatalogo.xaml
    /// </summary>
    public partial class EquiposCatalogo : Page
    {
        Page previousPage;

        public EquiposCatalogo(Page previous)
        {
            previousPage = previous;
            InitializeComponent();
        }
        public void UpdateEquipos(object sender, RoutedEventArgs e)
        {

            listaEquipos.ItemsSource = App.EquipoController.GetAll();
        }
        private void EquipoNuevo(object sender, RoutedEventArgs e)
        {
            EquipoPage equipoPage = new EquipoPage(new Equipo(), this);
            Window.GetWindow(this).Content = equipoPage;


        }
        private void SearchEquipos(object sender, RoutedEventArgs e)
        {
            listaEquipos.ItemsSource = App.JugadorController.search(searchboxequipos.Text);
        }

        private void SeleccionaEquipo(object sender, SelectionChangedEventArgs e)
        {
            if (listaEquipos.SelectedItem != null)
            {
                Equipo equipo = (listaEquipos.SelectedItem as Equipo);
                id.Content = equipo.id.ToString();
                nombre.Content = equipo.Nombre;
                
            }

        }
        private void EliminarEquipo(object sender, RoutedEventArgs e)
        {
            if (listaEquipos.SelectedItem != null)
            {
                App.EquipoController.Delete((listaEquipos.SelectedItem as Equipo).id);
                UpdateEquipos(sender, e);

                // Se resetean los campos del jugador seleccionado eliminado
                id.Content = "";
                nombre.Content = "";
            }
        }
        private void EditarEquipo(object sender, RoutedEventArgs e)
        {
            if (listaEquipos.SelectedItem != null)
            {

                Window.GetWindow(this).Content = new EquipoPage((Equipo)listaEquipos.SelectedItem, this);

            }

        }
        private void BusquedaAlCambiarTexto(object sender, TextChangedEventArgs e)
        {

            listaEquipos.ItemsSource = App.EquipoController.search(searchboxequipos.Text);
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
            listaEquipos.SelectedItem = listaEquipos.Items[0];
        }

        private void GoToPrevious(object sender, RoutedEventArgs e)
        {
            int index = listaEquipos.Items.IndexOf(listaEquipos.SelectedItem);
            if (index > 0)
                listaEquipos.SelectedItem = listaEquipos.Items[index - 1];
        }

        private void GoToNext(object sender, RoutedEventArgs e)
        {
            int index = listaEquipos.Items.IndexOf(listaEquipos.SelectedItem);
            if (index < listaEquipos.Items.Count - 1)
                listaEquipos.SelectedItem = listaEquipos.Items[index + 1];
        }

        private void GoToLast(object sender, RoutedEventArgs e)
        {
            listaEquipos.SelectedItem = listaEquipos.Items[listaEquipos.Items.Count - 1];
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
        }



    }
}
