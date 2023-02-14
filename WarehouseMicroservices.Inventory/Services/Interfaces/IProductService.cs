using WarehouseMicroservices.Inventory.DTOs.Product;

namespace WarehouseMicroservices.Inventory.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProduct(int id);
        Task<ProductDTO> CreateProduct(CreateProductDTO createProduct);
        Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO updateProduct);
        Task DeleteProduct(int id);
    }
}
