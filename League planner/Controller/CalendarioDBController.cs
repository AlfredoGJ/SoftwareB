using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace League_planner
{
    public class CalendarioDBController
    {
    	SQLiteConnection database;
        Calendario selected { get; }

        public CalendarioDBController(SQLiteConnection connection)
        {
        	database = connection;
        }

        public void Save(Calendario calendario)
        {
            using (SQLiteCommand command = new SQLiteCommand(database))
            {
                if (calendario.id == 0)
                {
                    command.CommandText = "INSERT INTO calendarios(fecha, local, visitante, ganador) VALUES (@fecha, @local, @visitante, @ganador);";
                    command.Parameters.AddWithValue("@fecha", calendario.fecha);
                    command.Parameters.AddWithValue("@local", calendario.local);
                    command.Parameters.AddWithValue("@visitante", calendario.visitante);
                    command.Parameters.AddWithValue("@ganador", calendario.ganador);

                    command.ExecuteNonQuery();
                    calendario.id = database.LastInsertRowId;

                } 

            	else
            	{
            		command.CommandText = "UPDATE calendarios SET fecha=@fecha, local=@local, visitante=@visitante, ganador= @ganador WHERE id= @id; ";
            		command.Parameters.AddWithValue("@fecha", calendario.fecha);
            		command.Parameters.AddWithValue("@local", calendario.local);
            		command.Parameters.AddWithValue("@visitante", calendario.visitante);
                    command.Parameters.AddWithValue("@ganador", calendario.ganador);
                    command.Parameters.AddWithValue("@id", calendario.id);
                    command.ExecuteNonQuery();
            	}
            }
        }

        //
        public List<Calendario> GetAll()
        {
        	DataTable table = new DataTable();
        	List<Calendario> eventos = new List<Calendario>();
        	// Selecciona todas las columnas de la tabla de calendarios
        	string  command = "SELECT * FROM calendarios";

        	using(SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, database))
        	{
        		adapter.Fill(table);
        		foreach(DataRow row in table.Rows)
        		{
        									//              id,			      fecha,		       	 local,			 ,visitante
        			eventos.Add(new Calendario(row.Field<Int64>(0),row.Field<DateTime>(1),row.Field<string>(2),row.Field<string>(3), row.Field<Int64>(4)) );
        		}
        	}
        	return eventos;
        }

    }
}
