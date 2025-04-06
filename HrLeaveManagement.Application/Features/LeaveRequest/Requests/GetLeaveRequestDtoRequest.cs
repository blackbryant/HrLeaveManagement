﻿using HrLeaveManagement.Application.Dtos.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Requests
{
    public interface GetLeaveRequestDtoRequest : IRequest<List<LeaveRequestDto>>
    {
        int Id { get; set; }
    }
    
    
}
