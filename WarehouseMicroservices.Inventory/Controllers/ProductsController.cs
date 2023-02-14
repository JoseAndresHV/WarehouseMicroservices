using Microsoft.AspNetCore.Mvc;
using WarehouseMicroservices.Inventory.DTOs;
using WarehouseMicroservices.Inventory.DTOs.Product;
using WarehouseMicroservices.Inventory.Services.Interfaces;

namespace WarehouseMicroservices.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<ProductDTO>>>> GetProducts()
        {
            var response = new ResponseDTO<IEnumerable<ProductDTO>>();
            try
            {
                response.Result = await _productService.GetAllProducts();
                response.Success = true;
                response.Message = "Products obtained.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> GetProduct(int id)
        {
            var response = new ResponseDTO<ProductDTO>();
            try
            {
                response.Result = await _productService.GetProduct(id);
                response.Success = true;
                response.Message = "Product obtained.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> PutProduct(int id, UpdateProductDTO product)
        {
            var response = new ResponseDTO<ProductDTO>();
            try
            {
                response.Result = await _productService.UpdateProduct(id, product);
                response.Success = true;
                response.Message = "Product updated.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> PostProduct(CreateProductDTO product)
        {
            var response = new ResponseDTO<ProductDTO>();
            try
            {
                response.Result = await _productService.CreateProduct(product);
                response.Success = true;
                response.Message = "Product created.";

                return CreatedAtAction("GetProduct",
                    new { id = response.Result.Id }, response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;

                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = new ResponseDTO<int>();
            try
            {
                await _productService.DeleteProduct(id);

                response.Result = id;
                response.Success = true;
                response.Message = "Product deleted.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }
    }
}
