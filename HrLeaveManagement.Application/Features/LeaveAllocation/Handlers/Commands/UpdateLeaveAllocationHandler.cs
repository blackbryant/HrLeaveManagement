using AutoMapper;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }


        async Task<Unit> IRequestHandler<UpdateLeaveAllocationCommand, Unit>.Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAlloction = await  _leaveAllocationRepository.GetById(request.LeaveAllocationDto.Id);

            var leaveAllocation = _mapper.Map(request.LeaveAllocationDto, leaveAlloction);
            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }

}
