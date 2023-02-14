namespace WarehouseMicroservices.Inventory.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int id) :
            base($"The product with id {id} was not found.")
        {
        }
    }
}
