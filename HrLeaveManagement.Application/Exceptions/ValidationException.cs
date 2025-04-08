using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Error { set; get;  } = new List<string>();

 

        public ValidationException(ValidationResult validationResult)  
        {
            foreach(var error  in validationResult.Errors)
            {
                Error.Add(error.ErrorMessage);
           }   


        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
