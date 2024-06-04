using System.Windows.Forms;

namespace ProjectNS.TheFormNS
{
    public partial class TheForm: System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.logIn_button = new System.Windows.Forms.Button();
            this.createAccount_button = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.account_tabPage = new System.Windows.Forms.TabPage();
            this.logOut_button = new System.Windows.Forms.Button();
            this.credsResponse_label = new System.Windows.Forms.Label();
            this.enterCreds_label = new System.Windows.Forms.Label();
            this.placeOrder_tabPage = new System.Windows.Forms.TabPage();
            this.cantOrder_label = new System.Windows.Forms.Label();
            this.orderPlacedLabel = new System.Windows.Forms.Label();
            this.itemsPanelsContainer_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.placeOrder_button = new System.Windows.Forms.Button();
            this.finance_tabPage = new System.Windows.Forms.TabPage();
            this.amountToPay_textbox = new System.Windows.Forms.TextBox();
            this.payBalance_button = new System.Windows.Forms.Button();
            this.balanceAmount_label = new System.Windows.Forms.Label();
            this.balance_label = new System.Windows.Forms.Label();
            this.purchaseHistory_tabPage = new System.Windows.Forms.TabPage();
            this.valuesAreExclusive_label = new System.Windows.Forms.Label();
            this.showHistory_button = new System.Windows.Forms.Button();
            this.filterPurchaseHistory_label = new System.Windows.Forms.Label();
            this.upperPriceRange_label = new System.Windows.Forms.Label();
            this.lowerPriceRange_label = new System.Windows.Forms.Label();
            this.upperPriceRange = new System.Windows.Forms.NumericUpDown();
            this.lowerPriceRange = new System.Windows.Forms.NumericUpDown();
            this.endDateTimePicker_label = new System.Windows.Forms.Label();
            this.purchaseHistory_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.startDateTimePicker_label = new System.Windows.Forms.Label();
            this.end_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.start_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabControl.SuspendLayout();
            this.account_tabPage.SuspendLayout();
            this.placeOrder_tabPage.SuspendLayout();
            this.finance_tabPage.SuspendLayout();
            this.purchaseHistory_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceRange)).BeginInit();
            this.SuspendLayout();
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(760, 122);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(100, 20);
            this.username_textbox.TabIndex = 1;
            this.username_textbox.Text = "username";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(760, 173);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 20);
            this.password_textbox.TabIndex = 2;
            this.password_textbox.Text = "password";
            // 
            // logIn_button
            // 
            this.logIn_button.Location = new System.Drawing.Point(692, 227);
            this.logIn_button.Name = "logIn_button";
            this.logIn_button.Size = new System.Drawing.Size(75, 23);
            this.logIn_button.TabIndex = 3;
            this.logIn_button.Text = "Log in";
            this.logIn_button.UseVisualStyleBackColor = true;
            this.logIn_button.Click += new System.EventHandler(this.logIn_Click);
            // 
            // createAccount_button
            // 
            this.createAccount_button.Location = new System.Drawing.Point(845, 227);
            this.createAccount_button.Name = "createAccount_button";
            this.createAccount_button.Size = new System.Drawing.Size(107, 23);
            this.createAccount_button.TabIndex = 4;
            this.createAccount_button.Text = "Create account";
            this.createAccount_button.UseVisualStyleBackColor = true;
            this.createAccount_button.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.account_tabPage);
            this.tabControl.Controls.Add(this.placeOrder_tabPage);
            this.tabControl.Controls.Add(this.finance_tabPage);
            this.tabControl.Controls.Add(this.purchaseHistory_tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1847, 890);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // account_tabPage
            // 
            this.account_tabPage.Controls.Add(this.logOut_button);
            this.account_tabPage.Controls.Add(this.credsResponse_label);
            this.account_tabPage.Controls.Add(this.enterCreds_label);
            this.account_tabPage.Controls.Add(this.username_textbox);
            this.account_tabPage.Controls.Add(this.createAccount_button);
            this.account_tabPage.Controls.Add(this.password_textbox);
            this.account_tabPage.Controls.Add(this.logIn_button);
            this.account_tabPage.Location = new System.Drawing.Point(4, 22);
            this.account_tabPage.Name = "account_tabPage";
            this.account_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.account_tabPage.Size = new System.Drawing.Size(1839, 864);
            this.account_tabPage.TabIndex = 0;
            this.account_tabPage.Text = "Account";
            this.account_tabPage.UseVisualStyleBackColor = true;
            // 
            // logOut_button
            // 
            this.logOut_button.Location = new System.Drawing.Point(774, 396);
            this.logOut_button.Name = "logOut_button";
            this.logOut_button.Size = new System.Drawing.Size(75, 23);
            this.logOut_button.TabIndex = 6;
            this.logOut_button.Text = "Log out";
            this.logOut_button.UseVisualStyleBackColor = true;
            this.logOut_button.Click += new System.EventHandler(this.logOut_button_Click);
            // 
            // credsResponse_label
            // 
            this.credsResponse_label.AutoSize = true;
            this.credsResponse_label.Location = new System.Drawing.Point(771, 334);
            this.credsResponse_label.Name = "credsResponse_label";
            this.credsResponse_label.Size = new System.Drawing.Size(107, 13);
            this.credsResponse_label.TabIndex = 5;
            this.credsResponse_label.Text = "credsResponseLabel";
            this.credsResponse_label.Visible = false;
            // 
            // enterCreds_label
            // 
            this.enterCreds_label.AutoSize = true;
            this.enterCreds_label.Location = new System.Drawing.Point(757, 86);
            this.enterCreds_label.Name = "enterCreds_label";
            this.enterCreds_label.Size = new System.Drawing.Size(92, 13);
            this.enterCreds_label.TabIndex = 1;
            this.enterCreds_label.Text = "Enter creds below";
            // 
            // placeOrder_tabPage
            // 
            this.placeOrder_tabPage.Controls.Add(this.cantOrder_label);
            this.placeOrder_tabPage.Controls.Add(this.orderPlacedLabel);
            this.placeOrder_tabPage.Controls.Add(this.itemsPanelsContainer_panel);
            this.placeOrder_tabPage.Controls.Add(this.placeOrder_button);
            this.placeOrder_tabPage.Location = new System.Drawing.Point(4, 22);
            this.placeOrder_tabPage.Name = "placeOrder_tabPage";
            this.placeOrder_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.placeOrder_tabPage.Size = new System.Drawing.Size(1839, 864);
            this.placeOrder_tabPage.TabIndex = 1;
            this.placeOrder_tabPage.Text = "Place Order";
            this.placeOrder_tabPage.UseVisualStyleBackColor = true;
            // 
            // cantOrder_label
            // 
            this.cantOrder_label.AutoSize = true;
            this.cantOrder_label.Location = new System.Drawing.Point(416, 637);
            this.cantOrder_label.Name = "cantOrder_label";
            this.cantOrder_label.Size = new System.Drawing.Size(82, 13);
            this.cantOrder_label.TabIndex = 5;
            this.cantOrder_label.Text = "can\'t order label";
            this.cantOrder_label.Visible = false;
            // 
            // orderPlacedLabel
            // 
            this.orderPlacedLabel.AutoSize = true;
            this.orderPlacedLabel.Location = new System.Drawing.Point(771, 130);
            this.orderPlacedLabel.Name = "orderPlacedLabel";
            this.orderPlacedLabel.Size = new System.Drawing.Size(0, 13);
            this.orderPlacedLabel.TabIndex = 4;
            // 
            // itemsPanelsContainer_panel
            // 
            this.itemsPanelsContainer_panel.AutoScroll = true;
            this.itemsPanelsContainer_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPanelsContainer_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.itemsPanelsContainer_panel.Location = new System.Drawing.Point(310, 47);
            this.itemsPanelsContainer_panel.Name = "itemsPanelsContainer_panel";
            this.itemsPanelsContainer_panel.Size = new System.Drawing.Size(1183, 558);
            this.itemsPanelsContainer_panel.TabIndex = 2;
            this.itemsPanelsContainer_panel.WrapContents = false;
            // 
            // placeOrder_button
            // 
            this.placeOrder_button.Location = new System.Drawing.Point(310, 632);
            this.placeOrder_button.Name = "placeOrder_button";
            this.placeOrder_button.Size = new System.Drawing.Size(75, 23);
            this.placeOrder_button.TabIndex = 0;
            this.placeOrder_button.Text = "Place order";
            this.placeOrder_button.UseVisualStyleBackColor = true;
            this.placeOrder_button.Click += new System.EventHandler(this.placeOrderButton_Click);
            // 
            // finance_tabPage
            // 
            this.finance_tabPage.Controls.Add(this.amountToPay_textbox);
            this.finance_tabPage.Controls.Add(this.payBalance_button);
            this.finance_tabPage.Controls.Add(this.balanceAmount_label);
            this.finance_tabPage.Controls.Add(this.balance_label);
            this.finance_tabPage.Location = new System.Drawing.Point(4, 22);
            this.finance_tabPage.Name = "finance_tabPage";
            this.finance_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.finance_tabPage.Size = new System.Drawing.Size(1839, 864);
            this.finance_tabPage.TabIndex = 2;
            this.finance_tabPage.Text = "Finance";
            this.finance_tabPage.UseVisualStyleBackColor = true;
            // 
            // amountToPay_textbox
            // 
            this.amountToPay_textbox.Location = new System.Drawing.Point(660, 179);
            this.amountToPay_textbox.Name = "amountToPay_textbox";
            this.amountToPay_textbox.Size = new System.Drawing.Size(113, 20);
            this.amountToPay_textbox.TabIndex = 3;
            this.amountToPay_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // payBalance_button
            // 
            this.payBalance_button.Location = new System.Drawing.Point(633, 141);
            this.payBalance_button.Name = "payBalance_button";
            this.payBalance_button.Size = new System.Drawing.Size(179, 23);
            this.payBalance_button.TabIndex = 2;
            this.payBalance_button.Text = "Pay the amount entered below";
            this.payBalance_button.UseVisualStyleBackColor = true;
            this.payBalance_button.Click += new System.EventHandler(this.payButton_Click);
            // 
            // balanceAmount_label
            // 
            this.balanceAmount_label.Location = new System.Drawing.Point(712, 94);
            this.balanceAmount_label.Name = "balanceAmount_label";
            this.balanceAmount_label.Size = new System.Drawing.Size(100, 23);
            this.balanceAmount_label.TabIndex = 1;
            // 
            // balance_label
            // 
            this.balance_label.AutoSize = true;
            this.balance_label.Location = new System.Drawing.Point(657, 94);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(49, 13);
            this.balance_label.TabIndex = 0;
            this.balance_label.Text = "Balance:";
            // 
            // purchaseHistory_tabPage
            // 
            this.purchaseHistory_tabPage.Controls.Add(this.valuesAreExclusive_label);
            this.purchaseHistory_tabPage.Controls.Add(this.showHistory_button);
            this.purchaseHistory_tabPage.Controls.Add(this.filterPurchaseHistory_label);
            this.purchaseHistory_tabPage.Controls.Add(this.upperPriceRange_label);
            this.purchaseHistory_tabPage.Controls.Add(this.lowerPriceRange_label);
            this.purchaseHistory_tabPage.Controls.Add(this.upperPriceRange);
            this.purchaseHistory_tabPage.Controls.Add(this.lowerPriceRange);
            this.purchaseHistory_tabPage.Controls.Add(this.endDateTimePicker_label);
            this.purchaseHistory_tabPage.Controls.Add(this.purchaseHistory_panel);
            this.purchaseHistory_tabPage.Controls.Add(this.startDateTimePicker_label);
            this.purchaseHistory_tabPage.Controls.Add(this.end_dateTimePicker);
            this.purchaseHistory_tabPage.Controls.Add(this.start_dateTimePicker);
            this.purchaseHistory_tabPage.Location = new System.Drawing.Point(4, 22);
            this.purchaseHistory_tabPage.Name = "purchaseHistory_tabPage";
            this.purchaseHistory_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.purchaseHistory_tabPage.Size = new System.Drawing.Size(1839, 864);
            this.purchaseHistory_tabPage.TabIndex = 3;
            this.purchaseHistory_tabPage.Text = "Purchase History";
            this.purchaseHistory_tabPage.UseVisualStyleBackColor = true;
            // 
            // valuesAreExclusive_label
            // 
            this.valuesAreExclusive_label.AutoSize = true;
            this.valuesAreExclusive_label.Location = new System.Drawing.Point(823, 49);
            this.valuesAreExclusive_label.Name = "valuesAreExclusive_label";
            this.valuesAreExclusive_label.Size = new System.Drawing.Size(120, 13);
            this.valuesAreExclusive_label.TabIndex = 12;
            this.valuesAreExclusive_label.Text = "All values are exclusive.";
            // 
            // showHistory_button
            // 
            this.showHistory_button.Location = new System.Drawing.Point(826, 163);
            this.showHistory_button.Name = "showHistory_button";
            this.showHistory_button.Size = new System.Drawing.Size(125, 23);
            this.showHistory_button.TabIndex = 11;
            this.showHistory_button.Text = "Show History";
            this.showHistory_button.UseVisualStyleBackColor = true;
            this.showHistory_button.Click += new System.EventHandler(this.showHistory_button_Click);
            // 
            // filterPurchaseHistory_label
            // 
            this.filterPurchaseHistory_label.AutoSize = true;
            this.filterPurchaseHistory_label.Location = new System.Drawing.Point(677, 29);
            this.filterPurchaseHistory_label.Name = "filterPurchaseHistory_label";
            this.filterPurchaseHistory_label.Size = new System.Drawing.Size(467, 13);
            this.filterPurchaseHistory_label.TabIndex = 10;
            this.filterPurchaseHistory_label.Text = "Filter the purchases by price or date. Leave them on their defaults if you wish t" +
    "o see all purchases.";
            // 
            // upperPriceRange_label
            // 
            this.upperPriceRange_label.AutoSize = true;
            this.upperPriceRange_label.Location = new System.Drawing.Point(950, 119);
            this.upperPriceRange_label.Name = "upperPriceRange_label";
            this.upperPriceRange_label.Size = new System.Drawing.Size(74, 13);
            this.upperPriceRange_label.TabIndex = 9;
            this.upperPriceRange_label.Text = "Upper Range:";
            // 
            // lowerPriceRange_label
            // 
            this.lowerPriceRange_label.AutoSize = true;
            this.lowerPriceRange_label.Location = new System.Drawing.Point(950, 82);
            this.lowerPriceRange_label.Name = "lowerPriceRange_label";
            this.lowerPriceRange_label.Size = new System.Drawing.Size(74, 13);
            this.lowerPriceRange_label.TabIndex = 8;
            this.lowerPriceRange_label.Text = "Lower Range:";
            // 
            // upperPriceRange
            // 
            this.upperPriceRange.Location = new System.Drawing.Point(1030, 115);
            this.upperPriceRange.Name = "upperPriceRange";
            this.upperPriceRange.Size = new System.Drawing.Size(120, 20);
            this.upperPriceRange.TabIndex = 7;
            this.upperPriceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lowerPriceRange
            // 
            this.lowerPriceRange.Location = new System.Drawing.Point(1030, 80);
            this.lowerPriceRange.Name = "lowerPriceRange";
            this.lowerPriceRange.Size = new System.Drawing.Size(120, 20);
            this.lowerPriceRange.TabIndex = 6;
            this.lowerPriceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lowerPriceRange.ThousandsSeparator = true;
            // 
            // endDateTimePicker_label
            // 
            this.endDateTimePicker_label.AutoSize = true;
            this.endDateTimePicker_label.Location = new System.Drawing.Point(585, 119);
            this.endDateTimePicker_label.Name = "endDateTimePicker_label";
            this.endDateTimePicker_label.Size = new System.Drawing.Size(29, 13);
            this.endDateTimePicker_label.TabIndex = 5;
            this.endDateTimePicker_label.Text = "End:";
            // 
            // purchaseHistory_panel
            // 
            this.purchaseHistory_panel.AutoScroll = true;
            this.purchaseHistory_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.purchaseHistory_panel.Location = new System.Drawing.Point(569, 226);
            this.purchaseHistory_panel.Name = "purchaseHistory_panel";
            this.purchaseHistory_panel.Size = new System.Drawing.Size(655, 286);
            this.purchaseHistory_panel.TabIndex = 4;
            this.purchaseHistory_panel.WrapContents = false;
            // 
            // startDateTimePicker_label
            // 
            this.startDateTimePicker_label.AutoSize = true;
            this.startDateTimePicker_label.Location = new System.Drawing.Point(582, 82);
            this.startDateTimePicker_label.Name = "startDateTimePicker_label";
            this.startDateTimePicker_label.Size = new System.Drawing.Size(32, 13);
            this.startDateTimePicker_label.TabIndex = 3;
            this.startDateTimePicker_label.Text = "Start:";
            // 
            // end_dateTimePicker
            // 
            this.end_dateTimePicker.Location = new System.Drawing.Point(620, 115);
            this.end_dateTimePicker.Name = "end_dateTimePicker";
            this.end_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.end_dateTimePicker.TabIndex = 2;
            // 
            // start_dateTimePicker
            // 
            this.start_dateTimePicker.Location = new System.Drawing.Point(620, 80);
            this.start_dateTimePicker.Name = "start_dateTimePicker";
            this.start_dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.start_dateTimePicker.TabIndex = 1;
            this.start_dateTimePicker.Value = new System.DateTime(2024, 4, 22, 0, 0, 0, 0);
            // 
            // TheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1847, 890);
            this.Controls.Add(this.tabControl);
            this.Name = "TheForm";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.account_tabPage.ResumeLayout(false);
            this.account_tabPage.PerformLayout();
            this.placeOrder_tabPage.ResumeLayout(false);
            this.placeOrder_tabPage.PerformLayout();
            this.finance_tabPage.ResumeLayout(false);
            this.finance_tabPage.PerformLayout();
            this.purchaseHistory_tabPage.ResumeLayout(false);
            this.purchaseHistory_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceRange)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DateTimePicker end_dateTimePicker;
        private System.Windows.Forms.DateTimePicker start_dateTimePicker;
        private System.Windows.Forms.Label startDateTimePicker_label;
        private System.Windows.Forms.Label endDateTimePicker_label;
        private System.Windows.Forms.NumericUpDown upperPriceRange;
        private System.Windows.Forms.NumericUpDown lowerPriceRange;
        private System.Windows.Forms.FlowLayoutPanel purchaseHistory_panel;
        private System.Windows.Forms.Label lowerPriceRange_label;
        private System.Windows.Forms.Label upperPriceRange_label;
        private System.Windows.Forms.Label filterPurchaseHistory_label;
        private System.Windows.Forms.Button showHistory_button;
        private System.Windows.Forms.Label valuesAreExclusive_label;
        private System.Windows.Forms.Label orderPlacedLabel;
        private System.Windows.Forms.FlowLayoutPanel itemsPanelsContainer_panel;
        private System.Windows.Forms.Button placeOrder_button;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Button logIn_button;
        private System.Windows.Forms.Button createAccount_button;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage account_tabPage;
        private System.Windows.Forms.Label enterCreds_label;
        private System.Windows.Forms.TabPage finance_tabPage;
        private System.Windows.Forms.TabPage purchaseHistory_tabPage;
        private System.Windows.Forms.Label balanceAmount_label;
        private System.Windows.Forms.Label balance_label;
        private System.Windows.Forms.Button payBalance_button;
        private System.Windows.Forms.TextBox amountToPay_textbox;
        private System.Windows.Forms.TabPage placeOrder_tabPage;
        private Label credsResponse_label;
        private Button logOut_button;
        private Label cantOrder_label;
    }
}