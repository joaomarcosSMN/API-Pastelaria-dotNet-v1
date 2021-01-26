using System;
using System.Data;
using System.Data.SqlClient;

namespace PastelariaSMN.Infra
{
    public class Connection : IDisposable
    {
        // public SqlConnection connection { get; private set; }
        public readonly SqlConnection connection;

        public Connection()
        {
            connection = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;");
        }

        public void OpenConnection() {
            if(connection.State == ConnectionState.Closed)
                connection.Open();
        }
        // public void CloseConnection() {
        //     if(connection.State == ConnectionState.Open)
        //         connection.Close();
        // }
        
        public void Dispose()
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}