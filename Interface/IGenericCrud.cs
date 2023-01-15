using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IGenericCrud<T> where T : class
    {
        #region Métodos ASíncronico
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
