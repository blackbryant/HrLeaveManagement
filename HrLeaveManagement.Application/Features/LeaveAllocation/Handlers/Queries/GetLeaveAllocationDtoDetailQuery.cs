using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveAllocation;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationDtoDetailQuery : IRequestHandler<GetLeaveAllocationDtoDetailRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDtoDetailQuery(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDtoDetailRequest request, CancellationToken cancellationToken)
        {
           _leaveAllocationRepository.GetById(request.Id);
            var leaveAllocationDtos = _mapper.Map<LeaveAllocationDto>(request);
            return await Task.FromResult(leaveAllocationDtos);
        }


    }
}
