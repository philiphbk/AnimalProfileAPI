using AnimalWebApi.Entities;

namespace AnimalWebApi.RepositoryInterface
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<IList<Animal>> GetAllAnimals( int pageNumber, int pageSize);
    }
}
