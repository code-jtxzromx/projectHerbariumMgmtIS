﻿using projectHerbariumMgmtIS.Dialogs;
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
    public sealed partial class TaxonOrderPage : Page
    {
        public TaxonOrderPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrOrderTable.ItemsSource = new TaxonOrder().GetOrders();

        private void btnAddOrder_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Order");

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgrOrderTable.SelectedIndex != -1)
                this.LoadForm("Edit Order", dgrOrderTable.SelectedItem as TaxonOrder);
        }

        private async void LoadForm(string transaction, TaxonOrder order = null)
        {
            OrderForm form = new OrderForm()
            {
                TransactionForm = transaction,
                OrderData = (order == null) ? new TaxonOrder() : order,
                PrimaryButtonText = (transaction == "Add Order") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Order") ? "Order Inserted to the Database" : "Order Updated in the Database";
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
