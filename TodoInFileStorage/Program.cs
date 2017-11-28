using System;
using System.Collections.Generic;
using Todo.Data.Ado;
using Todo.Data.Lite;
using TodoLogic;

namespace TodoInFileStorage
{
    class Program
    {
        public static TasksLogic Logics = new TasksLogic(new LiteTasksStorage());

        static IDictionary<string, CommandProcessor> commands = new Dictionary<string, CommandProcessor>
        {
            { "list", new ListCommandProcessor() },
            { "create", new CreateCommandProcessor() },
            { "delete", new DeleteCommandProcessor() },
            { "rename",new RenameCommandProcessor()}
        };

        static void Main(string[] args)
        {
            var command = WaitForNextCommand();
            while (command != "exit")
            {
                ProcessCommand(command);

                command = WaitForNextCommand();
            }
        }

        private static string WaitForNextCommand()
        {
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        private static void ProcessCommand(string command)
        {
            if (commands.ContainsKey(command))
                commands[command].Process();
            else
                Console.WriteLine("command not recognized");
        }
    }
}
