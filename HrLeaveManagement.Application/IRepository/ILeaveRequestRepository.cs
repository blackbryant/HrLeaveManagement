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
        Task<int> CreateLeaveRequest(LeaveRequest leaveRequest);
        Task<bool> ChangeApprovalStatus(int id, bool approved, string approverComment);
        Task<bool> CancelRequest(int id);
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<IReadOnlyList<LeaveRequest>> GetUserLeaveRequests(string userId);


    }

}
