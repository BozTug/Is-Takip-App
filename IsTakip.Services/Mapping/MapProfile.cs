using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Business, BusinessDTO>().ReverseMap();
            CreateMap<Agenda, AgendaDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerClass, CustomerClassDTO>().ReverseMap();
            CreateMap<CustomerRepresentative, CustomerRepresentativeDTO>().ReverseMap();
            CreateMap<Jobfile, JobfileDTO>().ReverseMap();
            CreateMap<ProductionLead, ProductionLeadDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
            CreateMap<WareHouseInventory, WareHouseInventoryDTO>().ReverseMap();
            CreateMap<WareHouseShelf, WareHouseShelfDTO>().ReverseMap();
            CreateMap<Customer, CustomerWithCustomerClassDTO>();
            CreateMap<Customer, CustomerWithAgendaDTO>();
            CreateMap<Customer, CustomerWithBusinessDTO>();
            CreateMap<Customer, CustomerWithCustomerRepresentativeDTO>();
            CreateMap<Customer, CustomerWithWareHouseInventoryDTO>();
            CreateMap<Business, BusinessWithCustomerDTO>();
            CreateMap<Business, BusinessWithJobfileDTO>();
            CreateMap<Business, BusinessWithSupplierDTO>();
            CreateMap<WareHouseInventory, WareHouseInventoryWithCustomerDTO>();
            CreateMap<WareHouseInventory, WareHouseInventoryWithSupplierDTO>();
            CreateMap<WareHouseInventory, WareHouseInventoryWithWarehouseDTO>();
            CreateMap<WareHouseInventory, WareHouseInventoryWithWareHouseShelfDTO>();
            CreateMap<Warehouse, WarehouseWithWareHouseInventoryDTO>();
            CreateMap<Warehouse, WarehouseWithWareHouseShelfDTO>();
            CreateMap<WareHouseShelf, WareHouseShelfWithWarehouseDTO>();
            CreateMap<WareHouseShelf, WareHouseShelfWithWareHouseInventoryDTO>();
            CreateMap<Supplier, SupplierWithBusinessDTO>();
            CreateMap<Supplier, SupplierWithWareHouseInventoryDTO>();
            CreateMap<User, UserWithCustomerDTO>();
            CreateMap<Jobfile, JobfileWithBusinessDTO>();
            CreateMap<CustomerClass, CustomerClassWithCustomerDTO>();



        }
    }
}
