using WarehouseMicroservices.Sales.DTOs.Sale;
using WarehouseMicroservices.Sales.Enums;
using WarehouseMicroservices.Sales.Models;

namespace WarehouseMicroservices.Sales.Services.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleDTO>> GetAllSales();
        Task<SaleDTO> GetSale(int id);
        Task<SaleDTO> SellProduct(SellProductDTO sellProduct);
        Task<SaleDTO> RefundProduct(int saleId);
        Sale CalculateSale(Product product, int qty, TaxType taxType);
        Task<SaleDTO> UpdateSaleStatus(int saleId, UpdateSaleStatusDTO updateSaleStatus);
    }
}
