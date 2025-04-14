using HrLeaveManagement.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application
{
    public static class ApplicationServiceRegisteration
    {
         
        public static IServiceCollection ConfigurationApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services; 
        }

    }
}
