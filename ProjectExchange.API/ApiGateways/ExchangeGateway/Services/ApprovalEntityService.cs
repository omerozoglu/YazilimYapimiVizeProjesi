using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class ApprovalEntityService<T> : IAprpovalEntityService<T> where T : ApprovalEntityBase {

        private readonly HttpClient _client;
        public ApprovalEntityService (HttpClient client) {
            _client = client;
        }

        public async Task<ResponseModel<T>> GetApprovalEntity (string id) {
            try {
                var response = await _client.GetAsync ($"/api/v1/{typeof(T).Name+"/"+id}");
                return await response.ReadContentAs<ResponseModel<T>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<T> () {
                    ReponseName = nameof (GetApprovalEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseStatus.Error,
                    Content = null
                };
                return response;
            }

        }
        public async Task<ResponseModel<T>> CreateApprovalEntity (T model) {
            try {
                var response = await _client.PostAsJsonAsync<T> ($"/api/v1/{typeof(T).Name}", model);
                return await response.ReadContentAs<ResponseModel<T>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<T> () {
                    ReponseName = nameof (CreateApprovalEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseStatus.Error,
                    Content = null
                };
                return response;
            }
        }
        public async Task<ResponseModel<T>> UpdateApprovalEntity (T model) {
            try {
                var response = await _client.PutAsJsonAsync<T> ($"/api/v1/{typeof(T).Name}", model);
                return await response.ReadContentAs<ResponseModel<T>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<T> () {
                    ReponseName = nameof (UpdateApprovalEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseStatus.Error,
                    Content = null
                };
                return response;
            }
        }
    }
}