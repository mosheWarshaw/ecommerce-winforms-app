using System;

namespace ProjectNS.FinanceNS
{
    interface IFinanceData
    {
        int UserId { get; }
        String AmountToPay { get; }
        void SetBalance(decimal newBalance);
    }
}
