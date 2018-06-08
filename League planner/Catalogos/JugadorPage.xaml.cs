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
    /// Lógica de interacción para JugadorPage.xaml
    /// </summary>
    public partial class JugadorPage : Page
    {
        Page previousPage;
        Jugador jugador;
        List<Equipo> equiposList;
        public Jugador Jugador{get; set;}
        DateTime nace;

        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="j">Jugador que será editado</param>
        /// <param name="previous"> Pagina desde la cual se llama a esta página</param>
        public JugadorPage(Jugador j, Page previous)
        {
            
            InitializeComponent();
         
            this.jugador = j;
            this.previousPage = previous;

            DataContext = jugador;

           
        }


        /// <summary>
        /// Cancela la edicion y regresa a la página anterior
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>
        public void Cancelar(object sender, EventArgs e)
        {
            Window.GetWindow(this).Content = previousPage;
        }


        /// <summary>
        /// Acepta los cambios realizados en el jugador, ya sea nuevo o editado y lo inserta o actualiza en la base de datos
        /// siempre y cuando se proporcionen los datos necesarios, en caso de ser así regresa a la pagina anterior 
        /// </summary>
        /// <param name="sender">El objeto que desencadenó este evento (no controlado por el usuario)</param>
        /// <param name="e">Argumentods del evento (no controlado por el usuario)</param>
        public void Aceptar(object sender, EventArgs e)
        {
            long cel = 0;
            if(equipos.SelectedItem != null)
            {
                if (nombre.Text != null && paterno.Text != null && materno.Text != null && telefono.Text != null && email.Text != null && nacimiento.Text != null &&
                    nombre.Text != "" && paterno.Text != "" && materno.Text != "")
                {
                    try{
                        if(nombre.Text.Any(x => char.IsNumber(x)) || materno.Text.Any(x => char.IsNumber(x)) || paterno.Text.Any(x => char.IsNumber(x)))
                        {
                            MessageBox.Show("Error J-07\nNombre no debe llevar numeros o simbolos");
                           
                        }
                        else
                        {
                            if ( telefono.Text.Length != 10 )
                            {
                                MessageBox.Show("Error J-05\nEl número debe contener 10 digitos");
                            }
                            else
                            {
                                jugador.Nombre = nombre.Text;
                                jugador.ApellidoPaterno = paterno.Text;
                                jugador.ApellidoMaterno = materno.Text;
                                nace = Convert.ToDateTime(nacimiento.Text);
                                if((DateTime.Now.Year - nace.Year) > 100 || (DateTime.Now.Year < nace.Year ) || ((DateTime.Now.Year - nace.Year) < 10))
                                {
                                    MessageBox.Show("La edad es correcta? ");
                                }
                                else
                                {
                                    jugador.FechaDeNacimiento = Convert.ToDateTime(nacimiento.Text);
                                    
                                    jugador.Email = email.Text;
                                    cel = Convert.ToInt64(telefono.Text);
                                    jugador.Telefono = cel;
                                    App.JugadorController.Save(jugador);
                                    MessageBox.Show(jugador.Nombre);
                                    Window.GetWindow(this).Content = previousPage;
                                       

                                    
                                }
                                

                            }
                        }
                        
                        


                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error J-03\nNo se pudo crear al jugador\n" + exception);

                    }
                }
                else
                {
                    MessageBox.Show("Error J-01\nComplete todos los campos");
                }
            }
            else
            {
                MessageBox.Show("Error J-05\nSeleccione un equipo");
            }
            
                
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

        private void equipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(equipos.SelectedItem != null)
            {
                Equipo equipo = (equipos.SelectedItem as Equipo);
                jugador.Equipo = Convert.ToInt32(equipo.id);
            }
           
        }
        // Carga la pagina
        // Si la base de datos no tiene equipos, manda un mensaje 
        // no se podra crear jugadores si no hay equipos
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            equiposList= App.EquipoController.GetAll();
            equipos.ItemsSource = equiposList; 
            if (equipos == null)
            {
                MessageBox.Show("Error J-02\nNo se puede crear jugadores debido a que no hay equipos disponibles");
            }
            else
            {
                equipos.SelectedItem = equiposList.Find(x => x.id==jugador.Equipo);
               
            }
            
        }

        private void ValidateNumeric(object sender, KeyEventArgs e)
        {
            if (!Char.IsNumber(e.ToString()[0]))
                e.Handled = true;
        }

        private void telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Console.WriteLine(e.Text);
            if (!Char.IsNumber(e.Text[0]))
                e.Handled = true;
            
        }
    }
}
