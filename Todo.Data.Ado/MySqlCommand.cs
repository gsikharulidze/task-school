using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Todo.Data.Ado
{
    public class MySqlCommand
    {
        private readonly string commandText;

        public MySqlCommand(string commandText)
        {
            this.commandText = commandText;
        }

        public List<TEntity> Query<TEntity>(Func<SqlDataReader, TEntity> logic)
        {
            var entities = new List<TEntity>();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand(commandText, connection))
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    entities.Add(logic(reader));
                }
            }

            return entities;
        }

        public void NonQuery()
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand(commandText, connection))
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
