using System.Threading.Tasks;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public interface IUserService {
        Task<UserModel> GetUser (string id);
        Task<bool> UpdateUser (UpdateOnePropModel model);
        Task<bool> UpdateUser (UserModel model);
    }
}