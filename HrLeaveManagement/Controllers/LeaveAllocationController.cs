using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using HrLeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {

        private readonly IMediator _mediator;


        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<List<LeaveAllocationDto>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationDtoListRequest());
            return leaveAllocations;
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<LeaveAllocationDto> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDtoDetailRequest() { Id = id });

            return leaveAllocation;
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateLeaveAllocationDto createLeaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = createLeaveAllocation };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,  [FromBody]UpdateLeaveAllocationDto updateLeaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand {Id = id,  LeaveAllocationDto = updateLeaveAllocation };
            await _mediator.Send(command);
            
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}
