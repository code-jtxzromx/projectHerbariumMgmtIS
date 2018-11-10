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
    public sealed partial class ExternalValidatorPage : Page
    {
        public ExternalValidatorPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrValidatorTable.ItemsSource = new Validator().GetValidators();

        private void btnAddValidator_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add External Validator");

        private void btnEditValidator_Click(object sender, RoutedEventArgs e)
        {
            if (dgrValidatorTable.SelectedIndex != -1)
                this.LoadForm("Edit External Validator", dgrValidatorTable.SelectedItem as Validator);
        }

        private async void LoadForm(string transaction, Validator validator = null)
        {
            ValidatorForm form = new ValidatorForm()
            {
                TransactionForm = transaction,
                ValidatorData = (validator == null) ? new Validator() : validator,
                PrimaryButtonText = (transaction == "Add External Validator") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add External Validator") ? "External Validator Inserted to the Database" : "External Validator Updated in the Database";
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
