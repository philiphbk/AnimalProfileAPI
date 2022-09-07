using AnimalWebApi.Data;
using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;

namespace AnimalWebApi.Repository
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(AnimalDbContext context) : base(context)
        { }

        public async Task<IList<Animal>> GetAllAnimals(int pageNumber, int pageSize)
        {
            var animals = await GetAll();
            var orderAnimals = animals.OrderBy(x => x.PetName);

            return PageList<Animal>.ToPageList(orderAnimals, pageNumber, pageSize);
        }

    } 
}
