using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace League_planner
{
    public class TarjetaDBController
    {
        SQLiteConnection database;
        Gol selected { get; }

        public TarjetaDBController(SQLiteConnection connection)
        {
            this.database = connection;
        }

        public void Save(Tarjeta tarjeta)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                if (tarjeta.id == 0)
                {
                    command.CommandText = "INSERT INTO tarjetas(clave_jugador, clave_partido, tipo, clave_equipo) VALUES( @clave_jugador, @clave_partido, @tipo, @clave_equipo);";
                    command.Parameters.AddWithValue("@clave_jugador", tarjeta.Jugador);
                    command.Parameters.AddWithValue("@clave_partido", tarjeta.Partido);
                    command.Parameters.AddWithValue("@tipo", tarjeta.Tipo);
                    command.Parameters.AddWithValue("@clave_equipo", tarjeta.equipo);


                    command.ExecuteNonQuery();
                    tarjeta.id = (int)database.LastInsertRowId;
                }
                else
                {
                    command.CommandText = "UPDATE tarjetas SET clave_jugador = @clave_jugador, clave_partido = @clave_partido, tipo = @tipo, clave_equipo= @clave_equipo WHERE id=@id; ";
                    command.Parameters.AddWithValue("@id", tarjeta.id);
                    command.Parameters.AddWithValue("@clave_jugador", tarjeta.Jugador);
                    command.Parameters.AddWithValue("@clave_partido", tarjeta.Partido);
                    command.Parameters.AddWithValue("@tipo", tarjeta.Tipo);
                    command.Parameters.AddWithValue("@clave_equipo", tarjeta.equipo);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Tarjeta> GetAll()
        {
            DataTable table = new DataTable();
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            string command = "SELECT * FROM tarjetas";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
            {
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    tarjetas.Add(new Tarjeta(row.Field<Int64>(0), row.Field<int>(1), row.Field<string>(2), row.Field<int>(3), row.Field<int>(4)));
                }
            }
            return tarjetas;
        }

        public void Delete(Tarjeta t)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                command.CommandText = "DELETE FROM tarjetas WHERE id = @id;";
                command.Parameters.AddWithValue("@id", t.id);
                command.ExecuteNonQuery();
            }

        }
    }
}
