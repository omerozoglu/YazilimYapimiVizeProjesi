using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.DeleteCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Domain.Common;
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
            var query = new GetCommonEntityQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region CreaterCommonEntity ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> CreateCommonEntity (CreateCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateCommonEntity ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> UpdateCommonEntity (UpdateCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DeleteCommonEntity ()
        [HttpDelete]
        [ProducesResponseType (typeof (EntityResponse<CommonEntity>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<CommonEntity>>> DeleteCommonEntity (DeleteCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion
    }
}