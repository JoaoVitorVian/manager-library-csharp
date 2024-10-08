using Manager.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        
        Task<T> Update(T obj);
        
        Task Remove(Guid id);
        
        Task<T> Get(Guid id);

        Task<List<T>> GetAll();
    }
}