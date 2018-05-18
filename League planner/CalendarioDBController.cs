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
            	if(calendario.id == 0)
            	{
            		command.CommandText = "INSERT INTO calendarios(dia, mes, local, visitante) VALUES (@dia, @mes, @local, @visitante);";
            		command.Parameters.AddWithValue("@dia",calendario.dia);
            		command.Parameters.AddWithValue("@mes",calendario.mes);
            		command.Parameters.AddWithValue("@local",calendario.local);
            		command.Parameters.AddWithValue("@visitante", calendario.visitante);

                    command.ExecuteNonQuery();
                    calendario.id = database.LastInsertRowId;
                 
                }
            	else
            	{
            		command.CommandText = "UPDATE calendarios SET dia= @dia, mes=@mes, local=@local, visitante=@visitante WHERE id= @id; ";
            		command.Parameters.AddWithValue("@dia", calendario.dia);
            		command.Parameters.AddWithValue("@mes", calendario.mes);
            		command.Parameters.AddWithValue("@local", calendario.local);
            		command.Parameters.AddWithValue("@visitante", calendario.visitante);

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
        									//                  id,			      dia,			      mes,		       	 local,			 ,visitante
        			eventos.Add(new Calendario(row.Field<Int64>(0),row.Field<int>(1),row.Field<string>(2),row.Field<string>(3),row.Field<string>(4) ) );
        		}
        	}
        	return eventos;
        }

    }
}
