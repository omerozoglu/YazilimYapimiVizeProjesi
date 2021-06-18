using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Commands.Create;
using Application.Features.Commands.Delete;
using Application.Features.Commands.Update;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Application.Features.Queries.GetList.GetProductsByName;
using Application.Features.Queries.GetList.GetProductsUser;
using Application.Features.Queries.GetList.GetProductsWithStatusByName;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/Product
    [Route ("api/v1/[controller]")]
    public class ProductController : ControllerBase {

        private readonly IMediator _mediator;

        public ProductController (IMediator mediator) {
            _mediator = mediator;
        }

        #region GetProducts ()
        [HttpGet]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProducts () {
            var query = new GetProductsListQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetProduct ()
        [HttpGet ("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProduct (string id) {
            try {
                var query = new GetProductQuery (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (GetProduct);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region GetGroupedProducts ()
        [HttpGet ("GetGroupedProducts")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetGroupedProducts () {
            try {
                var query = new GetAllGroupedQuery ();
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (GetGroupedProducts);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region GetProductUser ()
        [HttpPost ("GetProductUser")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProductUser (List<string> ids) {
            try {
                var query = new GetProductsUserQuery (ids);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (GetProductUser);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region GetProductByName ()
        [HttpGet ("{productName}")]
        // [Route ("GetProductByName")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProductByName (string productName) {
            try {
                var query = new GetProductsByNameQuery (productName);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (GetProductByName);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region GetProductsWithStatusByName ()
        [HttpGet ("ps/{productstatusName}")]
        // [Route ("GetProductByName")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProductsWithStatusByName (string productstatusName) {
            try {
                var query = new GetProductsWithStatusByNameQuery (productstatusName);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (GetProductByName);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateProduct ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> CreateProduct (CreateProductCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (CreateProduct);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateProduct ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<Product>>> UpdateProduct (UpdateProductCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (CreateProduct);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteProduct ()
        [HttpDelete ("{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<Product>>> DeleteProduct (string id) {
            try {
                DeleteProductCommand command = new DeleteProductCommand (id);
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<Product> ();
                err.ReponseName = nameof (CreateProduct);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}