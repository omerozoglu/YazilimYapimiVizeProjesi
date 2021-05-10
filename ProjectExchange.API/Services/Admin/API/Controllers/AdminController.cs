using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.DeleteCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.GetListQuery;
using Application.Features.Queries.GetQuery;
using Application.Models;
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
        [ProducesResponseType (typeof (IEnumerable<CommonEntityVm>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CommonEntityVm>>> GetCommonEntitys () {
            var query = new GetListCommonEntityQuery ();
            var orders = await _mediator.Send (query);
            return Ok (orders);
        }
        #endregion

        #region GetCommonEntity ()
        [HttpGet ("{id:length(24)}", Name = "GetCommonEntity")]
        [ProducesResponseType (typeof (CommonEntityVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CommonEntityVm>> GetCommonEntity (string id) {
            var query = new GetCommonEntityQuery (id);
            var orders = await _mediator.Send (query);
            if (orders == null) {
                return NotFound ();
            }

            return Ok (orders);
        }
        #endregion

        #region CreaterCommonEntity ()
        [HttpPost]
        [ProducesResponseType (typeof (CommonEntityVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CommonEntityVm>> CreateCommonEntity (CreateCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateCommonEntity ()
        [HttpPut (Name = "UpdateCommonEntity")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCommonEntity (UpdateCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DeleteCommonEntity ()
        [HttpDelete ("{id:length(24)}", Name = "DeleteCommonEntity")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCommonEntity (DeleteCommonEntityCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion
    }
}