using Microsoft.EntityFrameworkCore;
using SoftwareLab.Core.Repositories;
using SoftwareLab.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLab.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) { 
            
            this._context = context;
        
        }
        public async Task<T> AddAsync(T Entity)
        {
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public Task<T> DeleteAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<IReadOnlyList<T>> GetPageResponseAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
