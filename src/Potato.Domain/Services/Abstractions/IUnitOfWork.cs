namespace Potato.Domain.Services.Abstractions
{
    public interface IUnitOfWork
    {
        IVegetableRepository VegetablesRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
