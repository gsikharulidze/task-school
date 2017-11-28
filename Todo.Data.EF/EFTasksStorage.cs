using System.Collections.Generic;
using System.Linq;
using Todo.Core;

namespace Todo.Data.EF
{
    public class EFTasksStorage : ITasksStore
    {
        public Task Create(Task task)
        {
            var context = new TasksContext();
            context.Tasks.Add(task);
            context.SaveChanges();
            return task;
        }

        public void Delete(int id)
        {
            var context = new TasksContext();
            var task = context.Tasks.First(x => x.Id == id);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }

        public Task Find(int id)
        {
            var context = new TasksContext();
            return context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Task> List()
        {
            var context = new TasksContext();
            return context.Tasks.ToList();
        }

        public void Update(int id, Task task)
        {
            var context = new TasksContext();
            var dbTask = context.Tasks.First(x => x.Id == id);
            dbTask.Name = task.Name;
            context.SaveChanges();
        }
    }
}
