using HrLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrLeaveManagement.Domain.Models;


namespace HrLeaveManagement.Application.IRepository
{
    public  interface ILeaveAllocationRepository : IGenericRepositoryAsync<LeaveAllocation>
    {

    }
     
}
