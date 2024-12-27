using Potato.Domain.Models;
using System.Linq.Expressions;

namespace Potato.Domain.Services.Abstractions
{
    public interface IVegetableRepository
    {
        Task AddAsync(Vegetable vegetable, CancellationToken cancellationToken = default);

        Task<IEnumerable<Vegetable>> GetAsync(Expression<Func<Vegetable, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
