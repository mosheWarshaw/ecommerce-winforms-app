using System;
using System.Collections.Generic;
using ProjectNS.ItemNS;
using System.Windows.Forms;

namespace ProjectNS.PlaceOrderNS
{
    interface IOrderData
    {
        int UserId { get; }
        Panel ItemsPanelsContainer { get; }
        String BalanceAmount { set; }
        String OrderPlacedLabel { get; set; }
        List<Item> AllItems { get; }
    }
}
