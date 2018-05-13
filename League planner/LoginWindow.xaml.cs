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
using System.Windows.Shapes;

namespace League_planner
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

         private void LogIn(object sender, RoutedEventArgs e)
        {
            if (usuario.Text == "admin" && contraseña.Password == "root")
            {
                Window w = new MainWindow(usuario.Text);
                w.Show();
                this.Close();
               
            }

            if (usuario.Text == "coach" && contraseña.Password == "1234")
            {
                Window w = new MainWindow(usuario.Text);
                w.Show();
                this.Close();

            }



        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            Console.WriteLine("alksdjlaksjdlk");
            
        }
    }
}
