using System;
using static ProjectNS.TheFormNS.TheForm;

namespace ProjectNS.ItemNS
{
    public class Item
    {
        public readonly int Pk;
        public readonly String Name;
        public readonly decimal Quantity;
        public readonly decimal Price;
        public readonly TableName TheTableName;

        public Item(int pk, String name, decimal quantity, decimal price, TableName theTableName)
        {
            Pk = pk;
            Name = name;
            Quantity = quantity;
            Price = price;
            TheTableName = theTableName;
        }
    }
}
