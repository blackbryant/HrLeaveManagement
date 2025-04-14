using HrLeaveManagement.Application.Dtos.LeaveRequest;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<List<LeaveRequestDto>> Get()
        {

            var leaveRequests =  await _mediator.Send(new GetLeaveRequestDtoRequest());
            return leaveRequests;
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async  Task<LeaveRequestDto> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailDtoRequest() { Id = id });

            return leaveRequest;    
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand2 { LeaveRequestDto = leaveRequestDto };
            await _mediator.Send(command);

            return NoContent();
        }


        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]UpdateLeaveRequestDto leaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand { Id = id,  LeaveRequestDto = leaveRequestDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();

        }

        [HttpPut("changeApprove/{id}")]
        public async Task<ActionResult> ChangeApprove([FromBody] ChangeLeaveRequestApproveDto changeLeaveRequestApproveDto )
        {
            var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApproveDto = changeLeaveRequestApproveDto };
            await _mediator.Send(command);
            return NoContent();
        }



    }
}
