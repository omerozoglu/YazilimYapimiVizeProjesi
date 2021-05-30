using System;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.ProductApprovals.Commands.Create;
using Application.Features.ProductApprovals.Commands.Delete;
using Application.Features.ProductApprovals.Commands.Update;
using Application.Features.ProductApprovals.Queries.Get;
using Application.Features.ProductApprovals.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/ProductApproval
    [Route ("api/v1/[controller]")]
    public class ProductApprovalController : ControllerBase {
        private readonly IMediator _mediator;

        public ProductApprovalController (IMediator mediator) {
            _mediator = mediator;
        }
        #region GetAllProductApprovalEntity ()
        [HttpGet]
        //  [Route ("GetAllProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<ProductApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<ProductApproval>>> GetAllProductApprovalEntity () {
            var query = new GetListProductApprovalQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetProductApprovalEntity ()
        [HttpGet ("{id:length(24)}")]
        // [Route ("GetProductApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<ProductApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<ProductApproval>>> GetProductApprovalEntity (string id) {
            try {
                var query = new GetProductApprovalQuery (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<ProductApproval> ();
                err.ReponseName = nameof (GetProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateProductApprovalEntity ()
        [HttpPost]
        // [Route ("CreateProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<ProductApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<ProductApproval>>> CreateProductApprovalEntity (CreateProductApprovalCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<ProductApproval> ();
                err.ReponseName = nameof (CreateProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateProductApprovalEntity ()
        [HttpPut]
        // [Route ("UpdateProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<ProductApproval>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<ProductApproval>>> UpdateProductApprovalEntity (UpdateProductApprovalCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<ProductApproval> ();
                err.ReponseName = nameof (UpdateProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteProductApprovalEntity ()
        [HttpDelete ("{id:length(24)}")]
        // [Route ("DeleteProductApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<ProductApproval>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<ProductApproval>>> DeleteProductApprovalEntity (string id) {
            try {
                DeleteProductApprovalCommand command = new DeleteProductApprovalCommand (id);
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<ProductApproval> ();
                err.ReponseName = nameof (DeleteProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}