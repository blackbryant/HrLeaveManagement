using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Exceptions
{
    public class NotFoundException :ApplicationException
    {
        public NotFoundException() : base("Not found error occurred.")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string name,string key ) : base($"{name}  ({key}) was not found")
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
