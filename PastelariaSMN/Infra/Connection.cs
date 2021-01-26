using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PastelariaSMN.Infra
{
    public class Connection : IDisposable
    {
        public readonly SqlConnection connection;

        public Connection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
        }

        public void OpenConnection() {
            if(connection.State == ConnectionState.Closed)
                connection.Open();
        }
        
        public void Dispose()
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}