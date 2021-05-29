using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using ExchangeGateway.CommonAlgorithms.Sorting;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Models.EntityModels.Enums;
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
        private readonly IAprpovalEntityService<MoneyApproval> _moneyApprovalService;
        private readonly IAprpovalEntityService<ProductApproval> _productApprovalService;
        public ExchangeController (IUserService userService, IProductService productService, IAprpovalEntityService<MoneyApproval> moneyApprovalService, IAprpovalEntityService<ProductApproval> productApprovalService) {
            _userService = userService;
            _productService = productService;
            _moneyApprovalService = moneyApprovalService;
            _productApprovalService = productApprovalService;
        }

        [HttpPut]
        [Route ("TakeOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseModel<string>>> TakeOperation (TakerModel model) {

            var response = new ResponseModel<string> () { ReponseName = nameof (TakeOperation), Content = null };
            double _modelProdcutWeight = model.Weight;
            string _modelProductName = model.ProductName, _modelUserId = model.UserId;
            var _takerUserResponse = await _userService.GetUser (_modelUserId);
            var _takerUser = _takerUserResponse.Content[0];

            #region Get products
            var productResponse = await _productService.GetProductsByName (_modelProductName);
            if (productResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = productResponse.Status;
                response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{productResponse.Message}\"";
                return response;
            }

            var products = productResponse.Content;
            //* If operation has interrupted on updating

            //* Sorting products
            products = InsertionSort.sort (products);
            #endregion

            #region Taker product check
            bool isThereProduct = false;
            Product _tmpTakerProduct = new Product ();
            foreach (var product in _takerUser.Products) {
                var takerProductResponse = await _productService.GetProduct (product);
                _tmpTakerProduct = takerProductResponse.Content.Find (product => product.Name == product.Name);
                if (_tmpTakerProduct.Name == _modelProductName) {
                    isThereProduct = true;
                    break;
                }
            }
            //* If there is product named by taker wants, Update this product
            if (!isThereProduct) {
                _tmpTakerProduct.Name = products[0].Name;
                _tmpTakerProduct.ImgUrl = products[0].ImgUrl;
                _tmpTakerProduct.UserId = _modelUserId;
                //* else, create a new one
                var _createTakerProductResponse = await _productService.CreateProduct (_tmpTakerProduct);
                //* If operation has interrupted on updating
                if (_createTakerProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = _createTakerProductResponse.Status;
                    response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_createTakerProductResponse.Message}\"";
                }

                _tmpTakerProduct.Id = _createTakerProductResponse.Content[0].Id;
                _takerUser.Products.Add (_tmpTakerProduct.Id);
                var _updateTakerResponse = await _userService.UpdateUser (_takerUser);
                //* If operation has interrupted on updating
                if (_createTakerProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = _createTakerProductResponse.Status;
                    response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_createTakerProductResponse.Message}\"";
                }

            }
            #endregion

            #region Take operation
            var _tmpTakerProdcutWeight = _modelProdcutWeight;
            foreach (var _tmpSellerProdcut in products) {
                var _sellerUserResponse = await _userService.GetUser (_tmpSellerProdcut.UserId);
                var _sellerUser = _sellerUserResponse.Content[0];

                if (_tmpTakerProdcutWeight > _tmpSellerProdcut.Weight) {
                    //* this operation was make seller's product weight was zero,so this product must be delete
                    _tmpTakerProdcutWeight -= _tmpSellerProdcut.Weight;
                    var _deleteSellerProductResponse = await _productService.DeleteProduct (_tmpSellerProdcut.Id);
                    //* If operation has interrupted on deleting
                    if (_deleteSellerProductResponse.Status.Value != ResponseType.Success.Value) {
                        response.Status = _deleteSellerProductResponse.Status;
                        response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_deleteSellerProductResponse.Message}\"";
                        break;
                    }

                    //* Seller's credit += As much as the weight of the product that the taker wants * Seller's unit price of the product 
                    _sellerUser.Credit += _tmpSellerProdcut.Weight * _tmpSellerProdcut.UnitPrice;

                    //* Taker's credit -= As much as the weight of the product that the taker wants * Seller's unit price of the product 
                    _takerUser.Credit -= _tmpSellerProdcut.Weight * _tmpSellerProdcut.UnitPrice;

                    _tmpTakerProduct.Weight += _tmpSellerProdcut.Weight;
                } else {
                    //* this operation was filled as much as the weight of the product that the taker wants and Seller's product weight was decreased
                    _tmpSellerProdcut.Weight -= _tmpTakerProdcutWeight;
                    var _updateSellerProductResponse = await _productService.UpdateProduct (_tmpSellerProdcut);
                    //* If operation has interrupted on updating
                    if (_updateSellerProductResponse.Status.Value != ResponseType.Success.Value) {
                        response.Status = _updateSellerProductResponse.Status;
                        response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_updateSellerProductResponse.Message}\"";
                        break;
                    }
                    //* Seller's credit += As much as the weight of the product that the taker wants * Seller's unit price of the product 
                    _sellerUser.Credit += _tmpTakerProdcutWeight * _tmpSellerProdcut.UnitPrice;

                    //* Taker's credit -= As much as the weight of the product that the taker wants * Seller's unit price of the product 
                    _takerUser.Credit -= _tmpTakerProdcutWeight * _tmpSellerProdcut.UnitPrice;

                    _tmpTakerProduct.Weight += _tmpTakerProdcutWeight;
                    _tmpTakerProdcutWeight = 0;
                }

                var _updateSellerResponse = await _userService.UpdateUser (_sellerUser);
                //* If operation has interrupted on updating
                if (_updateSellerResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = _updateSellerResponse.Status;
                    response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_updateSellerResponse.Message}\"";
                    break;
                }

                var _updateTakerResponse = await _userService.UpdateUser (_takerUser);
                //* If operation has interrupted on updating
                if (_updateTakerResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = _updateTakerResponse.Status;
                    response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_updateTakerResponse.Message}\"";
                    break;
                }

                var _updateTakerProductResponse = await _productService.UpdateProduct (_tmpTakerProduct);
                //* If operation has interrupted on updating
                if (_updateTakerProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = _updateTakerProductResponse.Status;
                    response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{_updateTakerProductResponse.Message}\"";
                    break;
                }

                if (_tmpTakerProdcutWeight == 0) {
                    break;
                }
            }

            #endregion

            response.Message = "Take Operation successfully";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPut]
        [Route ("SellOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> SellOperation (SellerModel model) {
            var response = new ResponseModel<string> () { ReponseName = nameof (SellOperation) };
            double _modelProdcutWeight = model.Weight, _modelProductUnitPrice = model.UnitPrice;
            string _modelUserId = model.UserId, _modelProductId = model.ProductId;

            //* Get Seller User
            var sellerUserReponse = await _userService.GetUser (_modelUserId);
            if (sellerUserReponse.Status.Value != ResponseType.Success.Value) {
                response.Status = sellerUserReponse.Status;
                response.Message = $"{nameof (TakeOperation)} was interrupted due to \"{sellerUserReponse.Message}\"";
                return response;
            }
            var sellerUser = sellerUserReponse.Content[0];

            //*Get Seller's Product
            var sellerProductResponse = await _productService.GetProduct (_modelProductId);
            if (sellerProductResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = sellerProductResponse.Status;
                response.Message = $"{nameof (SellOperation)} was interrupted due to \"{sellerProductResponse.Message}\"";
                return response;
            }
            var sellerProduct = sellerProductResponse.Content[0];

            //* Sell Operation
            //* The total weight of the seller's product  minus the weight of the product the seller wants to sell 

            sellerProduct.Weight = (sellerProduct.Weight - _modelProdcutWeight) > 0 ? (sellerProduct.Weight - _modelProdcutWeight) : 0;

            if (sellerProduct.Weight == 0) {
                //*delete seller product
                var deleteSellerProductResponse = await _productService.DeleteProduct (sellerProduct.Id);
                if (deleteSellerProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = deleteSellerProductResponse.Status;
                    response.Message = $"{nameof (SellOperation)} was interrupted due to \"{deleteSellerProductResponse.Message}\"";
                    return response;
                }
                sellerUser.Products.Remove (sellerProduct.Id);
                var updateSellerUserResponse = await _userService.UpdateUser (sellerUser);
                if (updateSellerUserResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = updateSellerUserResponse.Status;
                    response.Message = $"{nameof (SellOperation)} was interrupted due to \"{updateSellerUserResponse.Message}\"";
                    return response;
                }

            } else {
                //* update seller product
                var updateSellerProductResponse = await _productService.UpdateProduct (sellerProduct);
                if (updateSellerProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = updateSellerProductResponse.Status;
                    response.Message = $"{nameof (SellOperation)} was interrupted due to \"{updateSellerProductResponse.Message}\"";
                    return response;
                }
            }
            sellerProduct.UnitPrice = _modelProductUnitPrice;
            //* Create new product item
            Product newProduct = new Product ();
            newProduct = sellerProduct;
            newProduct.Weight = _modelProdcutWeight;
            newProduct.Id = null;

            var createSellerProductResponse = await _productService.CreateProduct (newProduct);
            if (createSellerProductResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = createSellerProductResponse.Status;
                response.Message = $"{nameof (SellOperation)} was interrupted due to \"{createSellerProductResponse.Message}\"";
                return response;
            }

            response.Message = "Operation successfully";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPost]
        [Route ("ProductLoadOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseModel<string>>> ProductLoadOperation (ProductApproval model) {
            var response = new ResponseModel<string> () { ReponseName = nameof (ProductLoadOperation) };

            //*Create ProductApprovalEntity
            var ProductApproval = new ProductApproval () {
                UserId = model.UserId,
                Type = ApprovalType.Load,
                Status = ApprovalStatus.Pending,
                ProductName = model.ProductName,
                ProductImgUrl = model.ProductImgUrl,
                ProductWeight = model.ProductWeight
            };
            var productApprovalResponse = await _productApprovalService.CreateApprovalEntity (ProductApproval);
            if (productApprovalResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = productApprovalResponse.Status;
                response.Message = $"{nameof (ProductLoadOperation)} was interrupted due to \"{productApprovalResponse.Message}\"";
                return response;
            }

            response.Message = "Operation successfully submitted to admin for approval ";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPost]
        [Route ("MoneyDepositOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> MoneyDepositOperation (MoneyApproval model) {
            var response = new ResponseModel<string> () { ReponseName = nameof (MoneyDepositOperation) };

            //*Create MoneyApprovalEntity
            var MoneyApproval = new MoneyApproval () {
                UserId = model.UserId,
                Type = ApprovalType.Deposit,
                Status = ApprovalStatus.Pending,
                Deposit = model.Deposit
            };
            var moneyApprovalResponse = await _moneyApprovalService.CreateApprovalEntity (MoneyApproval);
            if (moneyApprovalResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = moneyApprovalResponse.Status;
                response.Message = $"{nameof (MoneyDepositOperation)} was interrupted due to \"{moneyApprovalResponse.Message}\"";
                return response;
            }

            response.Message = "Operation successfully submitted to admin for approval ";
            response.Status = ResponseType.Success;
            return response;
        }

        [HttpPut]
        [Route ("AdminConfirmOperation")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<string>>> LoadConfirmOperation (ProductApproval model) {
            var response = new ResponseModel<string> () { ReponseName = nameof (LoadConfirmOperation), Content = new List<string> () { } };

            //* If admin approved, System'll be create product in related user
            if (model.Status.Value == ApprovalStatus.Approved.Value) {
                Product newProduct = new Product () { UserId = model.UserId, Name = model.ProductName, ImgUrl = model.ProductImgUrl, Weight = model.ProductWeight, UnitPrice = 0 };
                var userProductResponse = await _productService.CreateProduct (newProduct);
                if (userProductResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = userProductResponse.Status;
                    response.Message = $"{nameof (LoadConfirmOperation)} was interrupted due to \"{userProductResponse.Message}\"";
                    return response;
                }
                var userGetResponse = await _userService.GetUser (model.UserId);
                if (userGetResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = userGetResponse.Status;
                    response.Message = $"{nameof (LoadConfirmOperation)} was interrupted due to \"{userGetResponse.Message}\"";
                    return response;
                }
                User user = userGetResponse.Content[0];
                user.Products.Add (userProductResponse.Content[0].Id);
                var userResponse = await _userService.UpdateUser (user);
                if (userResponse.Status.Value != ResponseType.Success.Value) {
                    response.Status = userResponse.Status;
                    response.Message = $"{nameof (LoadConfirmOperation)} was interrupted due to \"{userResponse.Message}\"";
                    return response;
                }
            }

            //* Updating ApprovalEntity 
            var ProductApproval = model;
            var productApprovalResponse = await _productApprovalService.UpdateApprovalEntity (ProductApproval);
            if (productApprovalResponse.Status.Value != ResponseType.Success.Value) {
                response.Status = productApprovalResponse.Status;
                response.Message = $"{nameof (LoadConfirmOperation)} was interrupted due to \"{productApprovalResponse.Message}\"";
                return response;
            }

            response.Message = "Operation successfully submitted";
            response.Status = ResponseType.Success;
            return response;
        }

    }
}