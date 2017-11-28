using System.Collections.Generic;
using Todo.Core;

namespace TodoLogic
{
    public class TasksLogic
    {
        private readonly ITasksStore storage;

        public TasksLogic(ITasksStore storage)
        {
            this.storage = storage;
        }

        public IEnumerable<Task> List()
        {
            return storage.List();
        }

        public void Create(Task task)
        {
            storage.Create(task);
        }

        public void Rename(string id, string name)
        {
            storage.Update(int.Parse(id), new Task { Name = name });
        }

        public void Delete(string id)
        {
            storage.Delete(int.Parse(id));
        }
    }
}
