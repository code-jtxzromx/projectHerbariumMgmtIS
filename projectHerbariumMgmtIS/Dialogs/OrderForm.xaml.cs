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
    public sealed partial class OrderForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonOrder OrderData
        {
            get { return (TaxonOrder)GetValue(OrderDataProperty); }
            set { SetValue(OrderDataProperty, value); }
        }

        public static readonly DependencyProperty OrderDataProperty =
            DependencyProperty.Register("OrderData", typeof(TaxonOrder), typeof(OrderForm), new PropertyMetadata(new TaxonOrder()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(OrderForm), new PropertyMetadata(""));

        // Constructor
        public OrderForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Order")
                {
                    TransactionResult = OrderData.AddOrder();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Order")
                {
                    TransactionResult = OrderData.EditOrder();
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
            msgClassName.Visibility = Visibility.Collapsed;
            msgOrderName.Visibility = Visibility.Collapsed;

            if (cbxClassName.SelectedIndex == -1)
            {
                msgClassName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfOrderName.Text == "")
            {
                msgOrderName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgClassName.Visibility = Visibility.Collapsed;
            msgOrderName.Visibility = Visibility.Collapsed;

            OrderData = new TaxonOrder();
            cbxClassName.ItemsSource = new TaxonClass().GetClassList();

            TransactionForm = "Add Order";
            PrimaryButtonText = "Save";
        }
    }
}
