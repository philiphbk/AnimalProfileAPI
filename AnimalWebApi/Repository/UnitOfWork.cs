using AnimalWebApi.Data;
using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace AnimalWebApi.Repository
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly AnimalDbContext _context;
        private IGenericRepository<Animal> _animals;

        public UnitOfWork(AnimalDbContext context, IGenericRepository<Animal> animals)
        {
            _context = context;
            _animals = animals;
        }


        public IGenericRepository<Animal> Animals => _animals ??= new GenericRepository<Animal>(_context);

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
