namespace WarehouseMicroservices.Sales.Exceptions
{
    public class SaleNotFoundException : Exception
    {
        public SaleNotFoundException(int id) :
            base($"The sale with id {id} was not found.")
        {
        }
    }
}
