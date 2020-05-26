using Weatherly.AppLogic.Common.Mappings;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
