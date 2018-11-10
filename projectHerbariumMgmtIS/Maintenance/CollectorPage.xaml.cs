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
    public sealed partial class CollectorPage : Page
    {
        public CollectorPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrCollectorTable.ItemsSource = new Collector().GetCollectors();

        private void btnAddCollector_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Collector");

        private void btnEditCollector_Click(object sender, RoutedEventArgs e)
        {
            if (dgrCollectorTable.SelectedIndex != -1)
                this.LoadForm("Edit Collector", dgrCollectorTable.SelectedItem as Collector);
        }

        private async void LoadForm(string transaction, Collector collector = null)
        {
            CollectorForm form = new CollectorForm()
            {
                TransactionForm = transaction,
                CollectorData = (collector == null) ? new Collector() : collector,
                PrimaryButtonText = (transaction == "Add Collector") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Collector") ? "Collector Inserted to the Database" : "Collector Updated in the Database";
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
