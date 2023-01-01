using BSBookingQuery.Data.Context;
using BSBookingQuery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly BSBookingQueryDBContext _context;
        public GenericRepository(BSBookingQueryDBContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task Add(T entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
            }
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
