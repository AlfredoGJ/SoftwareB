using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace League_planner
{
    
    public class JugadorDBController
    {
        SQLiteConnection database;
        Jugador selected { get; }


        /// <summary>
        /// Constructor de la clase que recibe una conexion de la base de datos donde se haran las modificaciones.
        /// </summary>
        /// <param name="connection">Conexion a la base de datos</param>
        public JugadorDBController(SQLiteConnection connection)
        {
            database = connection;
        }


        /// <summary>
        /// Guarda un jugador en la base de datos, ya sea un jugador ya existente en la misma o un jugador nuevo
        /// </summary>
        /// <param name="jugador">El jugador que se debe guardar en la base de datos</param>
        public void Save(Jugador jugador)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                if (jugador.id == 0)
                {
                    command.CommandText = "INSERT INTO jugadores(nombre, apellidop, apellidom) VALUES( @nombre ,@apellidop,@apellidom); ";
                    command.Parameters.AddWithValue("@nombre", jugador.Nombre);
                    command.Parameters.AddWithValue("@apellidop", jugador.ApellidoPaterno);
                    command.Parameters.AddWithValue("@apellidom", jugador.ApellidoMaterno);
                    command.ExecuteNonQuery();
                    jugador.id = database.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE jugadores SET nombre= @nombre, apellidop=@apellidop, apellidom=@apellidom WHERE id= @id; ";
                    command.Parameters.AddWithValue("@nombre", jugador.Nombre);
                    command.Parameters.AddWithValue("@apellidop", jugador.ApellidoPaterno);
                    command.Parameters.AddWithValue("@apellidom", jugador.ApellidoMaterno);
                    command.Parameters.AddWithValue("@id",jugador.id);
                    command.ExecuteNonQuery();
                }
               
                
            }
        }

        /// <summary>
        /// Elimina un jugador de la base de datos
        /// </summary>
        /// <param name="id">El id del jugador a  eliminar</param>
        public void Delete(long id)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                command.CommandText = "DELETE FROM jugadores WHERE id= @id;";
                command.Parameters.AddWithValue("@id",id);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Obtienen una lista que contiene todos los jugadores en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Jugador> GetAll()
        {
            DataTable table = new DataTable();
            List<Jugador> jugadores = new List<Jugador>();
            string command= "SELECT * FROM jugadores";

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
            {
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    jugadores.Add(new Jugador(row.Field<Int64>(0),row.Field<string>(1), row.Field<string>(2), row.Field<string>(3)));
                }
            }
            return jugadores;
                           
        }


        /// <summary>
        /// DEvuelve una lista con los jugadores cuyo nombre completo contenga una cadena de busqueda proporcionada
        /// </summary>
        /// <param name="searchstring">La cadena de busqueda </param>
        /// <returns></returns>
        public List<Jugador> search(string searchstring)
        {
           
            List<Jugador> all = GetAll();
            return all.FindAll(x=> x.NombreCompleto.IndexOf(searchstring,StringComparison.CurrentCultureIgnoreCase)>=0);
            

        }
        


    }
}
