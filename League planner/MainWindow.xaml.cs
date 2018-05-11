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
    public partial class MainWindow : Window
    {
        SQLiteConnection connection;
        JugadorDBController jugadorController;
        ArbitroDBController arbitroController;

        public MainWindow()
        {
            InitializeComponent();
            App.StablishConnection();
            this.Content = new AdminMainWindow();
        }


        
      
        
    }
}
