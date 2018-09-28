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
    public sealed partial class TaxonGenusPage : Page
    {
        public TaxonGenusPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrGenusTable.ItemsSource = new TaxonGenus().GetGenera();

        private void btnAddGenus_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Genus");

        private void btnEditGenus_Click(object sender, RoutedEventArgs e)
        {
            if (dgrGenusTable.SelectedIndex != -1)
                this.LoadForm("Edit Genus", dgrGenusTable.SelectedItem as TaxonGenus);
        }

        private async void LoadForm(string transaction, TaxonGenus genus = null)
        {
            GenusForm form = new GenusForm()
            {
                TransactionForm = transaction,
                GenusData = (genus == null) ? new TaxonGenus() : genus,
                PrimaryButtonText = (transaction == "Add Genus") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Genus") ? "Genus Added to the Database" : "Genus Updated in the Database";
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
