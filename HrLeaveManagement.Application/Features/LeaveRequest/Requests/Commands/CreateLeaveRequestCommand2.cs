using HrLeaveManagement.Application.Dtos.LeaveRequest;
using HrLeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands
{
    interface CreateLeaveRequestCommand2 : IRequest<BaseCommandResponses>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }

    }
}
