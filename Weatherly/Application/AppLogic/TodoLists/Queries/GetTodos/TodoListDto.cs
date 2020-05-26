using System.Collections.Generic;
using Weatherly.AppLogic.Common.Mappings;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
