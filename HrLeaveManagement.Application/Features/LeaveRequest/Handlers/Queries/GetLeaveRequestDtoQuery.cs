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
    public  class GetLeaveRequestDtoQuery : IRequestHandler<GetLeaveRequestDtoRequest, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _imapper;

        public GetLeaveRequestDtoQuery(ILeaveRequestRepository leaveRequestRepository, IMapper imapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _imapper = imapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestDtoRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestsWithDetails();
            var leaveRequestDto = _imapper.Map<List<LeaveRequestDto>>(leaveRequest);
            return await Task.FromResult(leaveRequestDto);
        }


    }
}
