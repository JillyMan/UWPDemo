using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsDataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task Insert(T item);
    }
}
