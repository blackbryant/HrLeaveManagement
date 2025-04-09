using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Repositories
{
    public  class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrLeaveContext _dbContext;
        public LeaveTypeRepository(HrLeaveContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
     
    }

}
