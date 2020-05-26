using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weatherly.Domain.Entities;

namespace Weatherly.AppLogic.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
