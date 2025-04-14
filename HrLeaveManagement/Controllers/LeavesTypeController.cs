using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Application.Features.LeaveTypes.Handler.Queries;
using HrLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries.Commands;
using HrLeaveManagement.Application.Features.LeaveTypes.Requests;
using HrLeaveManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesTypeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeavesTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeavesTypeController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTyps = await _mediator.Send(new GetLeaveTypeDtoListRequest());
            return  leaveTyps ;
        }

        // GET api/<LeavesTypeController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDto> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDtoDetailRequest() { Id = id});

            return leaveType;
        }

        // POST api/<LeavesTypeController>
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody]CreateLeaveTypeDto leaveType)
        {
            var command =  new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeavesTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody]UpdateLeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand() { LeaveTypeDto = leaveType };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<LeavesTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand() { Id=id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
