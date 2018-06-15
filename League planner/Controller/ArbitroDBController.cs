using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace League_planner
{

    /// <summary>
    /// Se encarga de hacer las transacciones de inserción, actualización, eliminación y lectura de la tabla arbitros, funciona como un puente entre el tipo de datos Arbitro de la aplicacion y la base de datos. 
    /// </summary>
    public class ArbitroDBController
    {
        SQLiteConnection database1;
        Arbitro selected { get; }

        public ArbitroDBController(SQLiteConnection connection)
        {
            database1 = connection;
        }
        public void Save(Arbitro arbitro)
        {
            using (SQLiteCommand command = new SQLiteCommand(database1))
            {
                if (arbitro.id == 0)
                {
                    command.CommandText = "INSERT INTO arbitros(nombre, apellidop, apellidom, nacimiento, telefono) VALUES( @nombre ,@apellidop,@apellidom,@nacimiento,@telefono); ";
                    command.Parameters.AddWithValue("@nombre", arbitro.Nombre);
                    command.Parameters.AddWithValue("@apellidop", arbitro.ApellidoPaterno);
                    command.Parameters.AddWithValue("@apellidom", arbitro.ApellidoMaterno);
                    command.Parameters.AddWithValue("@nacimiento", arbitro.FechaDeNacimiento);
                    command.Parameters.AddWithValue("@telefono", arbitro.Telefono);
                    

                    command.ExecuteNonQuery();
                    arbitro.id = database1.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE arbitros SET nombre= @nombre, apellidop=@apellidop, apellidom=@apellidom, nacimiento=@nacimiento, telefono=@telefono WHERE id= @id; ";
                    command.Parameters.AddWithValue("@nombre", arbitro.Nombre);
                    command.Parameters.AddWithValue("@apellidop", arbitro.ApellidoPaterno);
                    command.Parameters.AddWithValue("@apellidom", arbitro.ApellidoMaterno);
                    command.Parameters.AddWithValue("@id", arbitro.id);
                    command.Parameters.AddWithValue("@nacimiento", arbitro.FechaDeNacimiento);
                    command.Parameters.AddWithValue("@telefono", arbitro.Telefono);
                    command.Parameters.AddWithValue("@email", arbitro.Email);
                    command.Parameters.AddWithValue("@clave_equipo", arbitro.Equipo);
                    command.Parameters.AddWithValue("@eliminado", arbitro.Eliminado);
                    command.Parameters.AddWithValue("@id", arbitro.id);


                    command.ExecuteNonQuery();
                }


            }
        }
        public void Delete(long id)
        {
            using (SQLiteCommand command = new SQLiteCommand(database1))
            {
                command.CommandText = "DELETE FROM arbitros WHERE id= @id;";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Arbitro> GetAll()
        {
            DataTable table = new DataTable();
            List<Arbitro> arbitros = new List<Arbitro>();
            string command = "SELECT * FROM arbitros";

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database1))
            {
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    arbitros.Add(new Arbitro(row.Field<Int64>(0), row.Field<string>(1), row.Field<string>(2), row.Field<string>(3), DateTime.Parse(row.Field<String>(4)), row.Field<string>(5)));
                }
            }
            return arbitros;

        }
        public List<Arbitro> search(string searchstring)
        {

            List<Arbitro> all = GetAll();
            return all.FindAll(x => x.NombreCompleto.IndexOf(searchstring, StringComparison.CurrentCultureIgnoreCase) >= 0);


        }


    }
}
