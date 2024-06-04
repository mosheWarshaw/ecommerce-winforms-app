using ProjectNS.ItemNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNS.TabVisitationNS
{
    public class FirstVisitation
    {
        #region PlaceOrder
        public static async Task<List<Item>> PlaceOrderAsync(TabVisitation tabVisitation, bool loggedIn, Panel itemsPanelsContainer)
        {
            List<Item> items = null;
            List<Panel> itemsPanels = null;
            if (loggedIn)
            {
                tabVisitation.SetVisitedToTrue(TabName.ORDER);
                await Task.Run(() =>
                {
                    _PlaceOrder(out items, out itemsPanels);
                });
                _DisplayAllItemsPanels(itemsPanelsContainer, itemsPanels);
            }
            return items;
        }

        private static void _PlaceOrder(out List<Item> items, out List<Panel> itemsPanels)
        {
            itemsPanels = new List<Panel>();
            using (var db = new DbDataContext())
            {
                items = Misc.GetItemsForSale(db);
            }
            int count = 0;
            foreach (Item item in items)
            {
                NumericUpDown nud = new NumericUpDown
                {
                    Name = "itemNud",
                    TextAlign = HorizontalAlignment.Right,
                    ThousandsSeparator = true,
                    Size = new Size(40, 40),
                    Maximum = item.Quantity
                };
                Label lPrice = new Label()
                {
                    Text = $"{item.Price}",
                    Name = "itemPrice",
                    AutoSize = true,
                    Location = new Point(nud.Location.X + 50, nud.Location.Y)
                };
                Label lName = new Label()
                {
                    Text = $"{item.Name}",
                    Name = "itemName",
                    AutoSize = true,
                    Location = new Point(lPrice.Location.X + 50, nud.Location.Y)
                };
                Panel p = new Panel
                {
                    AutoSize = true,
                    Name = "itemPanel" + count
                };
                p.Controls.Add(nud);
                p.Controls.Add(lPrice);
                p.Controls.Add(lName);

                itemsPanels.Add(p);
                count++;
            }
        }

        private static void _DisplayAllItemsPanels(Panel itemsPanelsContainer, List<Panel> itemsPanels)
        {
            foreach (Panel p in itemsPanels)
            {
                itemsPanelsContainer.Controls.Add(p);
            }
        }
        #endregion



        #region Finance
        public async static Task FinanceAsync(TabVisitation tabVisitation, int userId, Label balanceAmount, bool loggedIn)
        {
            if (loggedIn)
            {
                tabVisitation.SetVisitedToTrue(TabName.FINANCE);
                String formattedBalance = await Task.Run(() => _Finance(userId, balanceAmount));
                balanceAmount.Text = formattedBalance;
            }
        }

        private static String _Finance(int userId, Label balanceAmount)
        {
            decimal amount;
            using (var db = new DbDataContext())
            {
                amount = db.Users.First(u => u.id == userId).balance;
            }
            return Misc.FormatToCurrency(amount);
        }
        #endregion



        public static void PurchaseHistory(TabVisitation tabVisitation, DateTimePicker startPicker, DateTimePicker endPicker)
        {
            tabVisitation.SetVisitedToTrue(TabName.PURCHASE_HISTORY);
            startPicker.Value = Misc.Tomorrow;
            endPicker.Value = Misc.Tomorrow;
        }
    }
}
