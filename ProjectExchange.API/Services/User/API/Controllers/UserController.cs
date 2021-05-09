using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.DeleteCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.Get;
using Application.Features.Queries.GetList;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/User
    [Route ("api/v1/[controller]")]
    public class UserController : ControllerBase {

        private readonly IMediator _mediator;

        public UserController (IMediator mediator) {
            _mediator = mediator;
        }

        #region GetUsers ()
        [HttpGet]
        [ProducesResponseType (typeof (IEnumerable<UserVm>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserVm>>> GetUsers () {
            var query = new GetUsersListQuery ();
            var orders = await _mediator.Send (query);
            return Ok (orders);
        }
        #endregion

        #region GetUser ()
        [HttpGet ("{id:length(24)}", Name = "GetUser")]
        [ProducesResponseType (typeof (UserVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<UserVm>> GetUser (string id) {
            var query = new GetUserQuery (id);
            var orders = await _mediator.Send (query);
            if (orders == null) {
                return NotFound ();
            }

            return Ok (orders);
        }
        #endregion

        #region CreaterUser ()
        [HttpPost]
        [ProducesResponseType (typeof (UserVm), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<UserVm>> CreateUser (CreateUserCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateUser ()
        [HttpPut (Name = "UpdateUser")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUser (UpdateUserCommand command) {
            await _mediator.Send (command);
            return NoContent ();
        }
        #endregion

        #region DeleteUser ()
        [HttpDelete ("{id:length(24)}", Name = "DeleteUser")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser (DeleteUserCommand command) {
            await _mediator.Send (command);
            return NoContent ();
        }
        #endregion
    }
}