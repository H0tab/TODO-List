using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
