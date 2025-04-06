using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Application.Dtos.LeaveType;

namespace HrLeaveManagement.Application.Dtos.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public LeaveTypeDto? LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; } = DateTime.Now.Year;


    }
}
