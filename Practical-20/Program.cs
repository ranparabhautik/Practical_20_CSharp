using Practical_20.Logging;
using Practical_20.Middleware;
using Practical_20.Model.Data;
using Practical_20.Repository.Implementation;
using Practical_20.Repository.Interface;
using Practical_20.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepo<>),
    typeof(GenericRepo<>));

builder.Services.AddScoped<IEmployeeRepo,
    EmployeeRepo>();

builder.Services.AddScoped<Logger>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();