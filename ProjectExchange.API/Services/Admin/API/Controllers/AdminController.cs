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

        #region GetCommonEntity ()
        [HttpGet]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> GetCommonEntities () {
            var query = new GetListCommonEntityQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetCommonEntity ()
        [HttpGet ("{id:length(24)}", Name = "GetCommonEntity")]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> GetCommonEntity (string id) {
            try {
                var query = new GetCommonEntityQuery (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<CommonEntity> ();
                err.ReponseName = nameof (GetCommonEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreateCommonEntity ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> CreateCommonEntity (CreateCommonEntityCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity> ();
                err.ReponseName = nameof (CreateCommonEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateCommonEntity ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> UpdateCommonEntity (UpdateCommonEntityCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity> ();
                err.ReponseName = nameof (CreateCommonEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteCommonEntity ()
        [HttpDelete]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> DeleteCommonEntity (DeleteCommonEntityCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<CommonEntity> ();
                err.ReponseName = nameof (CreateCommonEntity);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}