using System;
using System.Data.SqlClient;

namespace DatabaseDemo
{
    class Program
    {
        private static string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=SampleDatabase;Integrated Security=true";  //;AttachDbFileName=W:\Data\SampleDatabase.mdf
        private static SqlConnection conn;

        static void Main(string[] args)
        {
            ConnectToDatabase();
            AskCredentials();

            CloseConnection();

            Console.WriteLine("Thank you for using our product.");
        }

        private static void AskCredentials()
        {
            while(true)
            {
                Console.Write("User name: ");
                string username = Console.ReadLine();
                Console.Write($"Password for {username}: ");
                string password = Console.ReadLine();

                bool success = Login(username, password);
                if(success)
                {
                    Console.WriteLine("\nAUTHORIZED\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong user name or password.");
                }
            }
        }

        private static void ConnectToDatabase()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        private static bool Login(string username, string password)
        {
            string query = $"SELECT COUNT(*) FROM [dbo].[Login] WHERE [Username]='{username}' AND [Password]='{password}'";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();

            int result = dr.GetInt32(0);
            dr.Close();

            return result > 0;
        }

        private static void CloseConnection()
        {
            if(conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
