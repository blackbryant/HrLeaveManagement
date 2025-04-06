using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Domain.Common
{
    public  abstract class BaseDomainEntity
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; } = string.Empty;

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        public string? LastModifiedBy { get; set; } = string.Empty;



    }
}
