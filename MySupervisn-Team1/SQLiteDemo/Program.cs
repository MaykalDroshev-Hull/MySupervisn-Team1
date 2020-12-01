using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1.SQLiteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqlite_connection;
            sqlite_connection = CreateConnection();
            CreateTable(sqlite_connection);
            InsertData(sqlite_connection);
            ReadData(sqlite_connection);
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_connection;
            // Create a new database connection:
            sqlite_connection = new SQLiteConnection("Data Source = database.db; Version = 3; New = True; Compress = True; ");
           // Open the connection:
         try
            {
                sqlite_connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, unable to connect to databse!");
            }
            return sqlite_connection;
        }

        static void CreateTable(SQLiteConnection pConnection)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
           string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
           sqlite_cmd = pConnection.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection pConnection)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = pConnection.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test Text ', 1); ";
           sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test1 Text1 ', 2); ";
           sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test2 Text2 ', 3); ";
           sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, Col2) VALUES('Test3 Text3 ', 3); ";
           sqlite_cmd.ExecuteNonQuery();
        }

        static void ReadData(SQLiteConnection pConnection)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = pConnection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            pConnection.Close();
        }
    }
}
