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
    /// Lógica de interacción para EntrenadorMainWindow.xaml
    /// </summary>
    public partial class EntrenadorMainWindow : Page
    {
        public EntrenadorMainWindow()
        {
            InitializeComponent();
        }

        private void Image_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void PanelMouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel panel = (sender as StackPanel);
            panel.Margin = new Thickness(-10);
            panel.BringIntoView();

        }

        private void PanelMouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel panel = (sender as StackPanel);
            panel.Margin = new Thickness(10);
        }

        private void JugadoresMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Content = new EquipoEstadisticasPage(this);
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released)
                Window.GetWindow(this).DragMove();
        }

        private void AribtrosMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Content = new ArbitrosCatalogo(this);
        }
        private void EquiposMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Content = new EquiposCatalogo(this);
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CambiarUsuario(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
            Window.GetWindow(this).Close();

        }

        private void tabla_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Content = new TablaPage(this);
        }
    }
}