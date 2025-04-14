using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveType;
using HrLeaveManagement.Application.Features.LeaveTypes.Requests;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handler.Queries
{
    public class GetLeaveTypeDtoListQuery : IRequestHandler<GetLeaveTypeDtoDetailRequest,LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDtoListQuery(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDtoDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = _leaveTypeRepository.GetAll();
           var leaveTypeDtos = _mapper.Map<LeaveTypeDto>(leaveTypes);
            return await  Task.FromResult(leaveTypeDtos);

        }

    }
}
