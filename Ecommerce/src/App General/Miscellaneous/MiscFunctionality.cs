using System;
using static ProjectNS.TheFormNS.TheForm;

namespace ProjectNS
{
    partial class Misc
    {
        public static DateTime Tomorrow
        {
            get
            {
                return DateTime.Today.AddDays(1);
            }
        }

        public static String GetTableName(TableName tableName)
        {
            switch (tableName)
            {
                case TableName.TEA:
                    return "tea";
                case TableName.EARBUDS:
                    return "earbuds";
            }
            throw new Exception();
        }

        public static String FormatToCurrency(decimal num)
        {
            //So -123.45 (the user has credit) is not displayed as $-123.45
            String signAndDollar = num < 0 ? "-$" : "$";
            decimal absNum = Math.Abs(num);

            String absNumFormatted = absNum.ToString("N2");
            String formattedNewBalanceAmount = $"{signAndDollar}{absNumFormatted}";
            return formattedNewBalanceAmount;
        }
    }
}
