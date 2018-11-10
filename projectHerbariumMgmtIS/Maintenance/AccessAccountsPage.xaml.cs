using projectHerbariumMgmtIS.Dialogs;
using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Maintenance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccessAccountsPage : Page
    {
        public AccessAccountsPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrAccountTable.ItemsSource = new Account().GetAccounts();

        private void btnAddAccount_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Access Account");

        private void btnEditAccount_Click(object sender, RoutedEventArgs e)
        {
            if (dgrAccountTable.SelectedIndex != -1)
                this.LoadForm("Edit Access Account", dgrAccountTable.SelectedItem as Account);
        }

        private async void LoadForm(string transaction, Account account = null)
        {
            AccountForm form = new AccountForm()
            {
                TransactionForm = transaction,
                AccountData = (account == null) ? new Account() : account,
                PrimaryButtonText = (transaction == "Add Access Account") ? "Save" : "Update",
                IsEditTrans = (transaction == "Add Access Account")
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Access Account") ? "Access Account Inserted to the Database" : "Access Account Updated in the Database";
                        break;
                    case 1:
                        message = "The System had run to an Error";
                        break;
                    case 2:
                        message = "Information is Already Exists in the Database";
                        break;
                }

                MessageDialog dialog = new MessageDialog(message);
                await dialog.ShowAsync();

                this.InitializePage();
            }
        }
    }
}
