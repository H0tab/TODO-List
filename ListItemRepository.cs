using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList
{
    public class ListItemRepository
    {
        private readonly AppDbContext _context;

        public ListItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTask(string description)
        {
            if (description != null)
            {
                ListItem listItem = new ListItem { Description = description, IsCompleted = false };
                _context.ListItems.Add(listItem);
                _context.Entry(listItem).State = EntityState.Added;
                _context.SaveChanges();
                Console.Clear();
                return;
            }
            Console.WriteLine("Enter description!");
        }

        public void GetTasks()
        {
            var items = _context.ListItems.ToList();
            int number = 1;

            foreach (var item in items)
            {
                item.OrdinalNumber = number++;
                _context.SaveChanges();

                Console.WriteLine($"({item.OrdinalNumber}) {item.Description} - {item.IsCompleted}");
            }
        }

        public void DeleteTask(int ordinalNumber)
        {
            var item = _context.ListItems.FirstOrDefault(x => x.OrdinalNumber == ordinalNumber);
            if (item != null)
            {
                _context.ListItems.Remove(item);
                _context.SaveChanges();
                Console.Clear();
                return;
            }
            Console.WriteLine("There is no such object!");
        }

        public void SetCompleted(int ordinalNumber)
        {
            var item = _context.ListItems.FirstOrDefault(x => x.OrdinalNumber == ordinalNumber);
            if (item != null)
            {
                item.IsCompleted = item.IsCompleted == true ? false : true;
                _context.SaveChanges();

                Console.Clear();

                return;
            }
            Console.WriteLine("There is no such object!");
        }
    }
}
