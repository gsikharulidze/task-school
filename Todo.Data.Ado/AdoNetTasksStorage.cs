using System;
using System.Collections.Generic;
using Todo.Core;

namespace Todo.Data.Ado
{
    public class AdoNetTasksStorage : ITasksStore
    {
        public Task Create(Task task)
        {
            new MySqlCommand($"insert into Tasks (Name) values ('{ task.Name }')").NonQuery();
            return task;
        }

        public void Delete(int id)
        {
            new MySqlCommand($"delete from Tasks where Id = {id}").NonQuery();
        }

        public Task Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> List()
        {
            return new MySqlCommand("select * from Tasks").Query(reader => new Task
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()
            });
        }

        public void Update(int id, Task task)
        {
            new MySqlCommand($"update Tasks set Name = '{ task.Name }' where Id = {id}").NonQuery();
        }
    }
}
