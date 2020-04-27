using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADONET;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace UnitTests
{
    using ADONET;
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Connection_0returned()
        {
            int expected = 0;
            int actual = Program.ConnectionTest();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest_0returned()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            int expected = 0;
            int actual = Program.InsertTest(connection, "knopka", "proverka nagatiya");
           
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateTest_0returned()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            int expected = 0;
            int actual = Program.UpdateTest(connection, 3, "login to acc", "proverka vhoda");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest_0returned()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            int expected = 0;
            int actual = Program.DeleteTest(connection, 2);

            Assert.AreEqual(expected, actual);
        }

    }
}
    


