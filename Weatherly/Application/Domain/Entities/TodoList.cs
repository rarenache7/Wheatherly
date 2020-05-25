using System.Collections.Generic;
using Weatherly.Domain.Common;

namespace Weatherly.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public TodoList()
        {
            Items = new List<TodoItem>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public IList<TodoItem> Items { get; set; }
    }
}
