using ProjectNS.FinanceNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNS.TheFormNS
{
    public partial class TheForm : Form
    {
        public class FinanceData : IFinanceData
        {
            private readonly TheForm _theForm;

            public FinanceData(TheForm theForm)
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

            public String AmountToPay {
                get
                {
                    return _theForm.amountToPay_textbox.Text;
                }
            }

            public void SetBalance(decimal newBalance)
            {
                _theForm.balanceAmount_label.Text = Misc.FormatToCurrency(newBalance);
            }
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            FinanceData data = new FinanceData(this);
            Functionality functionality = new Functionality(data);
            functionality.PayBalanceAsync();
        }
    }
}
