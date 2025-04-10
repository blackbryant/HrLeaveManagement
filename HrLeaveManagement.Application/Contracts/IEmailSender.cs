﻿using HrLeaveManagement.Domain.ValueOjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.Contracts
{
    public interface IEmailSender
    {

        Task<bool> SendEmail(Email email);



    }
}
