using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySupervisn_Team1
{
    public class DatabaseManager
    {
        private string _TableName;

        public DatabaseManager(Message pMessage)
        {
            _TableName = "MESSAGES";

            InitiateDatabse(_TableName,null, pMessage);
        }
        public DatabaseManager(User pUser)
        {
            _TableName = "USERS";
            
            InitiateDatabse(_TableName, pUser, null );
        }
 
        private void InitiateDatabse(string pTableName, User pUser, Message pMessage)
        {
            SQLiteConnection connection = CreateConnection(pTableName);
            CreateTable(connection, pTableName);
            InsertData(connection, pTableName, pUser, pMessage);
            ReadData(connection, pTableName);
        }

        private SQLiteConnection CreateConnection(string pTableName)
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

    private void CreateTable(SQLiteConnection pConnection, string pTableName)
    {
        // Create a table (drop if already exists)
        SQLiteCommand cmdDrop = pConnection.CreateCommand();
        cmdDrop.CommandText = "DROP TABLE IF EXISTS " + pTableName;
        cmdDrop.ExecuteNonQuery();

        SQLiteCommand cmdCreate = pConnection.CreateCommand();
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

    private void InsertData(SQLiteConnection pConnection, string pTableName, User pUser, Message pMessage)
    {
        using (SQLiteTransaction transaction = pConnection.BeginTransaction())
        {
            SQLiteCommand cmdInsert = pConnection.CreateCommand();

                if (pMessage != null) {
                    // Test how DATE output!!
                    cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, DATE, MESSAGE ) VALUES({1}, '{2}', '{3}', {4}, '{5}'); ", pTableName, pMessage.Sender.IdNumber, pMessage.Sender.Name, pMessage.DateTime, pMessage.Caption);
                }
                else if (pUser != null)
                {
                    cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, ROLE) VALUES({1}, '{2}', '{3}', '{4}'); ", pTableName, pUser.IdNumber, pUser.Name, pUser.Role);
                }
                cmdInsert.ExecuteNonQuery();
                transaction.Commit();
        }
    }

    private void ReadData(SQLiteConnection pConnection, string pTableName)
    {
        SQLiteCommand cmdSelect = pConnection.CreateCommand();
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
        pConnection.Close(); // Close connection after reading 
    }
}
}
