using System;
using System.Collections.Generic;
using System.Linq;
using ProjectNS;
using ProjectNS.ItemNS;
using static ProjectNS.TheFormNS.TheForm;

namespace ProjectNS.PlaceOrderNS
{
    /**Handles everything regarding creating an order (rearding the datatabase, that is), including the purchases,
     and updating the Item and User tables.*/
    public class Queries
    {
        private readonly DbDataContext _db;
        private readonly int _userId;
        private readonly List<ChosenItem> _chosenItems;

        public Queries(DbDataContext db, int userId, List<ChosenItem> chosenItems)
        {
            _db = db;
            _userId = userId;
            _chosenItems = chosenItems;
        }



        public void Create()
        {
            Order order = new Order()
            {
                user_id = _userId,
                date = DateTime.Now
            };
            _db.Orders.InsertOnSubmit(order);
            /*Submission here instead of having it done with the purchases
             * submission is so the primary key of the row created can be used in the Purchases.*/
            _db.SubmitChanges();

            List<Purchase> purchases = _GetPurchases(
                order.pk,
                out decimal orderCost
            );

            _db.Purchases.InsertAllOnSubmit(purchases);
            _UpdateItemQuantities();
            _UpdateUserBalance(orderCost);
            _db.SubmitChanges();
        }



        private List<Purchase> _GetPurchases(int orderPk, out decimal orderCost)
        {
            orderCost = 0;
            List<Purchase> purchases = new List<Purchase>();

            int quantityToBuy;
            int itemPk;
            decimal itemPrice;
            String tableName;

            foreach (ChosenItem chosenItem in _chosenItems)
            {
                quantityToBuy = chosenItem.QuantityToBuy;
                itemPk = chosenItem.TheItem.Pk;
                itemPrice = chosenItem.TheItem.Price;
                tableName = Misc.GetTableName(chosenItem.TheItem.TheTableName);

                purchases.Add(new Purchase
                {
                    order_pk = orderPk,
                    table_of_item_pk = tableName,
                    item_pk = itemPk,
                    quantity = quantityToBuy
                });
                orderCost += quantityToBuy * itemPrice;
            }

            return purchases;
        }



        /// <summary>
        /// Doesn't submit the changes to the db.
        /// </summary>
        private void _UpdateItemQuantities()
        {
            TableName tableName;
            int itemPk;
            int boughtQuantity;

            foreach (ChosenItem chosenItem in _chosenItems)
            {
                tableName = chosenItem.TheItem.TheTableName;
                itemPk = chosenItem.TheItem.Pk;
                boughtQuantity = chosenItem.QuantityToBuy;

                if(chosenItem.TheItem.TheTableName == TableName.TEA)
                {
                    Tea tea = _db.Teas.First(t => t.pk == itemPk);
                    tea.quantity -= boughtQuantity;
                }
                else if (chosenItem.TheItem.TheTableName == TableName.EARBUDS)
                {
                    Earbud earbud = _db.Earbuds.First(e => e.pk == itemPk);
                    earbud.quantity -= boughtQuantity;
                }
            }
        }



        /// <summary>
        /// Doesn't submit the changes to the db.
        /// </summary>
        private void _UpdateUserBalance(decimal orderCost)
        {
            User user = _db.Users.First(u => u.id == _userId);
            user.balance += orderCost;
        }
    }
}