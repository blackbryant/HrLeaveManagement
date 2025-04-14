using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }

    }
}
