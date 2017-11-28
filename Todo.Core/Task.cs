namespace Todo.Core
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"\n{Id}\t{Name}\t{Completed}";
        }
    }
}
