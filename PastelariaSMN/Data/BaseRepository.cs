using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using PastelariaSMN.Infra;

namespace PastelariaSMN.Data
{
    public abstract class BaseRepository 
    {
        public BaseRepository(Connection conn) 
        {
            this.conn = conn;
        }

        private Connection conn;
        private SqlCommand command;

        protected void SetProcedure(object procedureName)
        {
            command = new SqlCommand(procedureName.ToString(), conn.connection);
            command.CommandType = CommandType.StoredProcedure;
        }
        protected void AddParameter(string name, object value)
        {
            command.Parameters.AddWithValue("@" + name, value);
        }

        protected int ExecuteNonQuery()
        {
            conn.OpenConnection();
            var retorno = command.ExecuteNonQuery();
            // CloseConnection();
            return retorno;
        }

        protected SqlDataReader ExecuteReader()
        {
            conn.OpenConnection();
            var reader = command.ExecuteReader();
            // CloseConnection();
            return reader;
        
        }
}
}
