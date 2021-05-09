using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Contracts.Persistence {
    public interface IAsyncRepository<T> where T : EntityBase {
        //* IAsyncRepository servisde oluşacak olası tüm Repositorylerin sahip olması gereken metodları taşır.
        Task<IReadOnlyList<T>> GetAllAsync ();
        Task<T> GetByIdAsync (string id);
        Task<T> AddAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task<T> DeleteAsync (T entity);
        Task<T> DeleteAsync (string id);
    }
}