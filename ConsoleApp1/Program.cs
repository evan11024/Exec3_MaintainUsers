using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
		}

		public void Insert(int id, string name, string account, string password, DateTime dateTime, int heigth)
		{
			try
			{
				string sql = "INSERT INTO Users VALUES (@Id,@Name,@Account,@Password,@Datetime,@Heigth)";
				var dbhelper = new SqlDbHelper("default");
				var parameters = new SqlParameterBuilder().AddInt("Id", id)
														  .AddNVarchar("Name", 50, name)
														  .AddNVarchar("Account", 50, account)
														  .AddNVarchar("Password", 50, password)
														  .AddDatetime("Datetime", dateTime)
														  .AddInt("Heigth", heigth)
														  .build();
				dbhelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("資料已新增");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"新增失敗 原因:{ex.Message}");
			}
		}
		public void Delete(int id)
		{
			try
			{
				string sql = "Delete FROM Users VALUES WHERE Id = @Id";
				var dbhelper = new SqlDbHelper("default");
				var parameters = new SqlParameterBuilder().AddInt("Id", id)
														  .build();
				dbhelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("資料已刪除");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"刪除失敗 原因:{ex.Message}");
			}
		}
		public void Update(int id, string name, string account, string password, DateTime dateTime, int heigth)
		{
			try
			{
				string sql = "UPDATE Users SET Name = @Name,Account=@Account,Password=@Password,Datetime = @Datetime,Heigth=@Heigth WHERE Id = @Id";
				var dbhelper = new SqlDbHelper("default");
				var parameters = new SqlParameterBuilder().AddInt("Id", id)
														  .AddNVarchar("Name", 50, name)
														  .AddNVarchar("Account", 50, account)
														  .AddNVarchar("Password", 50, password)
														  .AddDatetime("Datetime", dateTime)
														  .AddInt("Heigth", heigth)
														  .build();
				dbhelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("資料已修改");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"修改失敗 原因:{ex.Message}");
			}
		}
		public void Select(int Id)
		{
			string sql = "select * FROM Users WHERE Id >@Id ORDER BY Id DESC";

			var dbHelper = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder()
										.AddInt("Id", Id)
										.build();
				DataTable news = dbHelper.Select(sql, parameters);

				foreach (DataRow row in news.Rows)
				{
					int id = row.Field<int>("Id");
					string title = row.Field<string>("Title");
					Console.WriteLine($"ID = {id}, Title = {title}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗，原因:{ex.Message}");
			}
		}

	}
}
