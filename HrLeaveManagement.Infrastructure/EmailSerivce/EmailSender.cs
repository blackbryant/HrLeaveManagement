﻿using HrLeaveManagement.Application.Contracts;
using HrLeaveManagement.Domain.ValueOjects;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.EmailSerice
{
    public class EmailSender : IEmailSender
    {
        private EmailSetting _emailSettings;

        public EmailSender(IOptions<EmailSetting> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }


        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.Apikey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await  client.SendEmailAsync(message);
             
            return response.StatusCode == System.Net.HttpStatusCode.OK ||
                   response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
    
}
