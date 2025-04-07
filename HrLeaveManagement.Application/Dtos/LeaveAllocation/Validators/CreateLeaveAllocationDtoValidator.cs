using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Dtos.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator()
        {
            RuleFor(x => x.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.")
                ;
        }
    }

}
