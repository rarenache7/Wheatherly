using System.Collections.Generic;
using Weatherly.AppLogic.TodoLists.Queries.ExportTodos;

namespace Weatherly.AppLogic.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}