using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Insert
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "INSERT INTO Users(Name,Account,Password,DateOfBirthd,Height) " +
						"VALUES(@Name,@Account,@Password,@DateOfBirthd,@Height)";
			var dbhelper = new SqlDbHelper("default");

			try
			{
				var aa = new sqlParameterBuilder()
					.AddNvarchar("Name", 50, "Lin")
					.AddNvarchar("Account", 50, "AAA123")
					.AddNvarchar("Password", 50, "aaa321")
					.AddDatetime("DateOfBirthd", DateTime.Today)
					.AddInt("Height", 198)
					.Build();
				dbhelper.ExecuteNonQuery(sql, aa);


				Console.WriteLine("資料已新增");
			}
			catch (Exception EX)
			{

				Console.WriteLine($"失敗, 原因:{EX.Message}");
			}

		}
	}
}
