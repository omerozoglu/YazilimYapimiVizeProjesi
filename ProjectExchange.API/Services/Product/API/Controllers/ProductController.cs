using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.DeleteCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Application.Features.Queries.GetList.GetProductsByName;
using Application.Models;
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
        [ProducesResponseType (typeof (IEnumerable<ProductVm>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts () {
            var query = new GetProductsListQuery ();
            var orders = await _mediator.Send (query);
            return Ok (orders);
        }
        #endregion

        #region GetProductByName ()
        [HttpPost]
        [Route ("GetProductByName")]
        [ProducesResponseType (typeof (ProductVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductByName (ProductVm model) {
            var query = new GetProductsByNameQuery (model);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetProduct ()
        [HttpGet ("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType (typeof (ProductVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVm>> GetProduct (string id) {
            var query = new GetProductQuery (id);
            var orders = await _mediator.Send (query);
            if (orders == null) {
                return NotFound ();
            }

            return Ok (orders);
        }
        #endregion

        #region CreaterProduct ()
        [HttpPost]
        [ProducesResponseType (typeof (ProductVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVm>> CreateProduct (CreateProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateProduct ()
        [HttpPut (Name = "UpdateProduct")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct (UpdateProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DeleteProduct ()
        [HttpDelete]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct (DeleteProductCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion
    }
}