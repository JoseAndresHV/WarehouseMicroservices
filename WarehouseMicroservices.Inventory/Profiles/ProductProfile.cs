using AutoMapper;
using WarehouseMicroservices.Inventory.DTOs.Product;
using WarehouseMicroservices.Inventory.Models;

namespace WarehouseMicroservices.Inventory.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<Product, ProductDTO>();
        }
    }
}
