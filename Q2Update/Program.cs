using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2Update
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
			string sql = "UPDATE Users Set " +
				"Name=@Name," +
				"Account=@Account," +
				"Password=@Password," +
				"DateOfBirthd=@DateOfBirthd," +
				"Height=@Height WHERE Id=@id ";
			var dbhelper = new SqlDbHelper("default");

			try
			{
				var aa = new sqlParameterBuilder()

					.AddNvarchar("Name", 50, "Amy")
					.AddNvarchar("Account", 50, "22222")
					.AddNvarchar("Password", 50, "00000")
					.AddDatetime("DateOfBirthd", DateTime.Today)
					.AddInt("Height", 160)
					.AddInt("id", 5)
					.Build();
				dbhelper.ExecuteNonQuery(sql, aa);


				Console.WriteLine("資料已更新");
			}
			catch (Exception EX)
			{

				Console.WriteLine($"失敗, 原因:{EX.Message}");
			}
		}
	}
}
