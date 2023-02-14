using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Sales.Data;
using WarehouseMicroservices.Sales.DTOs.Sale;
using WarehouseMicroservices.Sales.Enums;
using WarehouseMicroservices.Sales.Exceptions;
using WarehouseMicroservices.Sales.Models;
using WarehouseMicroservices.Sales.Services.Interfaces;

namespace WarehouseMicroservices.Sales.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SaleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Sale CalculateSale(Product product, int qty, TaxType taxType)
        {
            var subtotal = product.Price * qty;
            var tax = subtotal * TaxTypes.Values[taxType];

            return new Sale
            {
                ProductId = product.Id,
                Qty = qty,
                Subtotal = subtotal,
                Tax = tax,
                Total = subtotal + tax,
                DateTime = DateTime.Now
            };
        }

        public async Task<IEnumerable<SaleDTO>> GetAllSales()
        {
            var sales = await _context.Sales.ToListAsync();

            return _mapper.Map<IEnumerable<SaleDTO>>(sales);
        }

        public async Task<SaleDTO> GetSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                throw new SaleNotFoundException(id);
            }

            return _mapper.Map<SaleDTO>(sale);
        }

        public async Task<SaleDTO> RefundProduct(int saleId)
        {
            var sale = await _context.Sales.FindAsync(saleId);
            if (sale == null)
            {
                throw new SaleNotFoundException(saleId);
            }

            var product = await _context.Products.FindAsync(sale.ProductId);
            if (product == null)
            {
                throw new ProductNotFoundException(sale.ProductId);
            }

            product.Stock += sale.Qty;

            _context.Products.Update(product);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return _mapper.Map<SaleDTO>(sale);
        }

        public async Task<SaleDTO> SellProduct(SellProductDTO sellProductDTO)
        {
            var product = await _context.Products.FindAsync(sellProductDTO.ProductId);
            if (product == null)
            {
                throw new ProductNotFoundException(sellProductDTO.ProductId);
            }

            if (sellProductDTO.Qty <= 0)
            {
                throw new InvalidQtyException(sellProductDTO.Qty);
            }

            if (sellProductDTO.Qty > product!.Stock || product.Stock <= 0)
            {
                throw new NotEnoughStockException(product.ProductName, sellProductDTO.Qty);
            }

            product!.Stock -= sellProductDTO.Qty;
            _context.Products.Update(product);

            var sale = CalculateSale(product, sellProductDTO.Qty, TaxType.IVA);

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return _mapper.Map<SaleDTO>(sale);
        }
    }
}
