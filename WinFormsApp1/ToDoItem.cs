using System;

namespace WinFormsApp1
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public ToDoItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} - {(IsCompleted ? "Completed" : "Pending")} (Created: {CreatedAt})";
        }
    }
}
