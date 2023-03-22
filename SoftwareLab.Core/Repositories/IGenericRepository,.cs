using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLab.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>>GetAllAsync();
        Task<IReadOnlyList<T>>GetPageResponseAsync(int pageIndex, int pageSize);
        Task<T> AddAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task<T> DeleteAsync(T Entity);

    }
}
