using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Weatherly.AppLogic.Common.Exceptions;
using Weatherly.AppLogic.TodoItems.Commands.CreateTodoItem;
using Weatherly.AppLogic.TodoItems.Commands.DeleteTodoItem;
using Weatherly.AppLogic.TodoLists.Commands.CreateTodoList;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
