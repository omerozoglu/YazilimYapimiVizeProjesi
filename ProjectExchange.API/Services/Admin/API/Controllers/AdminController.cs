using System;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Commands.Create;
using Application.Features.Commands.Delete;
using Application.Features.Commands.Update;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/admin
    [Route ("api/v1/[controller]")]
    public class AdminController : ControllerBase {
        private readonly IMediator _mediator;

        public AdminController (IMediator mediator) {
            _mediator = mediator;
        }

        #region GetAllMoneyApprovalEntity ()
        [HttpGet]
        [Route ("GetAllMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<MoneyApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<MoneyApproval>>>> GetAllMoneyApprovalEntity () {
            var query = new GetListCommonEntityQuery<MoneyApproval> ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetAllProductApprovalEntity ()
        [HttpGet]
        [Route ("GetAllProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<ProductApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<ProductApproval>>>> GetAllProductApprovalEntity () {
            var query = new GetListCommonEntityQuery<ProductApproval> ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetMoneyApprovalEntity ()
        [HttpGet]
        [Route ("GetMoneyApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<MoneyApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<MoneyApproval>>>> GetMoneyApprovalEntity (string id) {
            try {
                var query = new GetCommonEntityQuery<MoneyApproval> (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<CommonEntity<MoneyApproval>> ();
                err.ReponseName = nameof (GetMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region GetProductApprovalEntity ()
        [HttpGet]
        [Route ("GetProductApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<ProductApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<ProductApproval>>>> GetProductApprovalEntity (string id) {
            try {
                var query = new GetCommonEntityQuery<ProductApproval> (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<CommonEntity<ProductApproval>> ();
                err.ReponseName = nameof (GetProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateMoneyApprovalEntity ()
        [HttpPost]
        [Route ("CreateMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<MoneyApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<MoneyApproval>>>> CreateMoneyApprovalEntity (CreateCommonEntityCommand<MoneyApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<MoneyApproval>> ();
                err.ReponseName = nameof (CreateMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateProductApprovalEntity ()
        [HttpPost]
        [Route ("CreateProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<ProductApproval>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity<ProductApproval>>>> CreateProductApprovalEntity (CreateCommonEntityCommand<ProductApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<ProductApproval>> ();
                err.ReponseName = nameof (CreateProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateMoneyApprovalEntity ()
        [HttpPut]
        [Route ("UpdateMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<MoneyApproval>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity<MoneyApproval>>>> UpdateMoneyApprovalEntity (UpdateCommonEntityCommand<MoneyApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<MoneyApproval>> ();
                err.ReponseName = nameof (UpdateMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateProductApprovalEntity ()
        [HttpPut]
        [Route ("UpdateProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<ProductApproval>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity<ProductApproval>>>> UpdateProductApprovalEntity (UpdateCommonEntityCommand<ProductApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<ProductApproval>> ();
                err.ReponseName = nameof (UpdateProductApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteMoneyApprovalEntity ()
        [HttpDelete]
        [Route ("DeleteMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<MoneyApproval>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity<MoneyApproval>>>> DeleteMoneyApprovalEntity (DeleteCommonEntityCommand<MoneyApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<MoneyApproval>> ();
                err.ReponseName = nameof (DeleteMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteProductApprovalEntity ()
        [HttpDelete]
        [Route ("DeleteProductApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity<ProductApproval>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity<ProductApproval>>>> DeleteProductApprovalEntity (DeleteCommonEntityCommand<ProductApproval> command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity<ProductApproval>> ();
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