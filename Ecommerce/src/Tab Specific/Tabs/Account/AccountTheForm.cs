using ProjectNS.AccountNS;
using System;
using System.Windows.Forms;

namespace ProjectNS.TheFormNS
{
    public partial class TheForm : Form
    {
        private class AccountData : IAccountData
        {
            private readonly TheForm _theForm;

            public AccountData(TheForm theForm)
            {
                _theForm = theForm;
            }

            public int UserId
            {
                set
                {
                    _theForm.UserId = value;
                }
            }

            public string Username
            {
                get
                {
                    return _theForm.username_textbox.Text;
                }
            }

            public string Password
            {
                get
                {
                    return _theForm.password_textbox.Text;
                }
            }

            /// <summary>
            /// Also sets the control to be visible.
            /// </summary>
            public void SetResponse(string response)
            {
                _theForm.credsResponse_label.Text = response;
                _theForm.credsResponse_label.Visible = true;
            }

            public bool LoggedIn
            {
                get
                {
                    return _theForm._loggedIn.val;
                }
                set
                {
                    _theForm._loggedIn.val = value;
                }
            }
        }



        private void logIn_Click(object sender, EventArgs e)
        {
            credsResponse_label.Text = "Attempting login.";

            AccountData data = new AccountData(this);
            Functionality functionality = new Functionality(data);
            functionality.LogInClickedAsync();
        }



        private void createAccount_Click(object sender, EventArgs e)
        {
            credsResponse_label.Text = "Validating new credentials.";

            AccountData data = new AccountData(this);
            Functionality functionality = new Functionality(data);
            functionality.CreateAccountClickedAsync();
        }



        private void logOut_button_Click(object sender, EventArgs e)
        {
            _loggedIn.val = false;
            credsResponse_label.Text = "You're logged out.";
            int invalidUserId = -1;
            UserId = invalidUserId;

            //Clearing data from pages.
            itemsPanelsContainer_panel.Controls.Clear();
            balanceAmount_label.Text = "";
            purchaseHistory_panel.Controls.Clear();
        }
    }
}
