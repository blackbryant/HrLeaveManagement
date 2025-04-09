using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HrLeaveManagement.Application.Dtos.LeaveType.Validators;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HrLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries.Commands;
using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeHandler( ILeaveTypeRepository leaveTypeRepository , IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper; 
        }


       public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //驗證
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }


            var leaveType = await _leaveTypeRepository.GetById(request.LeaveTypeDto.Id);
            if (leaveType == null)
            {
                throw new Exception(nameof(LeaveType));
            }
            _mapper.Map(request.LeaveTypeDto, leaveType);

           await _leaveTypeRepository.Update(leaveType);

          return Unit.Value;
        }

    }
}
