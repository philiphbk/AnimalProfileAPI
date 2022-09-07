using AnimalWebApi.Entities;

namespace AnimalWebApi.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Animal> Animals { get; }
        Task Save();
    }
}
