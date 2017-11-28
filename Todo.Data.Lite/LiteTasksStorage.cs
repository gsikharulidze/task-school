using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Todo.Core;

namespace Todo.Data.Lite
{
    public class LiteTasksStorage : ITasksStore
    {
        //public string conncetionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public string conncetionstring = @"MyData.db";

        public Task Create(Task task)
        {
            using (var db = new LiteDatabase(conncetionstring))
            {
                var tasks = db.GetCollection<Task>("tasks");
                var newtask = new Task
                {
                    Name = task.Name,
                    Completed = task.Completed
                };

                tasks.Insert(task);
            }
            return task;
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"Tasks.db"))
            {
                var tasks = db.GetCollection<Task>("tasks");
                tasks.Delete(x=>x.Id == id);
            }
        }

        public Task Find(int id)
        {
            using (var db = new LiteDatabase(conncetionstring))
            {
                var tasks = db.GetCollection<Task>("Tasks");
                var results = tasks.Find(x => x.Id == id).FirstOrDefault();
                return results;
            }
        }

        public IEnumerable<Task> List()
        {

            using (var db = new LiteDatabase(conncetionstring))
            {
                var tasks = db.GetCollection<Task>("Tasks");
                var results = tasks.Find(x => x.Id > 0);
                return results.ToList();
            }
        }

        public void Update(int id, Task task)
        {
            using (var db = new LiteDatabase(conncetionstring))
            {
                var tasks = db.GetCollection<Task>("Tasks");
                var Uptask = tasks.Find(x=>x.Id==id).First();
                Uptask.Name = task.Name;
                Uptask.Completed = task.Completed;
                tasks.Update(Uptask);
                    
            }
        }
    }
}
