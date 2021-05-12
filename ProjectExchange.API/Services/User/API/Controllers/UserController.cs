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
    // api/v1/User
    [Route ("api/v1/[controller]")]
    public class UserController : ControllerBase {
        private readonly IMediator _mediator;
        public UserController (IMediator mediator) {
            _mediator = mediator;
        }

        #region GetUsers ()
        [HttpGet]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<User>>> GetUsers () {
            var query = new GetUsersListQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region GetUser ()
        [HttpGet ("{id:length(24)}", Name = "GetUser")]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<User>>> GetUser (string id) {
            var query = new GetUserQuery (id);
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region CreaterUser ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<User>>> CreateUser (CreateUserCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region UpdateUser ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<User>>> UpdateUser (UpdateUserCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion

        #region DeleteUser ()
        [HttpDelete]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<User>>> DeleteUser (DeleteUserCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }
        #endregion
    }
}