namespace WarehouseMicroservices.Sales.Enums
{
    public enum TaxType
    {
        None,
        IVA,
        Other
    }

    public static class TaxTypes
    {
        public static readonly Dictionary<TaxType, decimal> Values = new()
        {
            [TaxType.None] = .0m,
            [TaxType.IVA] = .13m,
            [TaxType.Other] = .05m,
        };
    }
}
