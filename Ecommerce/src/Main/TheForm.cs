using ProjectNS.TabVisitationNS;
using System;
using System.Collections.Generic;
using ProjectNS.ItemNS;
using System.Windows.Forms;

namespace ProjectNS.TheFormNS
{
    public partial class TheForm : Form
    {
        private int UserId { get; set; }

        public List<Item> AllItems;

        private Val<bool> _loggedIn = new Val<bool>(false);

        public enum TableName { TEA, EARBUDS };

        private readonly TabVisitation _tabVisitation = new TabVisitation();

        private readonly decimal _balanceLimitForOrders = 100;


        private async void tabControl_Selected(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == placeOrder_tabPage && !(_tabVisitation.Visited(TabName.ORDER)))
            {
                AllItems = await FirstVisitation.PlaceOrderAsync(_tabVisitation, _loggedIn.val, itemsPanelsContainer_panel);
            }
            else if (tabControl.SelectedTab == finance_tabPage && !(_tabVisitation.Visited(TabName.FINANCE)))
            {
                await FirstVisitation.FinanceAsync(_tabVisitation, UserId, balanceAmount_label, _loggedIn.val);
            }
            else if (tabControl.SelectedTab == purchaseHistory_tabPage && !(_tabVisitation.Visited(TabName.PURCHASE_HISTORY)))
            {
                FirstVisitation.PurchaseHistory(_tabVisitation, start_dateTimePicker, end_dateTimePicker);
            }
        }



        public TheForm()
        {
            InitializeComponent();
        }
    }
}