using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Requests
{
    public  interface GetLeaveAllocationDtoDetailRequest : IRequest<LeaveAllocationDto>
    {
        int Id { get; set; }
    }

}
