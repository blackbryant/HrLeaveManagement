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
    public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeHandler( ILeaveTypeRepository leaveTypeRepository , IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper; 
        }


       public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //驗證
             
           
         

            var leaveType = await _leaveTypeRepository.GetById(request.Id);
            if (leaveType == null)
            {
                throw new Exception(nameof(LeaveType));
            }
        

           await _leaveTypeRepository.Delete(leaveType);

          return Unit.Value;
        }

    }
}
