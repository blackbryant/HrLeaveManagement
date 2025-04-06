using HrLeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Domain
{
    public class LeaveType : BaseDomainEntity
    {

        public string Name { get; set; } = string.Empty;

        public int DefaultDays { get; set; }

        public string? Description { get; set; }
        
    }
}
