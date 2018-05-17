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
        static ArbitroDBController arbitrocontroller;
        static EquipoDBController equipocontroller;
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
           // Creacion de tabla jugadores
            command.CommandText = "CREATE TABLE jugadores(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento DATE, telefono varchar(10), email varchar(100), clave_equipo int, eliminado int);";
            command.ExecuteNonQuery();


            // Creacion de tabla arbitros
            command.CommandText = "CREATE TABLE arbitros(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento DATE, telefono varchar(10), email varchar(100), eliminado int);";
            command.ExecuteNonQuery();

            // Creacion de tabla equipos
            command.CommandText = "CREATE TABLE equipos(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), clave_entrenador int, eliminado int, activo int);";
            command.ExecuteNonQuery();

            // Creacion de tabla entrenadores
            command.CommandText = "CREATE TABLE entrenadores(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento DATE, telefono varchar(10), email varchar(100), eliminado int);";
            command.ExecuteNonQuery();

            // Creacion de tabla partidos
            command.CommandText = "CREATE TABLE partidos(id INTEGER PRIMARY KEY AUTOINCREMENT," + 
                                   "clave_equipo_v int, clave_equipo_l int, tipo_partido varchar(10), clave_arbitro int, clave_temporada int, fecha DATE);";
            command.ExecuteNonQuery();

            //Creacion de tabla temporadas
            command.CommandText = "CREATE TABLE temporadas(id INTEGER PRIMARY KEY AUTOINCREMENT," + "periodo varchar(30), clave_campeon int );";
            command.ExecuteNonQuery();

            //Creacion de tabla goles
            command.CommandText = "CREATE TABLE goles(id INTEGER PRIMARY KEY AUTOINCREMENT," + " clave_jugador int, clave_partido int, favor_o_contra int);";
            command.ExecuteNonQuery();

            //Creacion de tabla tarjetas
            command.CommandText = "CREATE TABLE tarjetas(id INTEGER PRIMARY KEY AUTOINCREMENT," + "clave_jugador int, tipo varchar(10), clave_partido int);";
            command.ExecuteNonQuery();

            //Creacion de tabla usuarios
            command.CommandText = "CREATE TABLE usuarios(id INTEGER PRIMARY KEY AUTOINCREMENT," + "tipo varchar(30), contrasena varchar(20), eliminado int);";
            command.ExecuteNonQuery();

            //command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom) VALUES('Juan', 'Perez', 'Lopez'); ";
            //command.ExecuteNonQuery();
            //command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom) VALUES('Esteban', 'Lujan', 'Moreno'); ";
            //command.ExecuteNonQuery();

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
        public static ArbitroDBController ArbitroController
        {
            get
            {
                if(arbitrocontroller == null)
                {
                    arbitrocontroller = new ArbitroDBController(connection);
                    return arbitrocontroller;
                }
                else
                {
                    return arbitrocontroller;
                }
            }
        }
        public static EquipoDBController EquipoController
        {
            get
            {
                if (equipocontroller == null)
                {
                    equipocontroller = new EquipoDBController(connection);
                    return equipocontroller;
                }
                else
                {
                    return equipocontroller;
                }
            }
        }
        
          
        
    }
}
