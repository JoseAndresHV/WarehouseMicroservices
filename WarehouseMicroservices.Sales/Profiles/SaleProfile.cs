using AutoMapper;
using Microsoft.OpenApi.Extensions;
using WarehouseMicroservices.Sales.DTOs.Sale;
using WarehouseMicroservices.Sales.Models;

namespace WarehouseMicroservices.Sales.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleDTO>().ForMember(s => s.Status,
                m => m.MapFrom(s => s.Status.GetDisplayName()));
        }
    }
}
