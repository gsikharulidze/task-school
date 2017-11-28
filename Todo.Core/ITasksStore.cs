using System.Collections.Generic;

namespace Todo.Core
{
    public interface ITasksStore
    {
        IEnumerable<Task> List();
        Task Find(int id);
        Task Create(Task task);
        void Delete(int id);
        void Update(int id, Task task);
    }
}
