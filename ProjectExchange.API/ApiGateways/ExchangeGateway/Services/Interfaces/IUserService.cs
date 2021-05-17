using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface IUserService {
        Task<ResponseModel<User>> GetUser (string id);
        Task<ResponseModel<User>> UpdateUser (User model);
    }
}