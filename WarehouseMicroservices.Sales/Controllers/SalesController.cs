using Microsoft.AspNetCore.Mvc;
using WarehouseMicroservices.Sales.DTOs;
using WarehouseMicroservices.Sales.DTOs.Sale;
using WarehouseMicroservices.Sales.Services.Interfaces;

namespace WarehouseMicroservices.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetSales()
        {
            var response = new ResponseDTO<IEnumerable<SaleDTO>>();
            try
            {
                response.Result = await _saleService.GetAllSales();
                response.Success = true;
                response.Message = "Sales obtained.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<SaleDTO>>> GetSale(int id)
        {
            var response = new ResponseDTO<SaleDTO>();
            try
            {
                response.Result = await _saleService.GetSale(id);
                response.Success = true;
                response.Message = "Sale obtained.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<SaleDTO>>> PostSale(SellProductDTO sellProductDTO)
        {
            var response = new ResponseDTO<SaleDTO>();
            try
            {
                response.Result = await _saleService.SellProduct(sellProductDTO);
                response.Success = true;
                response.Message = "Product Sold.";

                return CreatedAtAction("GetSale",
                    new { id = response.Result.Id }, response.Result);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;

                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<int>>> DeleteSale(int id)
        {
            var response = new ResponseDTO<int>();
            try
            {
                await _saleService.RefundProduct(id);

                response.Result = id;
                response.Success = true;
                response.Message = "Product refunded.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO<SaleDTO>>> UpdateSaleStatus(int id, UpdateSaleStatusDTO sale)
        {
            var response = new ResponseDTO<SaleDTO>();
            try
            {
                response.Result = await _saleService.UpdateSaleStatus(id, sale);
                response.Success = true;
                response.Message = "Sale status updated.";
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
