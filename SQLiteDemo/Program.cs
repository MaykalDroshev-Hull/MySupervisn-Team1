using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLiteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
        SQLiteConnection connection;
            string tableName = "StudentMessage";
            int id = 123456;
            string name = "Sean Kirwin";
            List<string> messages = new List<string>();
            messages.Add("Hi, I am struggleing with workload at the moment, could you please help me? Thanks you, Sean");
            messages.Add("Good evening, I am struggleing with workload at the moment, could you please help me? Regards, Sean");
            messages.Add("Hi, Thank you for your help the other day. Best, Sean");

            connection = CreateConnection(tableName);
            CreateTable(connection, tableName);
            InsertData(connection, tableName, id, name, messages);
            ReadData(connection, tableName);

            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }

        static SQLiteConnection CreateConnection(string pTableName)
        {
            SQLiteConnection connection;
            // Create a new database connection:
            string fileName = String.Format("Data Source = database{0}.db; Version = 3; New = True; Compress = True; ", pTableName);
            connection = new SQLiteConnection(fileName);
            // Open the connection:
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, unable to connect to databse!");
            }
            return connection;
        }

        static void CreateTable(SQLiteConnection pConnection, string pTableMessage)
        {
            // Create a table (drop if already exists)
            SQLiteCommand cmdDrop = pConnection.CreateCommand();
            cmdDrop.CommandText = "DROP TABLE IF EXISTS " + pTableMessage;
            cmdDrop.ExecuteNonQuery();

            SQLiteCommand cmdCreate = pConnection.CreateCommand();
            cmdCreate.CommandText = String.Format("CREATE TABLE {0} (ID INT, NAME VARCHAR(20), MESSAGE VARCHAR(20))", pTableMessage); // column's title string or number
            cmdCreate.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection pConnection, string pTableName, int pId, string pName, List<string> pMessages)
        {
            using (SQLiteTransaction transaction = pConnection.BeginTransaction())
            {
                SQLiteCommand cmdInsert = pConnection.CreateCommand();

                foreach (string message in pMessages)
                {
                    cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, MESSAGE ) VALUES({1}, '{2}', '{3}'); ", pTableName, pId, pName, message);
                    cmdInsert.ExecuteNonQuery();
                }

                transaction.Commit();
            }
        }

        static void ReadData(SQLiteConnection pConnection, string pTableName)
        {
            SQLiteCommand cmdSelect = pConnection.CreateCommand();
            cmdSelect.CommandText = String.Format("SELECT * FROM {0}", pTableName);

            using (SQLiteDataReader dataReader = cmdSelect.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    //string myReader = dataReader.GetString(0);
                    //Console.WriteLine(myReader);
                    Console.WriteLine(dataReader["ID"] + "\t" + dataReader["NAME"] + "\t" + dataReader["MESSAGE"]);
                }
            }
            pConnection.Close(); // Close connection after reading 
        }
    }
}
