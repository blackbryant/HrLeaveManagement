using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using HrLeaveManagement.Application.Dtos.LeaveRequest;
using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        }





    }
}
