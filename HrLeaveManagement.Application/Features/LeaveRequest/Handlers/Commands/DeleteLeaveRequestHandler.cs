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
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository,   IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<DeleteLeaveRequestCommand, Unit>.Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id+"");
            }

            await _leaveRequestRepository.Delete(leaveRequest);


            return Unit.Value;
        }
    }
}
