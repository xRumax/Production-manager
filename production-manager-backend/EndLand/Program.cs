using EndLand.Core.ExceptionFilters;
using EndLand.Core.DTOs;
using EndLand.Data.Models;
using EndLand.Repositories.Handlers;
using EndLand.Repositories.Implementations;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ReportsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
using EndLand.Transfer.RobotDevicesProgDir.Data;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using EndLand.Transfer.Shared.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.ReportsDir.Queries;
using OfficeOpenXml;
using EndLand.Transfer.UsersDir.Queries;
using EndLand.Transfer.UsersDir.Data;
using EndLand.Transfer.UsersDir.Commands;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NetLandContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Serilog
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// add mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IRobotDeviceProgRepository, RobotDeviceProgRepository>();
builder.Services.AddScoped<IRobotWaterMeterRepository, RobotWaterMeterRepository>();
builder.Services.AddScoped<IRobotConfigurationRepository, RobotConfigurationRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IRobotCartonsInitialRepository, RobotCartonsInitialRepository>();
builder.Services.AddScoped<IRobotCartonsFinishRepository, RobotCartonsFinishRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IUserService, UserService>();

// Project queries and commands
builder.Services.AddTransient<IRequestHandler<ListProjectQuery, PaginatedList<ProjectListDto>>, ListProjectHandler>();
builder.Services.AddTransient<IRequestHandler<GetProjectQuery, ProjectDto>, GetProjectHandler>();
builder.Services.AddTransient<IRequestHandler<CreateProjectCommand, ProjectDto>, CreateProjectHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateProjectCommand>, UpdateProjectHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteProjectCommand>, DeleteProjectHandler>();
builder.Services.AddTransient<IRequestHandler<ExcelReportProjectQuery, MemoryStream>, ExcelReportProjectHandler>();

// Report queries and commands
builder.Services.AddTransient<IRequestHandler<ListReportQuery, PaginatedList<ReportListDto>>, ListReportHandler>();
builder.Services.AddTransient<IRequestHandler<GetReportQuery, ReportDto>, GetReportHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteReportCommand>, DeleteReportHandler>();
builder.Services.AddTransient<IRequestHandler<ExcelReportReportQuery, MemoryStream>, ExcelReportReportHandler>();

// RobotCartonsFinish queries
builder.Services.AddTransient<IRequestHandler<ListRobotCartonsFinishQuery, PaginatedList<RobotCartonsFinishListDto>>, ListRobotCartonsFinishHandler>();
builder.Services.AddTransient<IRequestHandler<GetRobotCartonsFinishQuery, RobotCartonsFinishDto>, GetRobotCartonsFinishHandler>();

// RobotCartonsInitial queries
builder.Services.AddTransient<IRequestHandler<ListRobotCartonsInitialQuery, PaginatedList<RobotCartonsInitialListDto>>, ListRobotCartonsInitialHandler>();
builder.Services.AddTransient<IRequestHandler<GetRobotCartonsInitialQuery, RobotCartonsInitialDto>, GetRobotCartonsInitialHandler>();

// RobotConfiguration queries
builder.Services.AddTransient<IRequestHandler<ListRobotConfigurationQuery, PaginatedList<RobotConfigurationDto>>, ListRobotConfigurationHandler>();
builder.Services.AddTransient<IRequestHandler<GetRobotConfigurationQuery, RobotConfigurationDto>, GetRobotConfigurationHandler>();

// RobotDevicesProg queries
builder.Services.AddTransient<IRequestHandler<ListRobotDevicesProgQuery, PaginatedList<RobotDevicesProgListDto>>, ListRobotDevicesProgHandler>();
builder.Services.AddTransient<IRequestHandler<GetRobotDeviceQuery, RobotDeviceDto>, GetRobotDeviceHandler>();

// RobotWaterMeter queries
builder.Services.AddTransient<IRequestHandler<ListRobotWaterMeterQuery, PaginatedList<RobotWaterMeterListDto>>, ListRobotWaterMeterHandler>();
builder.Services.AddTransient<IRequestHandler<GetRobotWaterMeterQuery, RobotWaterMeterDto>, GetRobotWaterMeterHandler>();

// Users
builder.Services.AddTransient<IRequestHandler<ListUsersQuery, PaginatedList<UserListDto>>, ListUsersHandler>();
builder.Services.AddTransient<IRequestHandler<GetUserQuery, UserDto>, GetUserHandler>();
builder.Services.AddTransient<IRequestHandler<CreateUserCommand, UserDto>, CreateUserHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateUserCommand>, UpdateUserHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteUserCommand>, DeleteUserHandler>();


var app = builder.Build();

// Add Serilog
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.MapControllers();

app.Run();
