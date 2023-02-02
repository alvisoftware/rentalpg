using Domain_Layer.Data;
using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using Service_Layer.IServices;
using Service_Layer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var ConnectionString = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();
//repository
builder.Services.AddScoped(typeof(IOwnerRepository<>), typeof(Owners<>));
builder.Services.AddScoped(typeof(IPropertyInfo<>), typeof(ProeprtyInfoRepository<>));
builder.Services.AddScoped(typeof(ITenantRepository<>), typeof(TenantRepository<>));
builder.Services.AddScoped(typeof(IAssignedRepository<>), typeof(AssignedPropertyRepository<>));
builder.Services.AddScoped(typeof(IQueriesRepository<>), typeof(QueriesRepository<>));
builder.Services.AddScoped(typeof(ISubTableRepository<>), typeof(SubTableRepository<>));
builder.Services.AddScoped(typeof(IRentCountRepository<>), typeof(RentCountRepository<>));
builder.Services.AddScoped(typeof(IRentMasterRepository<>), typeof(RentMasterRepository<>));
builder.Services.AddScoped(typeof(IRentTableRepository<>), typeof(RentTableRepository<>));
//services
builder.Services.AddScoped<IOwnerService<Owners>, OwnerService>();
builder.Services.AddScoped<IPropertyService<PropertyInfo>, PropertyService>();
builder.Services.AddScoped<ITenantService<Tenant>, TenantService>();
builder.Services.AddScoped<IAssignedService<Assigned>, AssignedService>();
builder.Services.AddScoped<IQueriesServices<Queries>,QueriesService>();
builder.Services.AddScoped<ISubTableService<Subtable>,SubTableService>();
builder.Services.AddScoped<IRentCountService<RentCountModel>, RentCountService>();
builder.Services.AddScoped<IRentMasterService<RentMaster>, RentMasterService>();
builder.Services.AddScoped<IRentTableService<RentTable>, RentTableService>();
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
