using AutoMapper;
using HrLeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HrLeaveManagement.Application.Exceptions;
using HrLeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HrLeaveManagement.Application.IRepository;
using MediatR;
using HrLeaveManagement.Domain.Models;
using HrLeaveManagement.Application.Models;
using HrLeaveManagement.Application.Contracts;
using HrLeaveManagement.Application.Responses;
using System.Reflection.Metadata;


namespace HrLeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand2, BaseCommandResponses>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        async Task<BaseCommandResponses> IRequestHandler<CreateLeaveRequestCommand2, BaseCommandResponses>.Handle(CreateLeaveRequestCommand2 request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            //寫入資料庫
            var leaveRequest = _mapper.Map<Domain.Models.LeaveRequest>(request.LeaveRequestDto);
            await _leaveRequestRepository.Add(leaveRequest);

            //電子郵件通知
            var email = new Email
            {
                To = "e49134030e@gmail.com",
                Body = $"Leave Type {leaveRequest.LeaveType} has been created. for {request.LeaveRequestDto.StartDate} ~ {request.LeaveRequestDto.EndDate} ",
                Subject = "Leave Request Submit",

            };

            try 
            {
                response.Id = leaveRequest.Id;
                response.Success = true;
                response.Message = "Leave Request Created Successfully";

                await _emailSender.SendEmail(email);

            }
            catch(Exception ex)
            {
               
            }


            return response; 
        }

       
    }
}
