using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Domain.ValueOjects
{
    public class EmailSetting
    {
        public string? Apikey { get; set; }

        public string? FromAddress { get; set; }

        public string? FromName { get; set; }

    }
}
