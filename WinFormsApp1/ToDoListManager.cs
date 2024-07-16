using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public class ToDoListManager
    {
        private List<ToDoItem> _items = new List<ToDoItem>();
        private int _nextId = 1;

        public void AddItem(string title)
        {
            var item = new ToDoItem(_nextId++, title);
            _items.Add(item);
        }

        public void RemoveItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void MarkAsCompleted(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsCompleted = true;
            }
        }

        public List<ToDoItem> GetItems()
        {
            return _items;
        }
    }
}
