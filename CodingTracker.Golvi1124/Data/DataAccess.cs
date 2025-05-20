using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker.Golvi1124.Data;

internal class DataAccess
{
    private string ConnectionString;
    public DataAccess(string connectionString)
    {
        ConnectionString = connectionString;
    }
    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS records (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DateStart TEXT NOT NULL,
                DateEnd TEXT NOT NULL
            )";

            connection.Execute(createTableQuery);
        }
    }
}