using HrLeaveManagement.Application.IRepository;
using HrLeaveManagement.Domain.Models;
using HrLeaveManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Services
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection ConfigurationServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<HrLeaveContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));  

            services.AddScoped<ILeaveRequestRepository, LeaveRequestRespository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }


    }
}
