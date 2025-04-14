using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveAllocation.Validators;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using HrLeaveManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class DeleteLeaveAllocationHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }


        async Task<Unit> IRequestHandler<DeleteLeaveAllocationCommand, Unit>.Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
         
            var leaveAlloction = await  _leaveAllocationRepository.GetById(request.Id);
            await _leaveAllocationRepository.Delete(leaveAlloction);
            return Unit.Value;

        }
    }

}
