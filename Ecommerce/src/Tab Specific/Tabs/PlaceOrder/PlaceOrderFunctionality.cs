using ProjectNS.ItemNS;
using ProjectNS.TheFormNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNS.PlaceOrderNS
{
    class Functionality
    {
        private readonly IOrderData _data;
        private List<ChosenItem> chosenItems;
        private List<NumericUpDown> nuds;


        public Functionality(IOrderData data)
        {
            _data = data;
        }


        public async Task PlaceOrder()
        {
            await _GetChosenItemsAsync();
            await _UpdateDbAsync();
            _UpdateOrderTab();
        }


        #region _GetChosenItems
        private async Task _GetChosenItemsAsync()
        {
            await Task.Run( () =>
            {
                _GetChosenItems();
            });
        }

        private void _GetChosenItems()
        {
            nuds = new List<NumericUpDown>();
            chosenItems = new List<ChosenItem>();

            int quantity;
            NumericUpDown nud;
            ChosenItem chosenItem;
            int i = 0;

            foreach (Panel panel in _data.ItemsPanelsContainer.Controls)
            {
                ExtractQuantity(panel, out nud, out quantity);
                if (quantity > 0)
                {
                    nuds.Add(nud);

                    chosenItem = new ChosenItem(_data.AllItems.ElementAt(i), quantity);
                    chosenItems.Add(chosenItem);
                }
                i++;
            }
        }
        #endregion




        #region UpdateDb
        private async Task _UpdateDbAsync()
        {
            await Task.Run( () =>
            {
                _UpdateDb();
            });
        }

        private void _UpdateDb()
        {
            using (var db = new DbDataContext())
            {
                Queries createOrder = new Queries(db, _data.UserId, chosenItems);
                createOrder.Create();
            }
        }
        #endregion



        private void _UpdateOrderTab()
        {
            foreach (NumericUpDown nud in nuds)
            {
                nud.Value = 0;
            }
            _data.OrderPlacedLabel = "Order placed.";
        }



        public static void ExtractQuantity(Panel panel, out NumericUpDown nud, out int quantity)
        {
            nud = (NumericUpDown)panel.Controls.Find("itemNud", false)[0];
            quantity = (int) nud.Value;
        }





        public static bool DetermineIfCanOrder(DbDataContext db, int userId, decimal balanceLimitForOrders, Label cantOrderLabel)
        {
            bool cantOrder = db.Users.First(u => u.id == userId).balance >= balanceLimitForOrders;
            if (cantOrder)
            {
                cantOrderLabel.Text = $"Your balance is too high, and you can not make any new purchases until it drops below {Misc.FormatToCurrency(balanceLimitForOrders)}";
                cantOrderLabel.Visible = true;
            }
            return cantOrder;
        }
    }
}
