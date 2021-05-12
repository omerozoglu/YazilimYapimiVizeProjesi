using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Services;
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
        public async Task<ActionResult<bool>> TakeOperation (TakerModel model) {

            double _price = 0, _weight = 0, totalprice = 0;

            var user = await _userService.GetUser (model.UserId);
            var productWeight = model.Weight;
            var product = await _productService.GetProduct (model.ProductId);
            var credit = user.Credit;

            var tempProductModel = new ProductModel () { Name = product.Name };
            var productList = await _productService.GetProductsByName (tempProductModel);

            var currentProducList = new List<ProductModel> ();

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
            if (totalprice > credit)
                return false;
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
                var userProduct = await _productService.GetProduct (userProductId);
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
                var userNewProductId = await _productService.CreateProduct (new ProductModel () { Id = null, Name = product.Name, ImgUrl = product.ImgUrl, Weight = productWeight, UnitPrice = 0 });
                user.Products.Add (userNewProductId.Id);
            }

            await _userService.UpdateUser (user);
            #endregion

            return true;
        }

        [HttpPut]
        [Route ("SellOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> SellOperation (SellerModel model) {
            double totalprice = 0;

            var user = await _userService.GetUser (model.UserId);

            var product = await _productService.GetProduct (model.ProductId);
            var productWeight = model.Weight;
            var productUnitPrice = model.UnitPrice;
            //* Toplam satış değeri hesaplama
            totalprice = productWeight * productUnitPrice;

            //* Ürün kilo güncelleme
            product.Weight -= productWeight;
            if (product.Weight <= 0) { }
            //* silme işlemi

            await _productService.UpdateProduct (product);

            //* Kullanıcı bakiye güncelleme
            user.Credit += totalprice;
            await _userService.UpdateUser (user);

            return true;
        }

        [HttpPost]
        [Route ("ProductLoadOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ProductLoadOperation (LoadProductModel model) {
            var product = new ProductModel () { Id = null, Name = model.ProductName, Weight = model.ProductWeight, ImgUrl = model.ProductImgUrl, UnitPrice = 0 };
            var newProduct = await _productService.CreateProduct (product);
            var commonEntity = new CommonEntityModel () { Id = null, UserId = model.UserId, ProductId = newProduct.Id, Type = "Load Operation", Status = "Pending" };
            //* Admin onayına gitmesi için istek oluşturuldu
            await _commonEntityService.CreateCommonEntity (commonEntity);
            return true;
        }

        [HttpPost]
        [Route ("MoneyDepositOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> MoneyDepositOperation (MoneyDepositModel model) {
            var commonEntity = new CommonEntityModel () { Id = null, UserId = model.UserId, Deposite = model.Deposite, ProductId = null, Type = "Deposit Money Operation", Status = "Pending" };
            //* Admin onayına gitmesi için istek oluşturuldu
            await _commonEntityService.CreateCommonEntity (commonEntity);
            return true;
        }

        [HttpPut]
        [Route ("ProductLoadOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> UpdateProductLoadOperation (CommonEntityModel model) {
            if (model.Status == "Denied") {
                //* User Bilgilendirme::: Durum başarısız daha sonra yapacağım
                //* product sil 
                return false;
            }
            #region Approved 
            var user = await _userService.GetUser (model.UserId);
            var product = await _productService.GetProduct (model.ProductId);
            var IsThereProduct = false;
            foreach (var item in user.Products) {
                var _product = await _productService.GetProduct (item);
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
            #endregion
            model.Status = "Approved";
            await _commonEntityService.UpdateCommonEntity (model);
            return true;
        }

        [HttpPut]
        [Route ("MoneyDepositOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> UpdteMoneyDepositOperation (CommonEntityModel model) {
            if (model.Status == "Denied") {
                //* User Bilgilendirme::: Durum başarısız daha sonra yapacağım
                return false;
            }
            var commonEntity = await _commonEntityService.GetCommonEntity (model.Id);
            var user = await _userService.GetUser (commonEntity.UserId);
            user.Credit += commonEntity.Deposite;
            await _userService.UpdateUser (user);
            commonEntity.Status = "Approved";
            await _commonEntityService.UpdateCommonEntity (commonEntity);
            return true;
        }

    }
}