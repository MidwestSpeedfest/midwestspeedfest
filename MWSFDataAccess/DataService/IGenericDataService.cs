using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSFDataAccess.DataService
{
    internal interface IGenericDataService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteRowAsync(ulong id);
        Task<T> GetAsync(ulong id);
        Task<int> SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T t);
        Task InsertAsync(T t);
    }
}
