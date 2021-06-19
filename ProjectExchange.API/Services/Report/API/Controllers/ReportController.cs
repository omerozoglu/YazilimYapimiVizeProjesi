using System;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Commands.Create;
using Application.Features.Queries.GetList;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    // api/v1/Report
    [Route ("api/v1/[controller]")]
    public class ReportController : ControllerBase {
        private readonly IMediator _mediator;
        public ReportController (IMediator mediator) {
            _mediator = mediator;
        }

        #region GetReports ()
        [HttpGet]
        [ProducesResponseType (typeof (EntityResponse<Report>), (int) HttpStatusCode.OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityResponse<Report>>> GetReports () {
            var query = new GetReportsListQuery ();
            var result = await _mediator.Send (query);
            return Ok (result);
        }
        #endregion

        #region CreateReport ()
        [HttpPost]
        [ProducesResponseType (typeof (EntityResponse<Report>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<EntityResponse<Report>>> CreateReport (CreateReportCommand command) {
            try {
                var result = await _mediator.Send (command);
                return Ok (result);
            } catch (ValidationException ex) {
                var err = new EntityResponse<Report> ();
                err.ReponseName = nameof (CreateReport);
                err.Status = ResponseType.Error;
                err.Message = ex.Message;
                err.Content = null;
                return Ok (err);
            }
        }
        #endregion
    }
}