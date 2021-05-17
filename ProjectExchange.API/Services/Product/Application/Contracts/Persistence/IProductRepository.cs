using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.Persistence {

    //*İhtiyaca bağlı olarak Product a özel
    public interface IProductRepository : IAsyncRepository<Product> {
        Task<IReadOnlyList<Product>> GetAllGroupedAsync ();
    }
}