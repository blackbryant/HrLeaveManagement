using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveRequest
{
    public class ChangeLeaveRequestApproveDto : BaseDto
    {

       public bool? Approeved { set; get; }


    }
}
