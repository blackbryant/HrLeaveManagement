using HrLeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Requests
{
    public class GetLeaveRequestDetailDtoRequest : IRequest<LeaveRequestDto>
    {
       public required  int Id { get; set; }
    }

}
