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
        static CalendarioDBController calendariocontroller;
        static GolDBController golController;
        static SQLiteConnection connection;
        static TarjetaDBController tarjetaController;


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

            //MessageBox.Show("Conexion exitosa","Espere");
        }

        private static void CreateDatabase()
        {

            SQLiteCommand command = new SQLiteCommand(connection);
            // Creacion de tabla jugadores
            command.CommandText = "CREATE TABLE jugadores(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento TEXT, telefono long, email varchar(100), clave_equipo int, eliminado int);";
            command.ExecuteNonQuery();

            //SE AGREGAN JUGADORES PARA INIACIALIZAR LA BASE DE DATOS

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
                "VALUES('Ernesto', 'Juarez', 'Lopez', '24-11-1980','1333567612','ernestoc_A@gmail.com', 1, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
               "VALUES('Emilio', 'Ibañez', 'Zamarripa', '18-11-1985','3333333333','im_emilio@gmail.com', 1, 0); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
               "VALUES('Carlos', 'Valdivia', 'Medellin', '12-9-1988','99999999','charlyV@gmail.com', 1, 0); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
               "VALUES('Alvaro', 'Perez', 'Martinez', '9-5-1982','9090222000','Alvaro_p@gmail.com', 1, 0); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
               "VALUES('Joaquin', 'Barcenas', 'Gonzalez', '1991-4-7','8898902233','SoyTJ@hotmail.com', 1, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
              "VALUES('Pedro Daniel', 'Montoya', 'Gonzalez', '1991-1-3','8898902233','PedroDMG@hotmail.com', 2, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
              "VALUES('Luis', 'Berrones', 'Sandoval', '1992-1-9','1112234567','LBrrones@hotmail.com', 2, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
              "VALUES('Miguel Angel', 'Contreras', 'Contreras', '1991-4-7','7787878888','MGACDD@hotmail.com', 2, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
              "VALUES('Esteban Sebastian', 'Araya', 'Gutierrez', '1991-12-23','8898902233','Sebas_Sebas@hotmail.com', 2, 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom, nacimiento, telefono, email, clave_equipo,eliminado) " +
              "VALUES('Tomas Alberto', 'Ruiz', 'Anaya', '1991-8-21','8898902233','TommyRuiz@hotmail.com', 2, 0); ";
            command.ExecuteNonQuery();



            // Creacion de tabla arbitros
            command.CommandText = "CREATE TABLE arbitros(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento TEXT, telefono varchar(10), email varchar(100), eliminado int);";
            command.ExecuteNonQuery();


            // SE AGREGAN ARBITROS PARA LA INICIALIZACION DE LA BASE DE DATOS

            command.CommandText = "INSERT INTO arbitros(nombre, apellidop, apellidom, nacimiento, telefono, email,eliminado) " +
              "VALUES('Jose Sebastian', 'Sanchez', 'Beltran', '1975-8-21','8898902233','sebas_34@hotmail.com', 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO arbitros(nombre, apellidop, apellidom, nacimiento, telefono, email,eliminado) " +
             "VALUES('Juan Uriel', 'Ortega', 'Ozuna', '1972-2-3','8898902233','J_Uriel@hotmail.com', 0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO arbitros(nombre, apellidop, apellidom, nacimiento, telefono, email,eliminado) " +
             "VALUES('Amador', 'Barcenas', 'Colunga', '1985-4-12','8898902233','Abar_34@hotmail.com', 0); ";
            command.ExecuteNonQuery();




            // Creacion de tabla equipos
            command.CommandText = "CREATE TABLE equipos (id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), clave_entrenador int, eliminado int, activo int);";
            command.ExecuteNonQuery();
            
            // CREACION DE EQUIPOS PARA LA INICUALIZACION DE LA BASE DE DATOS

            command.CommandText = "INSERT INTO equipos (nombre, clave_entrenador,eliminado, activo) " +
            "VALUES('Cuervos', 1,0,1); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO equipos (nombre, clave_entrenador,eliminado, activo) " +
           "VALUES('Aguilas', 1,0,1); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO equipos (nombre, clave_entrenador,eliminado, activo) " +
           "VALUES('Tigres', 1,0,1); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO equipos (nombre, clave_entrenador,eliminado, activo) " +
           "VALUES('Cruz Azul', 1,0,1); ";
            command.ExecuteNonQuery();



            // Creacion de tabla entrenadores
            command.CommandText = "CREATE TABLE entrenadores(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nombre varchar(50), apellidop varchar(50), apellidom varchar(50), nacimiento TEXT, telefono int, email varchar(100), eliminado int);";
            command.ExecuteNonQuery();

            // CREACION DE ENTRENADORES PARA INICIALIZACIN DE BASE DE DATOS

            command.CommandText = "INSERT INTO entrenadores (nombre, apellidop,apellidom, nacimiento, telefono, email, eliminado) " +
          "VALUES('Edgardo','Lopez','Medellin','1980/2/22', 66655543,'EdLM@gmail.com',0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO entrenadores (nombre, apellidop,apellidom, nacimiento, telefono, email, eliminado) " +
          "VALUES('Catarino','Juarez','Sanjuan','1980/2/22', 66655543,'CatJSJ@gmail.com',0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO entrenadores (nombre, apellidop,apellidom, nacimiento, telefono, email, eliminado) " +
          "VALUES('Miguel','Santillan','Sanchez','1980/2/22' ,66650002,'MSS_g@gmail.com',0); ";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO entrenadores (nombre, apellidop,apellidom, nacimiento, telefono, email, eliminado) " +
          "VALUES('Lindoro','Lopez','Lainez','1980/2/22' ,78755543,'LLL_A@gmail.com',0); ";
            command.ExecuteNonQuery();



            // Creacion de tabla partidos
            command.CommandText = "CREATE TABLE partidos(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                   "clave_equipo_v int, clave_equipo_l int, tipo_partido varchar(10), clave_arbitro int, clave_temporada int, fecha TEXT, hora TEXT);";
            command.ExecuteNonQuery();

            //Creacion de tabla temporadas
            command.CommandText = "CREATE TABLE temporadas(id INTEGER PRIMARY KEY AUTOINCREMENT," + "periodo varchar(30), clave_campeon int );";
            command.ExecuteNonQuery();

            //Creacion de tabla goles
            command.CommandText = "CREATE TABLE goles(id INTEGER PRIMARY KEY AUTOINCREMENT," + " clave_jugador int, clave_partido int, favor_o_contra int, clave_equipo int);";
            command.ExecuteNonQuery();

            //Creacion de tabla tarjetas
            command.CommandText = "CREATE TABLE tarjetas(id INTEGER PRIMARY KEY AUTOINCREMENT," + "clave_jugador int, tipo varchar(10), clave_partido int, clave_equipo int);";
            command.ExecuteNonQuery();

            //Creacion de tabla usuarios
            command.CommandText = "CREATE TABLE usuarios(id INTEGER PRIMARY KEY AUTOINCREMENT," + "tipo varchar(30), contrasena varchar(20), eliminado int);";
            command.ExecuteNonQuery();

            //Creacion de tabla calendario
            command.CommandText = "CREATE TABLE calendarios(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                 " fecha DateTime, local varchar(30), visitante varchar(30), ganador INTEGER);";
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
        public static ArbitroDBController ArbitroController
        {
            get
            {
                if (arbitrocontroller == null)
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
        public static CalendarioDBController CalendarioController
        {
            get
            {
                if (calendariocontroller == null)
                {
                    calendariocontroller = new CalendarioDBController(connection);
                    return calendariocontroller;
                }
                else
                {
                    return calendariocontroller;
                }
            }
        }

        public static GolDBController GolController
        {
            get
            {
                if (golController == null)
                {
                    golController = new GolDBController(connection);
                    return golController;
                }
                else
                {
                    return golController;
                }
            }
        }

        public static TarjetaDBController TarjetaController
        {
            get
            {
                if (tarjetaController == null)
                {
                    tarjetaController = new TarjetaDBController(connection);
                    return tarjetaController;
                }
                else
                {
                    return tarjetaController;
                }
            }
        }



    }
}
