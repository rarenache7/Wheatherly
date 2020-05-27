using System.Globalization;
using CsvHelper.Configuration;
using Weatherly.AppLogic.TodoLists.Queries.ExportTodos;

namespace Weatherly.Infrastructure.Files.Maps
{
    public sealed class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}