using System.Data.Entity;
using Todo.Core;

namespace Todo.Data.EF
{
    public class TasksContext : DbContext
    {
        public TasksContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        { }

        public DbSet<Task> Tasks { get; set; }
    }
}
