using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Repositories
{
    public class LeaveRequestRespository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveContext _dbContext;
        public LeaveRequestRespository(HrLeaveContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved, string command)
        {
            leaveRequest.Approved = approved;
            leaveRequest.RequestComments = command;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
             await  _dbContext.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await  _dbContext.LeaveRequests
                .Include(l => l.LeaveType)
                .ToListAsync();
            return leaveRequests;

        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest  = await  _dbContext.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.Id == id);

            return leaveRequest;
        }



    }
}
