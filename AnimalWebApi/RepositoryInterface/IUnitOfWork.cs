using AnimalWebApi.Entities;

namespace AnimalWebApi.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository AnimalRepository { get; }
        Task Save();
    }
}
