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
    public sealed partial class GenusForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonGenus GenusData
        {
            get { return (TaxonGenus)GetValue(GenusDataProperty); }
            set { SetValue(GenusDataProperty, value); }
        }

        public static readonly DependencyProperty GenusDataProperty =
            DependencyProperty.Register("GenusData", typeof(TaxonGenus), typeof(GenusForm), new PropertyMetadata(new TaxonGenus()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(GenusForm), new PropertyMetadata(""));

        // Constructor
        public GenusForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Genus")
                {
                    TransactionResult = GenusData.AddGenus();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Genus")
                {
                    TransactionResult = GenusData.EditGenus();
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
            msgGenusName.Visibility = Visibility.Collapsed;

            if (cbxFamilyName.SelectedIndex == -1)
            {
                msgFamilyName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfGenusName.Text == "")
            {
                msgGenusName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgFamilyName.Visibility = Visibility.Collapsed;
            msgGenusName.Visibility = Visibility.Collapsed;

            GenusData = new TaxonGenus();
            cbxFamilyName.ItemsSource = new TaxonFamily().GetFamilyList();

            TransactionForm = "Add Genus";
            PrimaryButtonText = "Save";
        }
    }
}
