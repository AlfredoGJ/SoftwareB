using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace League_planner
{
    public class GolDBController
    {
        SQLiteConnection database;
        Gol selected { get; }

        public GolDBController(SQLiteConnection connection)
        {
            this.database = connection;
        }

        public void Save(Gol gol)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                if (gol.id == 0)
                {
                    command.CommandText = "INSERT INTO goles(clave_jugador, clave_partido, favor_o_contra, clave_equipo) VALUES( @clave_jugador, @clave_partido, @favor_o_contra, @equipo);";
                    command.Parameters.AddWithValue("@clave_jugador",gol.clave_jugador);
                    command.Parameters.AddWithValue("@clave_partido", gol.clave_partido);
                    command.Parameters.AddWithValue("@favor_o_contra", gol.favor_o_contra);
                    command.Parameters.AddWithValue("@equipo", gol.equipo);
                    command.ExecuteNonQuery();
                    gol.id = database.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE goles SET clave_jugador = @clave_jugador, clave_partido = @clave_partido, favor_o_contra = @favor_o_contra, clave_equipo = @clave_equipo WHERE id= @id;";
                    command.Parameters.AddWithValue("@id", gol.id);
                    command.Parameters.AddWithValue("@clave_jugador", gol.clave_jugador);
                    command.Parameters.AddWithValue("@clave_partido", gol.clave_partido);
                    command.Parameters.AddWithValue("@favor_o_contra", gol.favor_o_contra);
                    command.Parameters.AddWithValue("@clave_equipo", gol.equipo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Gol> GetAll()
        {
            DataTable table = new DataTable();
            List<Gol> goles = new List<Gol>();
            string command = "SELECT * FROM goles";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
            {
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    goles.Add(new Gol(row.Field<Int64>(0), row.Field<int>(1), row.Field<int>(2), row.Field<int>(3), row.Field<int>(4)));
                }
            }
            return goles;
        }

        public void Delete(Gol g)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                command.CommandText = "DELETE FROM goles WHERE id= @id;";
                command.Parameters.AddWithValue("@id", g.id);
                command.ExecuteNonQuery();
            }

        }
    }
}
