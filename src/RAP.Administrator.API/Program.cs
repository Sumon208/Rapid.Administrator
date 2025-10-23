
using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;

using RAP.Administrator.Infrastructure.Repositories;
using RAP.Administrator.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IShiftTypeRepository, ShiftTypeRepository>();

builder.Services.AddScoped<IShiftTypeService,ShiftTypeService>();

builder.Services.AddScoped<ITaxRepository, TaxRepository>();

builder.Services.AddScoped<ITaxService,TaxService>();

builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();

builder.Services.AddScoped<IDivisionService, DivisionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
