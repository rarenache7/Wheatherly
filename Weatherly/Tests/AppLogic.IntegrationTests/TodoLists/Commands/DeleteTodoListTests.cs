using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Weatherly.AppLogic.Common.Exceptions;
using Weatherly.AppLogic.TodoLists.Commands.CreateTodoList;
using Weatherly.AppLogic.TodoLists.Commands.DeleteTodoList;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand
            {
                Id = listId
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}