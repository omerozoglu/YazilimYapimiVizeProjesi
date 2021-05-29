using System;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.MoneyApprovals.Commands.Create;
using Application.Features.MoneyApprovals.Commands.Delete;
using Application.Features.MoneyApprovals.Commands.Update;
using Application.Features.MoneyApprovals.Queries.Get;
using Application.Features.MoneyApprovals.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/moneyApproval
    [Route ("api/v1/[controller]")]
    public class MoneyApprovalController : ControllerBase {
        private readonly IMediator _mediator;

        public MoneyApprovalController (IMediator mediator) {
            _mediator = mediator;
        }
        #region GetAllMoneyApprovalEntity ()
        [HttpGet]
        //  [Route ("GetAllMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<MoneyApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<MoneyApproval>>> GetAllMoneyApprovalEntity () {
            var query = new GetListMoneyApprovalQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetMoneyApprovalEntity ()
        [HttpGet ("{id:length(24)}")]
        //  [Route ("GetMoneyApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<MoneyApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<MoneyApproval>>> GetMoneyApprovalEntity (string id) {
            try {
                var query = new GetMoneyApprovalQuery (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<MoneyApproval> ();
                err.ReponseName = nameof (GetMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateMoneyApprovalEntity ()
        [HttpPost]
        //   [Route ("CreateMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<MoneyApproval>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<MoneyApproval>>> CreateMoneyApprovalEntity (CreateMoneyApprovalCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<MoneyApproval> ();
                err.ReponseName = nameof (CreateMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateMoneyApprovalEntity ()
        [HttpPut]
        //   [Route ("UpdateMoneyApprovalEntity")]
        [ProducesResponseType (typeof (EntityResponse<MoneyApproval>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<MoneyApproval>>> UpdateMoneyApprovalEntity (UpdateMoneyApprovalCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<MoneyApproval> ();
                err.ReponseName = nameof (UpdateMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteMoneyApprovalEntity ()
        [HttpDelete ("{id:length(24)}")]
        //  [Route ("DeleteMoneyApprovalEntity/{id:length(24)}")]
        [ProducesResponseType (typeof (EntityResponse<MoneyApproval>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<MoneyApproval>>> DeleteMoneyApprovalEntity (string id) {
            try {
                DeleteMoneyApprovalCommand command = new DeleteMoneyApprovalCommand (id);
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<MoneyApproval> ();
                err.ReponseName = nameof (DeleteMoneyApprovalEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}