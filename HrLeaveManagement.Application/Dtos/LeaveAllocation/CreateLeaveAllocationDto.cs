using HrLeaveManagement.Application.Dtos.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveAllocation
{
    public class CreateLeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; } = DateTime.Now.Year;


    }
}
