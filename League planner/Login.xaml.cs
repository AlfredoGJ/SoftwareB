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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (usuario.Text == "admin" && contraseña.Password == "root")
                Window.GetWindow(this).Content = new AdminMainWindow();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if(e.RightButton== MouseButtonState.Released)
            Window.GetWindow(this).DragMove();
        }
    }
}