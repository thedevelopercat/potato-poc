using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Potato.Domain.Models;
using Potato.Domain.Services.Abstractions;
using Potato.Infra.Persistence.Data;

namespace Potato.Infra.Persistence.Repositories
{
    internal sealed class VegetablesRepository(VegetablesContext context) : IVegetableRepository
    {
        public async Task AddAsync(Vegetable vegetable, CancellationToken cancellationToken = default)
        {
            if (vegetable is null)
            {
                throw new ArgumentNullException(nameof(vegetable));
            }

            await context.Vegetables.AddAsync(vegetable, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Vegetable>> GetAsync(Expression<Func<Vegetable, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await context.Vegetables
                .AsNoTracking()
                .TagWithCallSite()
                .Where(predicate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
