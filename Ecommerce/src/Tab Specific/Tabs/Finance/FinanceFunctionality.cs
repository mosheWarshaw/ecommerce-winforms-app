using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNS.FinanceNS
{
    class Functionality
    {
        private IFinanceData _data;

        public Functionality(IFinanceData data)
        {
            _data = data;
        }

        public async Task PayBalanceAsync()
        {
            decimal? newBalance = null;
            await Task.Run(() =>
                {
                    newBalance = _PayBalance();
                }
            );
            if (newBalance != null)
                _data.SetBalance(newBalance.Value);
        }

        private decimal? _PayBalance()
        {
            decimal? newBalance = null;
            if (Double.TryParse(_data.AmountToPay, out double amount))
            {
                using (var db = new DbDataContext())
                {
                    User user = db.Users.First(u => u.id == _data.UserId);
                    user.balance -= (decimal)amount;
                    db.SubmitChanges();
                    /*The account could be active from another device, so the balance is not
                     * necessarily just the subtraction of the amount entered.
                     * In a future version, add a refresh button for this reason,
                     * but even for such a case, the user shouldn't have to refresh after
                     * paying a balance in case the new amount is only relfecting the balance
                     * based on the activity on this device.*/
                    newBalance = user.balance;
                }
            }
            return newBalance;
        }
    }
}
