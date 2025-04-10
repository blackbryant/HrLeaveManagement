using AutoMapper;
using HrLeaveManagement.Application.Contracts;
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
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }


       public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //驗證
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if ( validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            //寫入資料庫
            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
                await   _leaveTypeRepository.Add(leaveType);

       



            return leaveType.Id;
        }

    }
}
