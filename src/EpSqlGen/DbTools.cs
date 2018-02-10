using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;
  
namespace EpSqlGen
{
    public class DbTools
    {

        //DB setup
        //https://stackoverflow.com/questions/9218847/how-do-i-handle-database-connections-with-dapper-in-net
        //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/obtaining-a-dbproviderfactory
        // Given a provider name and connection string, 
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.
        public static DbConnection CreateOpenedDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    /*
                    -- list providers
                    DataTable table = DbProviderFactories.GetFactoryClasses();
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            Console.WriteLine(row[column]);
                        }
                    }
                    */

                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);    // OracleClientFactory.Instance;

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                    SimpleLog.WriteException("****  Opening DB connection with connection failed. Provider: " + providerName);
                    SimpleLog.WriteException(ex.Message);
                    System.Environment.Exit((int)ExitCodes.DbConnectionFailed);
                }
            }
            // Return the connection.
            return connection;
        }

    }
}
