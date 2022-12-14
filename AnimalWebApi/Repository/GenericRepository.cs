using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AnimalWebApi.Data;
using AnimalWebApi.RepositoryInterface;

namespace AnimalWebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly AnimalDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(AnimalDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }


        public Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

           
            return Task.FromResult(query.AsNoTracking());
        }

        

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task Delete(string id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
