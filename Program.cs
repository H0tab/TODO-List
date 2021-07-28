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
            itemManager.GetTasks();

            Console.WriteLine("Commands: add, del, complete, exit");

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
                        Console.Clear();
                        itemManager.GetTasks();
                        continue;

                    case "del":
                        Console.Write("Enter task ID to delete: ");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());
                        itemManager.DeleteTask(idToDelete);
                        Console.Clear();
                        itemManager.GetTasks();
                        continue;

                    case "complete":
                        Console.Write("Enter task ID to complete:");
                        int idToComplete = Convert.ToInt32(Console.ReadLine());
                        itemManager.SetCompleted(idToComplete);
                        Console.Clear();
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

            Console.ReadLine();
        }
    }
}
