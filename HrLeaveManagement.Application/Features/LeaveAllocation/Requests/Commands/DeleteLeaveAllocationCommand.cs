using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public required int Id { get; set; }

    }
}
