using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveType
{
    public class CreateLeaveTypeDto
    {
        public string? Name { get; set; }

        public int DefaultDays { get; set; }


    }
}
