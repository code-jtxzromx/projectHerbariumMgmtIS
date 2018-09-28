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
    public sealed partial class HerbariumBoxForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public HerbariumBox BoxData
        {
            get { return (HerbariumBox)GetValue(BoxDataProperty); }
            set { SetValue(BoxDataProperty, value); }
        }

        public static readonly DependencyProperty BoxDataProperty =
            DependencyProperty.Register("BoxData", typeof(HerbariumBox), typeof(HerbariumBoxForm), new PropertyMetadata(new HerbariumBox()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(HerbariumBoxForm), new PropertyMetadata(""));

        // Constructor
        public HerbariumBoxForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Herbarium Box")
                {
                    TransactionResult = BoxData.AddHerbariumBox();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Herbarium Box")
                {
                    TransactionResult = BoxData.EditHerbariumBox();
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
            msgFamilyName.Visibility = Visibility.Collapsed;
            msgBoxLimit.Visibility = Visibility.Collapsed;
            msgRack.Visibility = Visibility.Collapsed;
            msgRackRow.Visibility = Visibility.Collapsed;
            msgRackColumn.Visibility = Visibility.Collapsed;

            if (cbxFamilyName.SelectedIndex == -1)
            {
                msgFamilyName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfBoxLimit.Text == "")
            {
                msgBoxLimit.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfRack.Text == "")
            {
                msgRack.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfRackRow.Text == "")
            {
                msgRackRow.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfRackColumn.Text == "")
            {
                msgRackColumn.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgFamilyName.Visibility = Visibility.Collapsed;
            msgBoxLimit.Visibility = Visibility.Collapsed;
            msgRack.Visibility = Visibility.Collapsed;
            msgRackRow.Visibility = Visibility.Collapsed;
            msgRackColumn.Visibility = Visibility.Collapsed;

            BoxData = new HerbariumBox();
            cbxFamilyName.ItemsSource = new TaxonFamily().GetFamilyList();

            TransactionForm = "Add Herbarium Box";
            PrimaryButtonText = "Save";
        }
    }
}
