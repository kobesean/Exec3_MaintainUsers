using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3Delete
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "DELETE FROM Users WHERE Id=@id ";
			var dbhelper = new SqlDbHelper("default");

			try
			{
				var aa = new sqlParameterBuilder()
					.AddInt("id", 9)
					.Build();
				dbhelper.ExecuteNonQuery(sql, aa);


				Console.WriteLine("資料已刪除");
			}
			catch (Exception EX)
			{

				Console.WriteLine($"失敗, 原因:{EX.Message}");
			}
		}
	}
}
