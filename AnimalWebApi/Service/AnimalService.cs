using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;

namespace AnimalWebApi.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public AnimalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IList<Animal>> GetPagedAnimals(Pagination pagination)
        {
            return await _unitOfWork.AnimalRepository.GetAllAnimals(pagination.PageNumber, pagination.PageSize);
        }

        public async Task UpdateAnimal(Animal animal)
        { 
            _unitOfWork.AnimalRepository.Update(animal);

            await _unitOfWork.Save();
        }

        public async Task DeleteAnimal(string id)
        {
            await _unitOfWork.AnimalRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Insert(Animal animal)
        {
            await _unitOfWork.AnimalRepository.Insert(animal);
            await _unitOfWork.Save();
        }
    }
}
