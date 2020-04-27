using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace ADONET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);

            Program p = new Program();
            p.Connect(connection);
            //InsertTest(connection, "password", "proverka vvoda parolya");
            //UpdateTest(connection, 10, "knopka vvoda", "proverka nagatiya"); 
            //DeleteTest(connection, 5);
        }

        public void Connect(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);

                //InsertTest(connection, "password", "proverka vvoda parolya");
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
            Console.Read();
        }
      
        public static int ConnectionTest()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }

        public static int InsertTest(MySqlConnection connection, string NameTest, string Description)
        {
             connection.Open();
             string sqlExpression = "INSERT INTO test (name_test, description) VALUES (@name_test, @description)";

             MySqlCommand command = new MySqlCommand(sqlExpression, connection);

             MySqlParameter nameParam = new MySqlParameter("@name_test", NameTest);
             command.Parameters.Add(nameParam);
             MySqlParameter descriptionParam = new MySqlParameter("@description", Description);
             command.Parameters.Add(descriptionParam);

             int number = command.ExecuteNonQuery();
             Console.WriteLine("Добавлено тестов: {0}", number);
             connection.Close();
              
             return 0;
        }

        public static int UpdateTest(MySqlConnection connection, int id, string NewNameTest, string NewDescription)
        {
            connection.Open();
            string sqlExpression = "UPDATE test SET name_test = @name_test, description = @description WHERE id_test = @id";

            MySqlCommand command = new MySqlCommand(sqlExpression, connection);

            MySqlParameter nameParam = new MySqlParameter("@name_test", NewNameTest);
            command.Parameters.Add(nameParam);
            MySqlParameter descriptionParam = new MySqlParameter("@description", NewDescription);
            command.Parameters.Add(descriptionParam);
            MySqlParameter IdParam = new MySqlParameter("@id", id);
            command.Parameters.Add(IdParam);

            int number = command.ExecuteNonQuery();
            Console.WriteLine("Обновлено тестов: {0}", number);
            connection.Close();

            return 0;
        }

        public static int DeleteTest(MySqlConnection connection, int id)
        {
            connection.Open();
            string sqlExpression = "DELETE FROM test WHERE id_test=@id";

            MySqlCommand command = new MySqlCommand(sqlExpression, connection);

            MySqlParameter IdParam = new MySqlParameter("@id", id);
            command.Parameters.Add(IdParam);

            int number = command.ExecuteNonQuery();
            Console.WriteLine("Удалено тестов: {0}", number);
            connection.Close();

            return 0;
        }
    
    }
}
