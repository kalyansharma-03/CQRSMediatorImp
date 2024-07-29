using CQRSMediator.Application.Command;
using CQRSMediator.Application.Command.UpdateEmployee;
using CQRSMediator.Application.Model;
using CQRSMediator.Application.Queries;
using CQRSMediator.Application.Queries.GetEmployeeById;
using CQRSMediator.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var query = new GetAllEmployeeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("AddEmployeeDetails")]
        public async Task<IActionResult> AddEmployee(EEmployee model)
        {
            var command = new CreateEmployeeCommand(model.Name, model.Email);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetEmployeeById(Guid employeeId)
        {
            var query = new GetEmployeeByIdQuery(employeeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(EEmployee model)
        {
            var query = new UpdateEmployeeCommand(model.Id, model.Name, model.Email);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
