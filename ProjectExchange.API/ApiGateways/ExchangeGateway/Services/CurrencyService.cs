using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class CurrencyService : ICurrencyService {
        public readonly HttpClient _client;
        public CurrencyService (HttpClient client) {
            _client = client;
        }
        public async Task<double> RequestCurrencyAPI (CurrencyModel model) {
            Console.WriteLine ("==================================");
            HttpRequestMessage requestMessage = new HttpRequestMessage (HttpMethod.Get, "https://api.exchangerate.host/convert?from=" + model.From + "&to=" + model.To + "&amount=" + model.Amount);
            var response = await _client.SendAsync (requestMessage);
            return double.Parse (response.ReadContentAs<CurrencyModel> ().Result.result);
        }
    }
}