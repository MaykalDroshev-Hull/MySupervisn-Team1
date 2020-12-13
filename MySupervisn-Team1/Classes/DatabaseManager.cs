using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySupervisn_Team1
{
    public class DatabaseManager
    {
        private string _TableName;
        private SQLiteConnection mConnection;

        public DatabaseManager(Message pMessage)
        {
            _TableName = "MESSAGES";

            InitiateDatabse(_TableName, null, pMessage);
        }
        public DatabaseManager(User pUser)
        {
            _TableName = "USERS";

            InitiateDatabse(_TableName, pUser, null);
        }

        // For MySQL
        public static SqlConnection CreateConnectionToDatabase()
        {
            SqlConnection connection = new SqlConnection();
            //   var path = Environment.CurrentDirectory + @"\DataBase\Users-2.0.mdf";
            //   connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\micha\Documents\GitHub\MySupervisn-Team1\MySupervisn-Team1\DataBase\Users-2.0.mdf;Integrated Security=True";
            return connection;
        }

        // For MySQLite
        private void InitiateDatabse(string pTableName, User pUser, Message pMessage)
        {
            CreateConnection(pTableName);
            CreateTable(pTableName);
            InsertData(pTableName, pUser, pMessage);
            ReadData(pTableName);
        }

        private void CreateConnection(string pTableName)
        {
            // Create a new database connection:
            string fileName = String.Format("Data Source = database{0}.db; Version = 3; New = True; Compress = True; ", pTableName);
            mConnection = new SQLiteConnection(fileName);
            // Open the connection:
            try
            {
                mConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, unable to connect to databse!");
            }
        }

        private void CreateTable(string pTableName)
        {
            // Create a table (drop if already exists)
            SQLiteCommand cmdDrop = mConnection.CreateCommand();
            cmdDrop.CommandText = "DROP TABLE IF EXISTS " + pTableName;
            cmdDrop.ExecuteNonQuery();

            SQLiteCommand cmdCreate = mConnection.CreateCommand();
            if (pTableName != "MESSAGES")
            {
                cmdCreate.CommandText = String.Format("CREATE TABLE {0} (ID INT, NAME VARCHAR(20), DATE INT, MESSAGE VARCHAR(20))", pTableName); // column's title string or number
            }
            else if (pTableName != "USERS")
            {
                cmdCreate.CommandText = String.Format("CREATE TABLE {0} (ID INT, NAME VARCHAR(20), ROLE VARCHAR(20)", pTableName); // column's title string or number
            }
            cmdCreate.ExecuteNonQuery();
        }

        private void InsertData(string pTableName, User pUser, Message pMessage)
        {
            using (SQLiteTransaction transaction = mConnection.BeginTransaction())
            {
                SQLiteCommand cmdInsert = mConnection.CreateCommand();

                if (pMessage != null)
                {
                    // Test how DATE output!!
                    cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, DATE, MESSAGE ) VALUES({1}, '{2}', '{3}', {4}, '{5}'); ", pTableName, pMessage.Sender.IdNumber, pMessage.Sender.Name, pMessage.DateTime, pMessage.Body);
                }
                else if (pUser != null)
                {
                    cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, ROLE) VALUES({1}, '{2}', '{3}', '{4}'); ", pTableName, pUser.IdNumber, pUser.Name, pUser.Role);
                }
                cmdInsert.ExecuteNonQuery();
                transaction.Commit();
            }
        }

        private void ReadData(string pTableName)
        {
            SQLiteCommand cmdSelect = mConnection.CreateCommand();
            cmdSelect.CommandText = String.Format("SELECT * FROM {0}", pTableName);

            using (SQLiteDataReader dataReader = cmdSelect.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    //string myReader = dataReader.GetString(0);
                    //Console.WriteLine(myReader);
                    Console.WriteLine(dataReader["ID"] + "\t" + dataReader["NAME"] + "\t" + dataReader["DATE"] + "\t" + dataReader["MESSAGE"]);
                }
            }
            mConnection.Close(); // Close connection after reading 
        }
    }
}
