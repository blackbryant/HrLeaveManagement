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
    public class GetLeaveAllocationDtoQuery : IRequestHandler<GetLeaveAllocationDtoListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDtoQuery(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationDtoListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = _leaveAllocationRepository.GetAll();
            var leaveAllocationDtos = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

            return await  Task.FromResult(leaveAllocationDtos);

        }
    }
}
