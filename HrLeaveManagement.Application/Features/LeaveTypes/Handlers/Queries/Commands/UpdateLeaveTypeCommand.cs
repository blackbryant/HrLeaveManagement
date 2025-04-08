using HrLeaveManagement.Application.Dtos.LeaveRequest;
using HrLeaveManagement.Application.Dtos.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries.Commands
{
    public interface UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public UpdateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
