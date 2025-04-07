using FluentValidation;
using HrLeaveManagement.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveRequest.Validators
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;


        public CreateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be less than {ComparisonValue}");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                .MustAsync(async (id, cancellation) =>
                {

                   var leaveType = await _leaveTypeRepository.GetById(id);

                    if (leaveType == null)
                    {
                        return false;
                    }
                    else 
                    {
                        return true; 
                    }
                }).WithMessage("{PropertyName} does not exist");


        }
    }
   
}
