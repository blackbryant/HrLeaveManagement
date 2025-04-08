using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveAllocation.Validators;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }




        async Task<int> IRequestHandler<CreateLeaveAllocationCommand, int>.Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }


            var leaveAllocation = _mapper.Map<Domain.Models.LeaveAllocation>(request.LeaveAllocationDto);
            var id = await _leaveAllocationRepository.CreateLeaveAllocation(leaveAllocation);

            return id;
        }
    }

}
