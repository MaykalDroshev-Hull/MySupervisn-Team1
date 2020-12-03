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

        private int _Id;
        private string _Name;
        private DateTime _Date;
        private List<string> _Messages;



        public DatabaseManager(string pTableName, int pId, string pName, DateTime pDate, List<string> pMessage)
        {
            SQLiteConnection connection;

            _TableName = pTableName;

            _Id = pId;
            _Name = pName;
            _Date = pDate;
            _Messages = pMessage;
  
            connection = CreateConnection(_TableName);
            CreateTable(connection, _TableName);
            InsertData(connection, _TableName, _Id, _Name, _Date, _Messages);
            ReadData(connection, _TableName);
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
        cmdCreate.CommandText = String.Format("CREATE TABLE {0} (ID INT, NAME VARCHAR(20), MESSAGE VARCHAR(20))", pTableName); // column's title string or number
        cmdCreate.ExecuteNonQuery();
    }

    private void InsertData(SQLiteConnection pConnection, string pTableName, int pId, string pName, DateTime pDate, List<string> pMessages)
    {
        using (SQLiteTransaction transaction = pConnection.BeginTransaction())
        {
            SQLiteCommand cmdInsert = pConnection.CreateCommand();

            foreach (string message in pMessages)
            {
                // Test how DATE output!!
                cmdInsert.CommandText = String.Format("INSERT INTO {0} (ID, NAME, DATE, MESSAGE ) VALUES({1}, '{2}', '{3}', {4}, '{5}'); ", pTableName, pId, pName, pDate, message);
                cmdInsert.ExecuteNonQuery();
            }
            /*
             * Do something similar only for dates??
            foreach (DateTime date in pDate)
            {
                cmdInsert.CommandText = String.Format("INSERT INTO {0} (DATE) VALUES({1}); ", pDate);
                cmdInsert.ExecuteNonQuery();
            }
            */
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
