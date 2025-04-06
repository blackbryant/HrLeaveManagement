using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.IRepository
{
    public interface ILeaveTypeRepository : IGenericRepositoryAsync<LeaveType>
    {
        Task<int> CreateLeaveType(LeaveType leaveType);
        Task<bool> UpdateLeaveType(LeaveType leaveType);
        Task<bool> DeleteLeaveType(int id);
        Task<IReadOnlyList<LeaveType>> GetAllLeaveTypes();
        Task<LeaveType> GetLeaveTypeById(int id);
    }

}
