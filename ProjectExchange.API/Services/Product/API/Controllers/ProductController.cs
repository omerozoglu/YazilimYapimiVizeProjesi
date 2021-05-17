using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.DeleteCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Application.Features.Queries.GetList.GetProductsByName;
using Application.Features.Queries.GetList.GetProductsUser;
using Application.Models;
using Domain.Common;
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
            var query = new GetProductQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetGroupedProducts ()
        [HttpGet ("GetGroupedProducts")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetGroupedProducts () {
            var query = new GetAllGroupedQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetProductUser ()
        [HttpPost ("GetProductUser")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProductUser (List<string> ids) {
            var query = new GetProductsUserQuery (ids);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetProductByName ()
        [HttpPost]
        [Route ("GetProductByName")]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> GetProductByName (ProductVm model) {
            var query = new GetProductsByNameQuery (model);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region CreateProduct ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Product>>> CreateProduct (CreateProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateProduct ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<Product>>> UpdateProduct (UpdateProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DeleteProduct ()
        [HttpDelete]
        [ProducesResponseType (typeof (EntityResponse<Product>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<Product>>> DeleteProduct (DeleteProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion
    }
}