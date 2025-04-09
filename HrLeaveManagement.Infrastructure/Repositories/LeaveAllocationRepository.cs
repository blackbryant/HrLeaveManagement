using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Repositories
{
    public  class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    { 
        private readonly HrLeaveContext _dbContext;
        public LeaveAllocationRepository(HrLeaveContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

         
    }
    
  
}
