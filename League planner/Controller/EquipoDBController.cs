using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace League_planner
{
    public class EquipoDBController
    {
        SQLiteConnection database;
        
        public EquipoDBController(SQLiteConnection connection)
        {
            database = connection;
        }
        public void Save(Equipo equipo)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                if (equipo.id == 0)
                {
                    command.CommandText = "INSERT INTO equipos(nombre) VALUES( @nombre); ";
                    command.Parameters.AddWithValue("@nombre", equipo.Nombre);
                    command.ExecuteNonQuery();
                    equipo.id = database.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE equipos SET nombre= @nombre; ";
                    command.Parameters.AddWithValue("@nombre", equipo.Nombre);
                    command.ExecuteNonQuery();
                }
            }
         }
        public void Delete(long id)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                command.CommandText = "DELETE FROM equipos WHERE id= @id;";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
        public List<Equipo> GetAll()
        {
            DataTable table = new DataTable();
            List<Equipo> equipos = new List<Equipo>();
            string command = "SELECT * FROM equipos";

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
            {
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    equipos.Add(new Equipo(row.Field<Int64>(0), row.Field<string>(1)));
                }
            }
            return equipos;

        }
        public List<Equipo> search(string searchstring)
        {

            List<Equipo> all = GetAll();
            return all.FindAll(x => x.Nombre.IndexOf(searchstring, StringComparison.CurrentCultureIgnoreCase) >= 0);


        }

        public Equipo GetTeam(int clave)
        {

            DataTable table = new DataTable();
            List<Equipo> equipos = new List<Equipo>();
            string command = "SELECT * FROM equipos WHERE id= @clave;";
            SQLiteCommand SQLCmd = new SQLiteCommand(command, database);
            SQLCmd.Parameters.AddWithValue("@clave", clave);

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLCmd))
            {
                
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    equipos.Add(new Equipo(row.Field<Int64>(0), row.Field<string>(1)));
                }
            }

            if (equipos.Count > 0)
                return equipos[0];
            else return null;
        }

    }
}
