using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace ToDoList
{
    class Program
    {

        static void Main(string[] args)
        {
            var db = new AppDbContext();
            var itemManager = new ListItemRepository(db);
            bool isContinue = true;

            Console.WriteLine("TODO LIST!");
            Console.WriteLine("Commands: add, del, complete, exit");
            itemManager.GetTasks();

            while (isContinue)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "add":
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        itemManager.AddTask(description);
                        itemManager.GetTasks();
                        continue;

                    case "del":
                        Console.Write("Enter ordinal number of task to delete: ");
                        int numberToDelete = Convert.ToInt32(Console.ReadLine());
                        itemManager.DeleteTask(numberToDelete);
                        itemManager.GetTasks();
                        continue;

                    case "complete":
                        Console.Write("Enter ordinal number of task to complete:");
                        int numberToComplete = Convert.ToInt32(Console.ReadLine());
                        itemManager.SetCompleted(numberToComplete);
                        itemManager.GetTasks();
                        continue;

                    case "exit":
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("Command in incorrect!");
                        Console.WriteLine("Commands: add, del, complete, exit");
                        continue;
                }
            }
        }
    }
}
