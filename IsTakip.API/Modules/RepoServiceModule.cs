using Autofac;
using IsTakip.Caching;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;
using IsTakip.Repository;
using IsTakip.Repository.Repositories;
using IsTakip.Repository.UnitOfWorks;
using IsTakip.Service.Mapping;
using IsTakip.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace IsTakip.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<BusinessServiceWithCaching>().As<IBusinessService>();
            builder.RegisterType<CustomerClassServiceWithCaching>().As<ICustomerClassService>();
            builder.RegisterType<CustomerServiceWithCaching>().As<ICustomerService>();
            builder.RegisterType<JobfileServiceWithCaching>().As<IJobfileService>();
            builder.RegisterType<ProductionLeadServiceWithCaching>().As<IProductionLeadService>();
            builder.RegisterType<ProductionLeadTypeServiceWithCaching>().As<IProductionLeadTypeService>();
            builder.RegisterType<ProductionOrderServiceWithCaching>().As<IProductionOrderService>();
            builder.RegisterType<SupplierServiceWithCaching>().As<ISupplierService>();
            builder.RegisterType<UserServiceWithCaching>().As<IUserService>();
            builder.RegisterType<WareHouseInventoryServiceWithCaching>().As<IWareHouseInventoryService>();
            builder.RegisterType<WarehouseServiceWithCaching>().As<IWarehouseService>();
            builder.RegisterType<WareHouseShelfServiceWithCaching>().As<IWareHouseShelfService>();

        }
    }
}
