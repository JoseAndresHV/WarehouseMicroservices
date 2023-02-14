namespace WarehouseMicroservices.Inventory.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(decimal price) :
            base($"The price amount ${price} is not valid.")
        {
        }
    }
}
