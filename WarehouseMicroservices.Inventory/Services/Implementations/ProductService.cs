﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Inventory.Data;
using WarehouseMicroservices.Inventory.DTOs.Product;
using WarehouseMicroservices.Inventory.Exceptions;
using WarehouseMicroservices.Inventory.Models;
using WarehouseMicroservices.Inventory.Services.Interfaces;

namespace WarehouseMicroservices.Inventory.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProduct(CreateProductDTO createProduct)
        {
            if (createProduct.Stock <= 0)
            {
                throw new InvalidStockException(createProduct.Stock);
            }

            if (createProduct.Price <= 0)
            {
                throw new InvalidPriceException(createProduct.Price);
            }

            var product = _mapper.Map<Product>(createProduct);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO updateProduct)
        {
            if (id != updateProduct.Id)
            {
                throw new NotMatchingIdsException();
            }

            var existProduct = await _context.Products.FindAsync(id);
            if (existProduct == null)
            {
                throw new ProductNotFoundException(id);
            }

            if (updateProduct.Stock <= 0)
            {
                throw new InvalidStockException(updateProduct.Stock);
            }

            if (updateProduct.Price <= 0)
            {
                throw new InvalidPriceException(updateProduct.Price);
            }

            var product = _mapper.Map<Product>(updateProduct);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
