using ProjectNS.PurchaseHistoryNS;
using System;
using System.Linq;
using System.Windows.Forms;
using static ProjectNS.PurchaseHistoryNS.Functionality;

/*This simply is:
  IEnumerable< IGrouping<OrderDetails, PurchaseDetails> >
*/
using GroupedPurchases = System.Collections.Generic.IEnumerable<System.Linq.IGrouping<ProjectNS.PurchaseHistoryNS.Functionality.OrderDetails, ProjectNS.PurchaseHistoryNS.Functionality.PurchaseDetails>>;


namespace ProjectNS.TheFormNS
{
    public partial class TheForm : Form
    {
        public class PurchaseHistoryData : IPurchaseHistoryData
        {
            private readonly TheForm _theForm;

            public PurchaseHistoryData(TheForm theForm)
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

            public DateTime StartDateTime
            {
                get
                {
                    Control.ControlCollection purchaseHistoryTabControls = _theForm.purchaseHistory_tabPage.Controls;
                    Control startDateTimePicker = purchaseHistoryTabControls.Find("start_dateTimePicker", false)[0];
                    return ((DateTimePicker) startDateTimePicker).Value;
                }
            }

            public DateTime EndDateTime
            {
                get
                {
                    Control.ControlCollection purchaseHistoryTabControls = _theForm.purchaseHistory_tabPage.Controls;
                    Control endDateTimePicker = purchaseHistoryTabControls.Find("end_dateTimePicker", false)[0];
                    return ((DateTimePicker)endDateTimePicker).Value;
                }
            }

            public decimal LowerPriceRange
            {
                get
                {
                    return _theForm.lowerPriceRange.Value;
                }
            }

            public decimal UpperPriceRange
            {
                get
                {
                    return _theForm.upperPriceRange.Value;
                }
            }

            public void AddLabel(String str)
            {
                _theForm.purchaseHistory_panel.Controls.Add(
                    new Label
                    {
                        Text = str,
                        AutoSize = true
                    }
                );
            }
        }



        private void showHistory_button_Click(object sender, EventArgs e)
        {
            /*In case this is the second search the user wants to do the their history,
             * but this time with differnet filters.*/
            purchaseHistory_panel.Controls.Clear();

            PurchaseHistoryData data = new PurchaseHistoryData(this);
            Functionality functionality = new Functionality(data);
            functionality.ShowHistoryAsync();
        }
    }
}
