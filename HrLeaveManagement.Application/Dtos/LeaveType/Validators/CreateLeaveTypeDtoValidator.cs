using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.")
                ;
        }
    }

}
