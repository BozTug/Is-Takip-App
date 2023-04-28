using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using IsTakip.Repository;
using IsTakip.Service.Mapping;
using IsTakip.Service.Validations;
using IsTakip.WebApp.Modules;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
        {
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
        builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);

        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(builder.Configuration.GetConnectionString("DbConStr"), option =>
            {
                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
            });
        });


        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
}
}