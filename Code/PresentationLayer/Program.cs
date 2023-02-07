using Domain_Layer.Data;
using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using Service_Layer.IServices;
using Service_Layer.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var ConnectionString = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();
//repository
builder.Services.AddScoped(typeof(IOwnerRepository<>), typeof(Owners<>));
builder.Services.AddScoped(typeof(IPropertyInfo<>), typeof(ProeprtyInfoRepository<>));
builder.Services.AddScoped(typeof(ITenantRepository<>), typeof(TenantRepository<>));
builder.Services.AddScoped(typeof(IAssignedRepository<>), typeof(AssignedPropertyRepository<>));
builder.Services.AddScoped(typeof(IQueriesRepository<>), typeof(QueriesRepository<>));
//builder.Services.AddScoped(typeof(ISubTableRepository<>), typeof(SubTableRepository<>));
builder.Services.AddScoped(typeof(IRentCountRepository<>), typeof(RentCountRepository<>));
builder.Services.AddScoped(typeof(IRentMasterRepository<>), typeof(RentMasterRepository<>));
builder.Services.AddScoped(typeof(IRentTableRepository<>), typeof(RentTableRepository<>));
builder.Services.AddScoped(typeof(IUserRoleRepository<>), typeof(UserRoleRepository<>));

//builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
//builder.Services.AddControllers();
//services
builder.Services.AddScoped<IOwnerService<Owners>, OwnerService>();
builder.Services.AddScoped<IPropertyService<PropertyInfo>, PropertyService>();
builder.Services.AddScoped<ITenantService<Tenant>, TenantService>();
builder.Services.AddScoped<IAssignedService<AssignedProperties>, AssignedService>();
builder.Services.AddScoped<IQueriesServices<Queries>,QueriesService>();
//builder.Services.AddScoped<ISubTableService<Subtable>,SubTableService>();
builder.Services.AddScoped<IRentCountService<RentCountModel>, RentCountService>();
builder.Services.AddScoped<IRentMasterService<RentMaster>, RentMasterService>();
builder.Services.AddScoped<IRentTableService<RentDetails>, RentTableService>();
builder.Services.AddScoped<IUserRoleService<Users>, UserRoleService>();

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
