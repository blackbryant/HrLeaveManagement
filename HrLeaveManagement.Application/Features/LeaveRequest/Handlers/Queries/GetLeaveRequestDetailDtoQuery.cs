using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveRequest;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Features.LeaveRequest.Handlers.Queries
{
    public  class GetLeaveRequestDetailDtoQuery : IRequestHandler<GetLeaveRequestDetailDtoRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _imapper;


        public GetLeaveRequestDetailDtoQuery(ILeaveRequestRepository leaveRequestRepository, IMapper imapper)
        {
           _leaveRequestRepository = leaveRequestRepository;
            _imapper = imapper;    
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailDtoRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            var leaveRequestDto = _imapper.Map<LeaveRequestDto>(leaveRequest);

            return await  Task.FromResult(leaveRequestDto);
        }
    }
    

}
