using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class AccountForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public Account AccountData
        {
            get { return (Account)GetValue(AccountDataProperty); }
            set { SetValue(AccountDataProperty, value); }
        }
        public bool IsEditTrans
        {
            get { return (bool)GetValue(IsEditTransProperty); }
            set { SetValue(IsEditTransProperty, value); }
        }

        public static readonly DependencyProperty AccountDataProperty =
            DependencyProperty.Register("AccountData", typeof(Account), typeof(AccountForm), new PropertyMetadata(new Account()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(AccountForm), new PropertyMetadata(""));
        public static readonly DependencyProperty IsEditTransProperty =
            DependencyProperty.Register("IsEditTrans", typeof(bool), typeof(AccountForm), new PropertyMetadata(false));



        // Constructor
        public AccountForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Access Accounts")
                {
                    TransactionResult = AccountData.AddAccount();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Access Accounts")
                {
                    TransactionResult = AccountData.EditAccount();
                    args.Cancel = false;
                }
            }
            else
                args.Cancel = true;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClearForm();
            args.Cancel = true;
        }

        // Methods
        private bool ValidateForm()
        {
            bool formOK = true;
            msgStaffName.Visibility = Visibility.Collapsed;
            msgUsername.Visibility = Visibility.Collapsed;
            msgPassword.Visibility = Visibility.Collapsed;

            if (cbxStaffName.SelectedIndex == -1)
            {
                msgStaffName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfUsername.Text == "")
            {
                msgUsername.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfPassword.Password == "")
            {
                msgPassword.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgStaffName.Visibility = Visibility.Collapsed;
            msgUsername.Visibility = Visibility.Collapsed;
            msgPassword.Visibility = Visibility.Collapsed;

            AccountData = new Account();
            cbxStaffName.ItemsSource = new Staff().GetStaffList();

            TransactionForm = "Add Access Account";
            PrimaryButtonText = "Save";
        }
    }
}
