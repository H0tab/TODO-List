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
            ListItem listItem = new ListItem { Description = description };
            _context.ListItems.Add(listItem);
            _context.SaveChanges();
        }

        public List<ListItem> GetTasks()
        {
            return _context.ListItems.ToList();
        }

        public void DeleteTask(int id)
        {
            _context.ListItems.Remove(new ListItem() { Id = id });
            _context.SaveChanges();
        }
    }
}
