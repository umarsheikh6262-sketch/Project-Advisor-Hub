using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace semester_project
{
    public static class DatabaseHelper
    {
        // Added 'Initial Catalog=ProjectAdvisorHub' to specify the database
        private static readonly string ConnectionString = @"Data Source=Your Server Name;Initial Catalog=ProjectAdvisorHub;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandTimeout = 0;
                AddParameters(command, parameters);
                var dataTable = new DataTable();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }

        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandTimeout = 0;
                AddParameters(command, parameters);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandTimeout = 0;
                AddParameters(command, parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        private static void AddParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }
        }
    }
}