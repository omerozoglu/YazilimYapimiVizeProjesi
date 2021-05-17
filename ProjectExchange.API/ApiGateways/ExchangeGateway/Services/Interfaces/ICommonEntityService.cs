using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface ICommonEntityService {
        Task<ResponseModel<Admin>> GetCommonEntity (string id);
        Task<ResponseModel<Admin>> UpdateCommonEntity (Admin model);
        Task<ResponseModel<Admin>> CreateCommonEntity (Admin model);
    }
}