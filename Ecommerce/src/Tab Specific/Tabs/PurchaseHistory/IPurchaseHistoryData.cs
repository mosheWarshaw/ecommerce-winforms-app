using System;

namespace ProjectNS.PurchaseHistoryNS
{
    interface IPurchaseHistoryData
    {
        int UserId { get; }
        DateTime StartDateTime { get; }
        DateTime EndDateTime { get; }
        decimal LowerPriceRange { get; }
        decimal UpperPriceRange { get; }
        void AddLabel(String str);
    }
}
