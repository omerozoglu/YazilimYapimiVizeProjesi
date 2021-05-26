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
        [HttpGet ("{id}", Name = "GetUser")]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<User>>> GetUser (string id) {
            try {
                var query = new GetUserQuery (id);
                var result = await _mediator.Send (query);
                return Ok (result);
            } catch (Exception ex) {
                var err = new EntityResponse<User> ();
                err.ReponseName = nameof (GetUser);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region CreaterUser ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<User>>> CreateUser (CreateUserCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<User> ();
                err.ReponseName = nameof (CreateUser);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region UpdateUser ()
        [HttpPut]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<User>>> UpdateUser (UpdateUserCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<User> ();
                err.ReponseName = nameof (UpdateUser);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion

        #region DeleteUser ()
        [HttpDelete]
        [ProducesResponseType (typeof (EntityResponse<User>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<User>>> DeleteUser (DeleteUserCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<User> ();
                err.ReponseName = nameof (DeleteUser);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}