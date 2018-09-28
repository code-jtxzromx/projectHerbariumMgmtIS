using projectHerbariumMgmtIS.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Maintenance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BorrowerPage : Page
    {
        public BorrowerPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrBorrowerTable.ItemsSource = new Borrower().GetBorrowers();

        private void btnAddBorrower_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Borrower");

        private void btnEditBorrower_Click(object sender, RoutedEventArgs e)
        {
            if (dgrBorrowerTable.SelectedIndex != -1)
                this.LoadForm("Edit Borrower", dgrBorrowerTable.SelectedItem as Borrower);
        }

        private async void LoadForm(string transaction, Borrower borrower = null)
        {
            BorrowerForm form = new BorrowerForm()
            {
                TransactionForm = transaction,
                BorrowerData = (borrower == null) ? new Borrower() : borrower,
                PrimaryButtonText = (transaction == "Add Borrower") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Borrower") ? "Borrower Added to the Database" : "Borrower Updated in the Database";
                        break;
                    case 1:
                        message = "The System had run to an Error";
                        break;
                    case 2:
                        message = "Information is Already Exists in the Database";
                        break;
                }

                ResultDialog dialog = new ResultDialog()
                {
                    TextContent = message
                };
                await dialog.ShowAsync();

                this.InitializePage();
            }
        }
    }
}
