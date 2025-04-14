

using HrLeaveManagement.Infrastructure.Services;
using HrLeaveManagement.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.ConfigurationApplicationServices();
builder.Services.ConfigurationPersistenceServices(builder.Configuration);
builder.Services.ConfigurationMailService(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=> c.SwaggerDoc("v1", new OpenApiInfo {  Title ="Hr LeaveManage API",Version="v1"}));


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.LeaveManagement.Api v1"));
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
