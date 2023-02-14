using AutoMapper;
using WarehouseMicroservices.Sales.DTOs.Sale;
using WarehouseMicroservices.Sales.Models;

namespace WarehouseMicroservices.Sales.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleDTO>();
        }
    }
}
