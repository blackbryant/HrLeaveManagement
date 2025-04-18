﻿using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveTypeDto? LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; } = DateTime.Now;

        public string? RequestComments { get; set; }

        public DateTime DateActioned { get; set; } = DateTime.Now;

        public bool? Approved { get; set; } = false;

        public bool Cancelled { get; set; } = false;

    }
}
