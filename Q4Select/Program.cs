using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4Select
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "SELECT ID, Name FROM Users WHERE Id>@id order by Id DESC ";
			var dbhelper = new SqlDbHelper("default");

			try
			{
				var aa = new sqlParameterBuilder()
					.AddInt("id", 0)
					.Build();
				DataTable Users1 = dbhelper.Select(sql, aa);
				foreach (DataRow item in Users1.Rows)
				{
					int id = item.Field<int>("id");
					string Name=item.Field<string>("name");
					Console.WriteLine($"id={id}name={Name}");
				}


				Console.WriteLine("資料已查詢");
			}
			catch (Exception EX)
			{

				Console.WriteLine($"失敗, 原因:{EX.Message}");
			}
		}
	}
}
