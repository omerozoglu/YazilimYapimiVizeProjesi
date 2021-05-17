using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace ExchangeGateway.Extensions {
    public static class HttpClientExtensions {
        public static async Task<T> ReadContentAs<T> (this HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException ($"Something went wrong calling the API: {response.ReasonPhrase}");

            string dataAsString = await response.Content.ReadAsStringAsync ();
            return JsonConvert.DeserializeObject<T> (dataAsString);
        }

        public static Task<HttpResponseMessage> PostAsJsonAsync<T> (this HttpClient httpClient, string url, T data) {
            var dataAsString = JsonSerializer.Serialize (data);
            var content = new StringContent (dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

            return httpClient.PostAsync (url, content);
        }

        public static Task<HttpResponseMessage> PutAsJsonAsync<T> (this HttpClient httpClient, string url, T data) {
            var dataAsString = JsonSerializer.Serialize (data);
            var content = new StringContent (dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

            return httpClient.PutAsync (url, content);
        }
    }
}