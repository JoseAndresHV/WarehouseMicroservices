using WarehouseMicroservices.Sales.Enums;

namespace WarehouseMicroservices.Sales.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }

        public Product Product { get; set; } = default!;
    }
}
