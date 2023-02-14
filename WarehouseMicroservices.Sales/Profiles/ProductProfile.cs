using AutoMapper;
using WarehouseMicroservices.Sales.DTOs.Product;
using WarehouseMicroservices.Sales.Models;

namespace WarehouseMicroservices.Sales.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
