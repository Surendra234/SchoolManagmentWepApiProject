using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace SchoolManagmentSystem
{
    public class MyMethods
	{
        MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString: "Server=localhost;port=3306;Database=SchoolManagmentSystem;user=root;password=root@1234;Persist security Info=true");

        public string helloWorld()
		{
			return "Hello world";
		}
	}
}

