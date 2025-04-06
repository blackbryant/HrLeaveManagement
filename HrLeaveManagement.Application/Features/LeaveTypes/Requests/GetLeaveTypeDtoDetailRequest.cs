﻿using HrLeaveManagement.Application.Dtos.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeDtoDetailRequest :IRequest<LeaveTypeDto>
    {
        public int Id { get; set; } 
    }
}
