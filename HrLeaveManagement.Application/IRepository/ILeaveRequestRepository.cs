using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Domain.Models;

namespace HrLeaveManagement.Application.IRepository
{
    public interface ILeaveRequestRepository : IGenericRepositoryAsync<LeaveRequest>
    {
         
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved, string command);
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
       
    }

}
