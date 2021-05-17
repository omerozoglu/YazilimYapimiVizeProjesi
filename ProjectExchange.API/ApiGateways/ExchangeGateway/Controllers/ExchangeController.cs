using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Models.OperationModels;
using ExchangeGateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeGateway.Controllers {
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class ExchangeController : ControllerBase {

        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICommonEntityService _commonEntityService;

        public ExchangeController (IUserService userService, IProductService productService, ICommonEntityService commonEntityService) {
            _userService = userService;
            _productService = productService;
            _commonEntityService = commonEntityService;
        }

        [HttpPut]
        [Route ("TakeOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseModel<User>>> TakeOperation (TakerModel model) {
            var response = new ResponseModel<User> () { ReponseName = nameof (SellOperation) };

            double _price = 0, _weight = 0, totalprice = 0;

            var userResponse = await _userService.GetUser (model.UserId);
            var user = userResponse.Content.Find (p => p.Id == model.UserId);
            var productWeight = model.Weight;

            var productResponse = await _productService.GetProduct (model.ProductId);
            var product = productResponse.Content.Find (p => true);

            var credit = user.Credit;

            var tempProductModel = new Product () { Name = product.Name };
            var productListResponse = await _productService.GetProductsByName (tempProductModel);
            var productList = productListResponse.Content;
            var currentProducList = new List<Product> ();

            #region Fiyat hesaplayıcı
            foreach (var item in productList) {
                currentProducList.Add (item);
                _price += item.UnitPrice;
                _weight += item.Weight;
                if (_weight >= productWeight) {
                    totalprice = _price * _weight;
                    break;
                }
            }
            if (totalprice > credit) {
                response.Message = "Operation Faild";
                response.Status = ResponseType.Error;
                return response;
            }
            #endregion
            //*son item e kadar ağırlıkları 0 yap ve sil son item durumua göre azalt yada sil

            #region Ürün ağırlığı güncelleme
            double balance = productWeight;
            foreach (var item in currentProducList) {

                if (item.Weight >= balance) {
                    item.Weight -= balance;
                    await _productService.UpdateProduct (item);
                } else {
                    balance -= item.Weight;
                    item.Weight = 0;
                    //* 0 olanı sil
                }
            }
            #endregion

            #region Kullanıcı bakiye güncelleme
            user.Credit -= totalprice;
            #endregion

            #region Kullanıcı products güncelleme
            var IsThereProduct = false;
            foreach (var userProductId in user.Products) {
                var userProductResponse = await _productService.GetProduct (userProductId);
                var userProduct = userProductResponse.Content.Find (p => true);
                if (userProduct.Name == product.Name) {
                    userProduct.Weight += productWeight;
                    await _productService.UpdateProduct (userProduct);
                    IsThereProduct = false;
                    break;
                } else {
                    IsThereProduct = true;
                }
            }
            if (user.Products.Count == 0 || IsThereProduct) {
                var userNewProductResponse = await _productService.CreateProduct (new Product () { Id = null, Name = product.Name, ImgUrl = product.ImgUrl, Weight = productWeight, UnitPrice = 0 });
                var userNewProduct = userNewProductResponse.Content.Find (p => true);
                user.Products.Add (userNewProduct.Id);
            }

            await _userService.UpdateUser (user);
            #endregion
            response.Message = "Operation successfully";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPut]
        [Route ("SellOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<User>>> SellOperation (SellerModel model) {
            var response = new ResponseModel<User> () { ReponseName = nameof (SellOperation) };

            double totalprice = 0;

            var userResponse = await _userService.GetUser (model.UserId);
            var user = userResponse.Content.Find (p => true);

            var productResponse = await _productService.GetProduct (model.ProductId);
            var product = productResponse.Content.Find (p => true);

            var productWeight = model.Weight;
            var productUnitPrice = model.UnitPrice;
            //* Toplam satış değeri hesaplama
            totalprice = productWeight * productUnitPrice;

            //* Ürün kilo güncelleme
            product.Weight -= productWeight;
            if (product.Weight <= 0) { }
            //* silme işlemi

            //*kullanıcıya ait productı güncelliyor
            await _productService.UpdateProduct (product);
            //* Sisteme yeni fiyatlı ürünü ekliyor
            product.Weight = model.Weight;
            product.UnitPrice = productUnitPrice;
            await _productService.CreateProduct (product);

            //* Kullanıcı bakiye güncelleme
            user.Credit += totalprice;
            await _userService.UpdateUser (user);

            response.Message = "Operation successfully";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPost]
        [Route ("ProductLoadOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseModel<Admin>>> ProductLoadOperation (LoadProductModel model) {
            var response = new ResponseModel<Admin> () { ReponseName = nameof (MoneyDepositOperation), Content = new List<Admin> () { } };
            var product = new Product () { Id = null, Name = model.ProductName, Weight = model.ProductWeight, ImgUrl = model.ProductImgUrl, UnitPrice = 0 };
            var newProductResponse = await _productService.CreateProduct (product);
            var newProduct = newProductResponse.Content.Find (p => true);
            var commonEntity = new Admin () { Id = null, UserId = model.UserId, ProductId = newProduct.Id, Type = "LoadProduct", Status = "Pending" };
            //* Admin onayına gitmesi için istek oluşturuldu
            var commonEntityResponse = await _commonEntityService.CreateCommonEntity (commonEntity);
            commonEntity = commonEntityResponse.Content.Find (p => true);

            response.Content.Add (commonEntity);
            response.Message = "Operation successfully submitted to admin for approval ";
            response.Status = ResponseType.Success;

            return response;
        }

        [HttpPost]
        [Route ("MoneyDepositOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<Admin>>> MoneyDepositOperation (MoneyDepositModel model) {
            var response = new ResponseModel<Admin> () { ReponseName = nameof (MoneyDepositOperation), Content = new List<Admin> () { } };

            var commonEntity = new Admin () { Id = null, UserId = model.UserId, Deposite = model.Deposite, ProductId = null, Type = "MoneyDeposit", Status = "Pending" };
            //* Admin onayına gitmesi için istek oluşturuldu
            var commonEntityResponse = await _commonEntityService.CreateCommonEntity (commonEntity);

            commonEntity = commonEntityResponse.Content.Find (p => true);

            response.Content.Add (commonEntity);
            response.Message = "Operation successfully submitted to admin for approval ";
            response.Status = ResponseType.Success;

            return response;
        }

        [HttpPut]
        [Route ("AdminConfirmOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<Admin>>> AdminConfirmOperation (Admin model) {
            var response = new ResponseModel<Admin> () { ReponseName = nameof (AdminConfirmOperation) + "// " + model.Type, Content = new List<Admin> () { } };

            if (model.Type == "LoadProduct") {
                #region Denied
                if (model.Status == "Denied") {
                    //* User Bilgilendirme::: Durum başarısız daha sonra yapacağım product sil
                    response.Message = "Operation failed";
                    response.Status = ResponseType.Error;
                    return response;
                }
                #endregion

                #region Approved 

                var userResponse = await _userService.GetUser (model.UserId);
                var user = userResponse.Content.Find (p => true);
                var productResponse = await _productService.GetProduct (model.ProductId);
                var product = productResponse.Content.Find (p => true);
                var IsThereProduct = true;

                foreach (var item in user.Products) {
                    var _productResponse = await _productService.GetProduct (item);
                    var _product = _productResponse.Content.Find (p => true);
                    if (_product.Name == product.Name) {
                        _product.Weight += product.Weight;
                        await _productService.UpdateProduct (_product);
                        IsThereProduct = false;
                        break;
                    } else {
                        IsThereProduct = true;
                    }
                }
                if (IsThereProduct) {
                    user.Products.Add (product.Id);
                }
                await _userService.UpdateUser (user);

                model.Status = "Approved";
                await _commonEntityService.UpdateCommonEntity (model);

                #endregion

            } else if (model.Type == "MoneyDeposit") {
                #region Denied
                if (model.Status == "Denied") {
                    //* User Bilgilendirme::: Durum başarısız daha sonra yapacağım
                    response.Message = "Operation failed";
                    response.Status = ResponseType.Error;
                    return response;
                }
                #endregion

                #region Approved 
                var commonEntityResponse = await _commonEntityService.GetCommonEntity (model.Id);
                var commonEntity = commonEntityResponse.Content.Find (p => p.UserId == model.UserId);
                var userResponse = await _userService.GetUser (commonEntity.UserId);
                var user = userResponse.Content.Find (p => p.Id == model.UserId);
                user.Credit += commonEntity.Deposite;
                await _userService.UpdateUser (user);
                commonEntity.Status = "Approved";
                await _commonEntityService.UpdateCommonEntity (commonEntity);

                #endregion

            }
            response.Message = "Operation successfully submitted to admin for approval ";
            response.Status = ResponseType.Success;
            return response;
        }

    }
}