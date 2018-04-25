using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.IO;

namespace League_planner

{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        static JugadorDBController jugadorcontroller;
        static SQLiteConnection connection;


        public static void StablishConnection()
        {
            if (!File.Exists("database.db"))
            {
                connection = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True ");
                connection.Open();
                CreateDatabase();
            }
            else
            {
                connection = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True ");
                connection.Open();
            }

            MessageBox.Show("Conexion exitosa");
        }

        private static void CreateDatabase()
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE jugadores(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50));";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom) VALUES('Juan', 'Perez', 'Lopez'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom) VALUES('Esteban', 'Lujan', 'Moreno'); ";
            command.ExecuteNonQuery();

        }

        public static JugadorDBController JugadorController
        {
           get
            {
                if (jugadorcontroller == null)
                {
                    jugadorcontroller = new JugadorDBController(connection);
                    return jugadorcontroller;
                }

                else
                {
                    return jugadorcontroller;
                }
            }
            
        }
        
          
        
    }
}
