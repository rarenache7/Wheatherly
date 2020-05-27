using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Weatherly.AppLogic.TodoLists.Queries.GetTodos;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.IntegrationTests.TodoLists.Queries
{
    using static Testing;

    public class GetTodosTests : TestBase
    {
        [Test]
        public async Task ShouldReturnPriorityLevels()
        {
            var query = new GetTodosQuery();

            var result = await SendAsync(query);

            result.PriorityLevels.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldReturnAllListsAndItems()
        {
            await AddAsync(new TodoList
            {
                Title = "Shopping",
                Items =
                {
                    new TodoItem { Title = "Turbocharger", Done = true },
                    new TodoItem { Title = "Intercooler", Done = true },
                    new TodoItem { Title = "Custom Wastegate", Done = true },
                    new TodoItem { Title = "T25 Flange" },
                    new TodoItem { Title = "Downpipes" },
                    new TodoItem { Title = "ECU remap" },
                    new TodoItem { Title = "Turbo Pressure gauge" }
                }
            });

            var query = new GetTodosQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(1);
            result.Lists.First().Items.Should().HaveCount(7);
        }
    }
}
