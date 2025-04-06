using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveType
{
    public   class LeaveTypeDto :BaseDto
    {

        public string Name { get; set; } = string.Empty;

        public int DefaultDays { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
