using ProjectNS.ItemNS;
using ProjectNS.PlaceOrderNS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectNS.TheFormNS
{
    public partial class TheForm : Form
    {
        private class OrderData : IOrderData
        {
            private readonly TheForm _theForm;

            public OrderData(TheForm theForm)
            {
                _theForm = theForm;
            }

            public int UserId
            {
                get
                {
                    return _theForm.UserId;
                }
            }

            public Panel ItemsPanelsContainer
            {
                get
                {
                    return _theForm.itemsPanelsContainer_panel;
                }
            }

            public String BalanceAmount
            {
                set
                {
                    _theForm.balanceAmount_label.Text = value;
                }
            }

            public String OrderPlacedLabel
            {
                get
                {
                    return _theForm.orderPlacedLabel.Text;
                }
                set
                {
                    _theForm.orderPlacedLabel.Text = value;
                }
            }

            public List<Item> AllItems
            {
                get
                {
                    return _theForm.AllItems;
                }
            }
        }



        private void placeOrderButton_Click(object sender, EventArgs e)
        {
            bool canOrder;
            using (var db = new DbDataContext())
                canOrder = ! Functionality.DetermineIfCanOrder(db, UserId, _balanceLimitForOrders, cantOrder_label);

            if (canOrder) {
                orderPlacedLabel.Text = "Placing order....";
                OrderData data = new OrderData(this);
                Functionality functionality = new Functionality(data);
                functionality.PlaceOrder();
            }
        }
    }
}
