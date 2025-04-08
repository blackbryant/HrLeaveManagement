using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository,  IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<UpdateLeaveRequestCommand, Unit>.Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }


            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.LeaveRequestDto.Id);

            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApproveDto != null)
            {
                if (request.ChangeLeaveRequestApproveDto.Approeved.HasValue)
                {
                    string commands = leaveRequest.RequestComments!=null ? leaveRequest.RequestComments : "";

                    await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest.Id, request.ChangeLeaveRequestApproveDto.Approeved.Value, commands);
                }
            }

            return Unit.Value;
        }
    }
}
