using System;
using System.Collections.Generic;
using ProjectNS.ItemNS;
using System.Linq;
using static ProjectNS.TheFormNS.TheForm;

namespace ProjectNS
{
    partial class Misc
    {
        //For now, the user gets all items returned, instead of the user filtering by the item and cetagory which the database is set up for for future versions.
        public static List<Item> GetItemsForSale(DbDataContext db)
        {
            List<Item> items;

            items = db.Teas.
                Where(i => i.for_sale && i.quantity > 0).
                Select(i => new Item(i.pk, i.name, i.quantity, i.price, TableName.TEA)).
                ToList();

            items.AddRange(
                db.Earbuds.
                Where(i => i.for_sale && i.quantity > 0).
                Select(i => new Item(i.pk, i.name, i.quantity, i.price, TableName.EARBUDS)).
                ToList()
            );

            return items;
        }
    }
}
