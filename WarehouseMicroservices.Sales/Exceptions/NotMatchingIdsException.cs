namespace WarehouseMicroservices.Sales.Exceptions
{
    public class NotMatchingIdsException : Exception
    {
        public NotMatchingIdsException() :
            base($"The provided Ids are not the same.")
        {
        }
    }
}
