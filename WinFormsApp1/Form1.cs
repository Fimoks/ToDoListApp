using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ToDoListManager _manager = new ToDoListManager();

        public Form1()
        {
            InitializeComponent();

            // Устанавливаем свойство OwnerDrawFixed для ListBox
            listBoxTasks.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxTasks.DrawItem += ListBoxTasks_DrawItem;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var title = textBoxTitle.Text;
            if (!string.IsNullOrEmpty(title))
            {
                _manager.AddItem(title);
                textBoxTitle.Clear();
                UpdateTaskList();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem != null)
            {
                var selectedItem = listBoxTasks.SelectedItem.ToString();
                var id = int.Parse(selectedItem.Split(']')[0].Trim('[', ']'));
                _manager.RemoveItem(id);
                UpdateTaskList();
            }
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem != null)
            {
                var selectedItem = listBoxTasks.SelectedItem.ToString();
                var id = int.Parse(selectedItem.Split(']')[0].Trim('[', ']'));
                _manager.MarkAsCompleted(id);
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var item in _manager.GetItems())
            {
                listBoxTasks.Items.Add(item);
            }
        }

        private void ListBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            var item = listBoxTasks.Items[e.Index] as ToDoItem;

            if (item != null)
            {
                var brush = (item.IsCompleted) ? Brushes.Green : Brushes.Red;
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }
    }
}
