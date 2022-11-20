using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class SqlDbHelper
	{
		private string connString;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keyOfConnstring">app.config裡的值,例如'default'</param>
		public SqlDbHelper(string keyOfConnstring)
		{
			connString = System.Configuration.ConfigurationManager
				.ConnectionStrings[keyOfConnstring]
				.ConnectionString;
		}

		public void ExecuteNonQuery(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString)) 
			{ 
			SqlCommand command = new SqlCommand(sql, conn);
			conn.Open();


			command.Parameters.AddRange(parameters);

			command.ExecuteNonQuery();

		}
		}

		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString))
			{
			
				var command = new SqlCommand(sql, conn);
				if (parameters != null)
				{
					command.Parameters.AddRange(parameters);
				}
					

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "news");

				return dataSet.Tables["news"];


				Console.WriteLine("資料已 update");




			}
		}
	}
}
