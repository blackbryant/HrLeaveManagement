﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HrLeaveManagement.Domain.Models;

public partial class LeaveType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? DefaultDays { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public virtual ICollection<LeaveAllocation> LeaveAllocations { get; set; } = new List<LeaveAllocation>();
}