using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class CommonEntityService : ICommonEntityService {

        private readonly HttpClient _client;
        public CommonEntityService (HttpClient client) {
            _client = client;
        }

        public async Task<ResponseModel<CommonEntity>> GetCommonEntity (string id) {
            try {
                var response = await _client.GetAsync ($"/api/v1/Admin/{id}");
                return await response.ReadContentAs<ResponseModel<CommonEntity>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<CommonEntity> () {
                    ReponseName = nameof (GetCommonEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }

        }
        public async Task<ResponseModel<CommonEntity>> CreateCommonEntity (CommonEntity model) {
            try {
                var response = await _client.PostAsJsonAsync<CommonEntity> ("/api/v1/Admin", model);
                return await response.ReadContentAs<ResponseModel<CommonEntity>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<CommonEntity> () {
                    ReponseName = nameof (CreateCommonEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }

        public async Task<ResponseModel<CommonEntity>> UpdateCommonEntity (CommonEntity model) {
            try {
                var response = await _client.PutAsJsonAsync<CommonEntity> ("/api/v1/Admin", model);
                return await response.ReadContentAs<ResponseModel<CommonEntity>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<CommonEntity> () {
                    ReponseName = nameof (UpdateCommonEntity) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }
    }
}