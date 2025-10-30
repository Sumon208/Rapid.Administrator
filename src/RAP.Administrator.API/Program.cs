
using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;

using RAP.Administrator.Infrastructure.Repositories;
using RAP.Administrator.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ISafetyMaterialsService, SafetyMaterialsService>();
builder.Services.AddScoped<ISafetyMaterialsRepository, SafetyMaterialsRepository>();

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<ILoansService, LoansService>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<IProjectContractTypeService, ProjectContractTypeService>();
builder.Services.AddScoped<IProjectContractTypeRepository, ProjectContractTypeRepository>();

builder.Services.AddScoped<IProjectContractService, ProjectContractService>();
builder.Services.AddScoped<IProjectContractRepository, ProjectContractRepository>();

builder.Services.AddScoped<IEmployeeContractService, EmployeeContractService>();
builder.Services.AddScoped<IEmployeeContractRepository, EmployeeContractRepository>();

builder.Services.AddScoped<ILoanTypeService, LoanTypeService>();

builder.Services.AddScoped<ILoanTypeRepository,LoanTypeRepository>();

builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();

builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddScoped<IDocumentRepository,DocumentRepository>();builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();


builder.Services.AddScoped<IDocumentTypeRepository,DocumentTypeRepository>();

builder.Services.AddScoped<IContactTypeService, ContactTypeService>();

builder.Services.AddScoped<IContactTypeRepository,ContactTypeRepository>();

builder.Services.AddScoped<ISalaryAdvanceService, SalaryAdvanceService>();

builder.Services.AddScoped<ISalaryAdvanceRepository,SalaryAdvanceRepository>();


builder.Services.AddScoped<IJobLocationService, JobLocationService>();


builder.Services.AddScoped<IJobLocationRepository,JobLocationRepository>();


builder.Services.AddScoped<ICandidateListService, CandidateListService>();


builder.Services.AddScoped<ICandidateListRepository,CandidateListRepository>();


builder.Services.AddScoped<IRetirementService, RetirementService>();


builder.Services.AddScoped<IRetirementRepository,RetirementRepository>();


builder.Services.AddScoped<ITransferService, TransferService>();


builder.Services.AddScoped<ITransferRepository,TransferRepository>();


builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();


builder.Services.AddScoped<IInsuranceService,InsuranceService>();


builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddScoped<ICandidateService,CandidateService>();

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
