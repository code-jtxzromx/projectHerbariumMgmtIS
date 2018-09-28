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
    public sealed partial class PhylumForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonPhylum PhylumData
        {
            get { return (TaxonPhylum)GetValue(PhylumDataProperty); }
            set
            {
                SetValue(PhylumDataProperty, value);
                if (value.DomainName != "Eukaryota" || value.KingdomName != "Plantae")
                    chkIsKingdomPlant.IsChecked = false;
            }
        }

        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(PhylumForm), new PropertyMetadata(""));
        public static readonly DependencyProperty PhylumDataProperty =
            DependencyProperty.Register("PhylumData", typeof(TaxonPhylum), typeof(PhylumForm), new PropertyMetadata(new TaxonPhylum()));

        // Constructor
        public PhylumForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void chkIsKingdomPlant_CheckChanged(object sender, RoutedEventArgs e)
        {
            txfDomainName.IsEnabled = !(chkIsKingdomPlant.IsChecked == true);
            txfKingdomName.IsEnabled = !(chkIsKingdomPlant.IsChecked == true);
            txfDomainName.Text = (chkIsKingdomPlant.IsChecked == true) ? "Eukaryota" : "";
            txfKingdomName.Text = (chkIsKingdomPlant.IsChecked == true) ? "Plantae" : "";
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Phylum")
                {
                    TransactionResult = PhylumData.AddPhylum();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Phylum")
                {
                    TransactionResult = PhylumData.EditPhylum();
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
            msgDomainName.Visibility = Visibility.Collapsed;
            msgKingdomName.Visibility = Visibility.Collapsed;
            msgPhylumName.Visibility = Visibility.Collapsed;

            if (txfDomainName.Text == "")
            {
                msgDomainName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfKingdomName.Text == "")
            {
                msgKingdomName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfPhylumName.Text == "")
            {
                msgPhylumName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgDomainName.Visibility = Visibility.Collapsed;
            msgKingdomName.Visibility = Visibility.Collapsed;
            msgPhylumName.Visibility = Visibility.Collapsed;

            PhylumData = new TaxonPhylum();

            chkIsKingdomPlant.IsChecked = true;
            chkIsKingdomPlant_CheckChanged(chkIsKingdomPlant, null);

            TransactionForm = "Add Phylum";
            PrimaryButtonText = "Save";
        }
    }
}
