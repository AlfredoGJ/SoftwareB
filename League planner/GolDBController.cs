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
                    command.CommandText = "INSERT INTO goles(clave_jugador, clave_partido, favor_o_contra, gol) VALUES( @clave_jugador, @clave_partido, @favor_o_contra, @gol);";
                    command.Parameters.AddWithValue("@clave_jugador",gol.clave_jugador);
                    command.Parameters.AddWithValue("@clave_partido", gol.clave_partido);
                    command.Parameters.AddWithValue("@favor_o_contra", gol.favor_o_contra);
                    command.Parameters.AddWithValue("@gol", gol.gol);

                    command.ExecuteNonQuery();
                    gol.id = database.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE goles SET clave_jugador = @clave_jugador, clave_partido = @clave_partido, favor_o_contra = @favor_o_contra, gol = @gol;";
                    command.Parameters.AddWithValue("@id", gol.id);
                    command.Parameters.AddWithValue("@clave_jugador", gol.clave_jugador);
                    command.Parameters.AddWithValue("@clave_partido", gol.clave_partido);
                    command.Parameters.AddWithValue("@favor_o_contra", gol.favor_o_contra);
                    command.Parameters.AddWithValue("@gol", gol.gol);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Calendario> GetAll()
        {
            DataTable table = new DataTable();
            List<Calendario> eventos = new List<Calendario>();
            string command = "SELECT * FROM calendarios";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
            {
                //adapter.Fill(table);
                foreach(DataRow row in table.Rows)
                {
                    eventos.Add(new Calendario(row.Field<Int64>(0),row.Field<DateTime>(1),row.Field<string>(2), row.Field<string>(3)));
                }
            }
            return eventos;
        }
    }
}
