using Potato.Domain.Models;

namespace Potato.Domain.Services.Abstractions
{
    public interface IVegetableRepository
    {
        Task AddAsync(Vegetable vegetable, CancellationToken cancellationToken = default);
    }
}
