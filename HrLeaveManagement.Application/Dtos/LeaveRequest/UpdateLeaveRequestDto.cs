using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        public string? RequestComments { get; set; }

        public bool? Cancelled  { get; set; }



    }
}
