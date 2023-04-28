using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using IsTakip.API.Filters;
using IsTakip.API.Middlewares;
using IsTakip.API.Modules;
using IsTakip.Repository;
using IsTakip.Service.Mapping;
using IsTakip.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(fv => {
    fv.RegisterValidatorsFromAssemblyContaining<BusinessDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<SupplierDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<AgendaDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CustomerClassDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CustomerDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CustomerRepresentativeDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<JobfileDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<ProductionLeadDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<WarehouseDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<WareHouseInventoryDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<WareHouseShelfDTOValidator>();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
var config = new AutoMapper.MapperConfiguration(cfg=>
{
    cfg.AddProfile(new MapProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DbConStr"), option =>
    {
        option.MigrationsAssembly("IsTakip.Repository");
    });
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCostomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
