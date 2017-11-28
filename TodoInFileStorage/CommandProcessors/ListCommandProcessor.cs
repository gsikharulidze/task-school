using System;
using TodoLogic;

namespace TodoInFileStorage
{
    class ListCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine("\nid\tname");
            Console.WriteLine("================");
            foreach (var task in Program.Logics.List())
            {
                Console.WriteLine(task);
            }
            Console.WriteLine();
        }
    }
}
