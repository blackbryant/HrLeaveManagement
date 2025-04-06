using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {

        public LeaveTypeDto? LeaveType { get; set; }

        public DateTime? DateRequested { get; set; } 

        public bool? Approved { get; set; } = false;


    }
}
