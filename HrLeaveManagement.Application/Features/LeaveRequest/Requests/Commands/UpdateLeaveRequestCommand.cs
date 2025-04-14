using HrLeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

        public ChangeLeaveRequestApproveDto ChangeLeaveRequestApproveDto { get; set; }

    }
}
