using HrLeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands
{
    interface UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

        public ChangeLeaveRequestApproveDto ChangeLeaveRequestApproveDto { get; set; }

    }
}
