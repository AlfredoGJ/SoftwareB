﻿using System;
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
    /// Lógica de interacción para ArbitroPage.xaml
    /// </summary>
    public partial class ArbitroPage : Page
    {
         Page previousPage;
         Arbitro arbitro;

        public Arbitro Arbitro { get; set; }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="j">Jugador que será editado</param>
        /// <param name="previous"> Pagina desde la cual se llama a esta página</param>

        public ArbitroPage(Arbitro a, Page previous)
        {
            InitializeComponent();

            this.arbitro = a;
            this.previousPage = previous;

            DataContext = arbitro;
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
            if (!String.IsNullOrEmpty(nombre.Text) && !String.IsNullOrEmpty(paterno.Text) && !String.IsNullOrEmpty(materno.Text) )
            {

                if (telefono.Text.Length == 10)
                {
                    
                    App.ArbitroController.Save(arbitro);
                    Window.GetWindow(this).Content = previousPage;
                }
                else
                    MessageBox.Show("El telefono debe ser de 10 digitos");
                

            }
            else
                MessageBox.Show("Complete todos los campos para el arbitro");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

        private void telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Console.WriteLine(e.Text);
            if (!Char.IsNumber(e.Text[0]))
                e.Handled = true;

        }
    }
}
