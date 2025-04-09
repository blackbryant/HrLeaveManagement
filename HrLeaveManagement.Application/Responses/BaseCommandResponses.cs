using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Responses
{
    public  class BaseCommandResponses
    {
        public BaseCommandResponses() { }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Id { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

    }
}
