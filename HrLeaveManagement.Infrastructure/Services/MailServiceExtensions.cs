
using HrLeaveManagement.Application.Contracts;
using HrLeaveManagement.Infrastructure.EmailSerice;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Services
{
    public static class MailServiceExtensions
    {
        public static IServiceCollection AddMailService(this IServiceCollection services, IConfiguration configuration)
        {
            // Fix: Use Bind instead of Configure to map the configuration section to the EmailSetting class
            var emailSettings = new Domain.ValueOjects.EmailSetting();
            configuration.GetSection("EmailSettings").Bind(emailSettings);
            services.AddSingleton(emailSettings);

            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
