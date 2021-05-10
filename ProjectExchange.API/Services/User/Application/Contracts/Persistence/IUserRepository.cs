using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.Persistence {

    //*İhtiyaca bağlı olarak User a özel
    public interface IUserRepository : IAsyncRepository<User> {

    }
}