using System.Threading.Tasks;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services.Interfaces {
    public interface ICurrencyService {
        Task<double> RequestCurrencyAPI (CurrencyModel model);
    }
}