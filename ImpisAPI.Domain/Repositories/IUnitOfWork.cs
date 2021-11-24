using System.Threading;
using System.Threading.Tasks;

namespace ImpisAPI.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}