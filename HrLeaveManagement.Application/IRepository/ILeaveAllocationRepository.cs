using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.IRepository
{
    public  interface ILeaveAllocationRepository : IGenericRepositoryAsync<LeaveAllocation>
    {
        Task<bool> AllocateLeave(LeaveAllocation leaveAllocation);
        Task<bool> UpdateLeaveAllocation(LeaveAllocation leaveAllocation);
        Task<bool> DeleteLeaveAllocation(int id);
        Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<IReadOnlyList<LeaveAllocation>> GetUserAllocations(string userId);
    }

}
