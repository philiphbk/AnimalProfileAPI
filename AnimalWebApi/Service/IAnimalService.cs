using AnimalWebApi.Entities;

namespace AnimalWebApi.Service
{
    public interface IAnimalService
    {
        Task<IList<Animal>> GetPagedAnimals(Pagination pagination); 
        Task UpdateAnimal(Animal animal);

        Task DeleteAnimal(string id);

        Task Insert(Animal animal);

    }
}
