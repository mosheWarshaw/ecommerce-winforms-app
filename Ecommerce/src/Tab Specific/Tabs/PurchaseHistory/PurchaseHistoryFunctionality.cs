using ProjectNS.ItemNS;
using ProjectNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProjectNS.TheFormNS.TheForm;

/*This simply is:
  IEnumerable< IGrouping<OrderDetails, PurchaseDetails> >
*/
using GroupedPurchases = System.Collections.Generic.IEnumerable<System.Linq.IGrouping<ProjectNS.PurchaseHistoryNS.Functionality.OrderDetails, ProjectNS.PurchaseHistoryNS.Functionality.PurchaseDetails>>;


namespace ProjectNS.PurchaseHistoryNS
{
    class Functionality
    {
        private readonly IPurchaseHistoryData _data;

        public Functionality(IPurchaseHistoryData data)
        {
            _data = data;
        }



        public async Task ShowHistoryAsync()
        {
            GroupedPurchases groupedPurchases = await _GetGroupedPurchasesAsync();
            _DisplayPurchases(groupedPurchases);
        }



        #region GetGroupedPurchases
        public async Task<GroupedPurchases> _GetGroupedPurchasesAsync()
        {
            GroupedPurchases groupedPurchases = null;
            await Task.Run( () =>
            {
                groupedPurchases = _GetGroupedPurchases();
            });
            return groupedPurchases;
        }



        private GroupedPurchases _GetGroupedPurchases()
        {
            GroupedPurchases groups;
            using (var db = new DbDataContext())
            {
                IEnumerable<OrderedItem> orderedItems = db.Purchases.Select(
                    p => new OrderedItem()
                        {
                            orderPk = p.order_pk,
                            quantity = p.quantity,
                            date = p.Order.date,
                            item = _GetItem(db, p),
                            userId = p.Order.user_id
                        }
                    );

                orderedItems = _ApplyFilters(orderedItems);                

                groups = orderedItems.
                    GroupBy(
                        oi => new OrderDetails(
                            oi.orderPk,
                            oi.date
                        ),
                        oi => new PurchaseDetails(
                            oi.item.Name,
                            oi.quantity,
                            oi.item.Price
                        )
                    ).
                    OrderByDescending(
                        group => group.Key.DateTime
                    ).
                    ToList();

            }
            return groups;
        }


        private IEnumerable<OrderedItem> _ApplyFilters(IEnumerable<OrderedItem> orderedItems)
        {
            DateTime startDateTime = _data.StartDateTime;
            DateTime endDateTime = _data.EndDateTime;
            DateTime tomorrow = Misc.Tomorrow;
            decimal lowerRange = _data.LowerPriceRange;
            decimal upperRange = _data.UpperPriceRange;

            Func<OrderedItem, bool> userFilter = oi => oi.userId == _data.UserId;
            Func<OrderedItem, bool> startDateFilter = oi => DateTime.Compare(oi.date, startDateTime) > 0;
            Func<OrderedItem, bool> endDateFilter = oi => DateTime.Compare(oi.date, endDateTime) < 0;
            Func<OrderedItem, bool> lowerPriceFilter = x => x.item.Price > lowerRange;
            Func<OrderedItem, bool> upperPriceFilter = x => x.item.Price < upperRange;

            if (!startDateTime.Equals(tomorrow))
            {
                orderedItems = orderedItems.Where(startDateFilter);
            }
            if (!endDateTime.Equals(tomorrow))
            {
                orderedItems = orderedItems.Where(endDateFilter);
            }
            if (lowerRange != 0)
            {
                orderedItems = orderedItems.Where(lowerPriceFilter);
            }
            if (upperRange != 0)
            {
                orderedItems = orderedItems.Where(upperPriceFilter);
            }

            return orderedItems;
        }
        #endregion


        private Item _GetItem(DbDataContext db, Purchase p)
        {
            String tableName = p.table_of_item_pk;
            if (tableName.Equals("tea"))
            {
                Tea tea = db.Teas.First(t => t.pk == p.item_pk);
                return new Item(-1, tea.name, -1m, tea.price, TableName.TEA);
            }
            else if(tableName.Equals("earbuds"))
            {
                Earbud earbuds = db.Earbuds.First(e => e.pk == p.item_pk);
                return new Item(-1, earbuds.name, -1m, earbuds.price, TableName.EARBUDS);
            }
            throw new Exception();
        }



        #region helper methods
        private void _DisplayPurchases(GroupedPurchases groupedPurchases)
        {
            String orderStr;
            String purchaseStr;
            foreach (IGrouping<OrderDetails, PurchaseDetails> order in groupedPurchases)
            {
                orderStr = $"{order.Key.DateTime}";
                AddLabelToPanel(orderStr);

                foreach (PurchaseDetails pd in order)
                {
                    purchaseStr = $"{pd.ItemName} - {pd.Quantity} - {Misc.FormatToCurrency(pd.Price)}";
                    AddLabelToPanel(purchaseStr);
                }
            }
        }


        
        private void AddLabelToPanel(String str)
        {
            _data.AddLabel(str);
        }
        #endregion



        #region Order- and Purchase- Details
        public class OrderDetails
        {
            public int OrderFk;
            public readonly DateTime DateTime;
            public OrderDetails(int orderFk, DateTime dateTime)
            {
                OrderFk = orderFk;
                DateTime = dateTime;
            }
            public override bool Equals(object obj)
            {
                return OrderFk == ((OrderDetails)obj).OrderFk;
            }
            public override int GetHashCode()
            {
                return OrderFk.GetHashCode();
            }
        }



        public class PurchaseDetails
        {
            public String ItemName { get; }
            public int Quantity { get; }
            public decimal Price { get; }
            public PurchaseDetails(String itemName, int quantity, decimal price)
            {
                ItemName = itemName;
                Quantity = quantity;
                Price = price;
            }
        }
        #endregion
    }
}
