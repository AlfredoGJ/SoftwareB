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
    /// Lógica de interacción para CalendarioPage.xaml
    /// </summary>
    public partial class CalendarioPage : Page
    {
        Page previousPage;
        Calendario calendario;
        DateTime hoy = DateTime.Now;
        int compara;
        int comparaEquipos;
        DateTime fechaPartido;
       
        
        public Calendario Calendario{get; set;}

        public CalendarioPage(Calendario c, Page previous)
        {

            
            this.calendario = c;
            this.previousPage = previous;
            DataContext = calendario;
            
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
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
        //Envia los datos capturados y los guarda en la base de datos
        private void button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        /************************************************************************************************************************************************
         *              BOTON AGREGAR EVENTO
         *              Funcionalidad:
         *                  * Agrega un evento a la base de datos registrando la fecha, el equipo local  y el visitante.
         *                  * Si la fecha es menor a la fecha actual, envia un mensaje de error.
         *                  * Si no se selecciona un equipo, envia un mensaje pidiendo completar los campos.
         *                  * Si selecciona el mismo equipo tanto para local como visitante, solicita verificar los equipos.
         ************************************************************************************************************************************************/
        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            
            // Sentencia if donde evalua si todos los campos han sido llenados
            if(fecha.Text != null && equipoLocal.SelectedItem != null && equipoVisitante.SelectedItem != null){
                try{
                    fechaPartido = Convert.ToDateTime(fecha.Text);
                }
                catch (Exception exception){
                    MessageBox.Show("ERROR 005\nEscriba en el formato correspondiente");
                }
                try{
                    // variable que compara la fecha actual con la escrita por el usuario donde:
                    // compara == 0, entonces tiene la misma fecha y no hay problema
                    // compara >  0, entonces la fecha solicitada está en el pasado de la actual y requiere cambiar de fecha
                    // compara <  0, entonces la fecha se puede agendar en la base de datos 
                    
                    compara = DateTime.Compare(Convert.ToDateTime(hoy.ToShortDateString()), Convert.ToDateTime(fechaPartido.ToShortDateString()));
                    comparaEquipos = string.Compare(calendario.local, calendario.visitante);
                    if(comparaEquipos ==  0){
                        MessageBox.Show("ERROR: 002\nNo puede seleccionar al mismo equipo para local como para visitante");
                    }
                    else{
                        if (compara > 0){
                            MessageBox.Show("ERROR: 003\nNo puede agendar en está fecha");
                        }
                        else{
                            calendario.fecha = Convert.ToDateTime(fecha.Text);
                            App.CalendarioController.Save(calendario);
                            MessageBox.Show("Evento creado correctamente");
                        }
                    }   
                }
                catch(InvalidCastException exception){
                    MessageBox.Show("ERROR: 004\nError al insertar la fecha\n\n" + exception);
                }
            }
            else{
                MessageBox.Show("ERROR: 006\nComplete todos los campos");
            }
        }

        // Selecciona el equipo del comobobox y se le asigna al objeto Calendario
        private void equipoLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equipoLocal.SelectedItem != null)
            {
                Equipo local = (equipoLocal.SelectedItem as Equipo);
                calendario.local = local.Nombre;
            }
        }
        // Selecciona el equipo del comobobox y se le asigna al objeto Calendario
        private void equipoVisitante_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(equipoVisitante.SelectedItem != null)
            {
                Equipo visitante = (equipoVisitante.SelectedItem as Equipo);
                calendario.visitante = visitante.Nombre;
            }
        }

        /***********************************************************************************************************
         *  Al momento de cargar la página
         *  * Envia a los combobox los nombres de los equipos para crear el partido
         *  * Envia la fecha actual al textbox para que el usuario note como debe de ir la fecha
         ***********************************************************************************************************/
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            equipoLocal.ItemsSource = App.EquipoController.GetAll();
            equipoVisitante.ItemsSource = App.EquipoController.GetAll();
            fecha.Text = hoy.Date.ToShortDateString();    
        }
    }
}
