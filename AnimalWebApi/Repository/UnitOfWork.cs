using AnimalWebApi.Data;
using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace AnimalWebApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AnimalDbContext _context;
        private IAnimalRepository _animalRepository;

        public UnitOfWork(AnimalDbContext context, IAnimalRepository animalRepository)
        {
            _context = context;
            _animalRepository = animalRepository;   
        }


        
        public IAnimalRepository AnimalRepository => _animalRepository ??= new AnimalRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
