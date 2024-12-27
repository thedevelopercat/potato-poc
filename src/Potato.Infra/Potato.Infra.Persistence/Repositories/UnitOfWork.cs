using Microsoft.Extensions.Logging;
using Potato.Domain.Services.Abstractions;
using Potato.Infra.Persistence.Data;

namespace Potato.Infra.Persistence.Repositories
{
    internal sealed class UnitOfWork(IVegetableRepository vegetablesRepository, VegetablesContext context, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        public IVegetableRepository VegetablesRepository { get; } = vegetablesRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error saving changes to database.");
            }
        }
    }
}
