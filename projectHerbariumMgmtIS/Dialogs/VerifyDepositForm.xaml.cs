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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class VerifyDepositForm : ContentDialog
    {
        private int TransactionResult;

        // Properties
        public PlantDeposit VerifyingDepositData
        {
            get { return (PlantDeposit)GetValue(VerifyingDepositDataProperty); }
            set { SetValue(VerifyingDepositDataProperty, value); }
        }
        public BitmapImage HerbariumSheet
        {
            get { return (BitmapImage)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty VerifyingDepositDataProperty =
            DependencyProperty.Register("VerifyingDepositData", typeof(PlantDeposit), typeof(VerifyDepositForm), new PropertyMetadata(new PlantDeposit()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(BitmapImage), typeof(VerifyDepositForm), new PropertyMetadata(new BitmapImage()));

        // Constructor
        public VerifyDepositForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void cbxTaxonName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string AccessionNumber = "";
            string TaxonName;
            cbxReferenceAccession.ItemsSource = null;

            if (cbxTaxonName.SelectedIndex != -1)
            {
                TaxonName = cbxTaxonName.SelectedItem as string;
                cbxReferenceAccession.ItemsSource = new PlantDeposit().GetVerifiedAccessions(TaxonName);

                if (VerifyingDepositData.IsDuplicateHerbarium(TaxonName, ref AccessionNumber))
                {
                    chkSameAccession.IsChecked = true;
                    cbxReferenceAccession.SelectedItem = AccessionNumber;
                }
                else
                    chkSameAccession.IsChecked = false;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (ValidateForm())
            {
                string message = "";
                string ReferenceAccession = (chkSameAccession.IsChecked == true) 
                                                ? cbxReferenceAccession.SelectedItem as string : VerifyingDepositData.AccessionNumber;

                TransactionResult = VerifyingDepositData.VerifyDeposit(cbxTaxonName.SelectedItem as string, ReferenceAccession);

                switch (TransactionResult)
                {
                    case 0:
                        message = "Herbarium Sheet is Now Verified";
                        break;
                    case 1:
                        message = "Transaction Failed, The system had run to an Error";
                        break;
                }

                MessageDialog dialog = new MessageDialog(message, "Process Done");
                var result = dialog.ShowAsync();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            string TaxonName = (cbxTaxonName.SelectedIndex != -1) ? cbxTaxonName.SelectedItem as string : null;
            string ReferencesAccession = (chkSameAccession.IsChecked == true && cbxReferenceAccession.SelectedIndex != -1) ?
                                            cbxReferenceAccession.SelectedItem as string : null;

            TransactionResult = VerifyingDepositData.FurtherVerifyDeposit(TaxonName, ReferencesAccession);

            switch (TransactionResult)
            {
                case 0:
                    message = "Herbarium Sheet will be Verified to Other Herbarium Centers";
                    break;
                case 1:
                    message = "Transaction Failed, The system had run to an Error";
                    break;
            }

            MessageDialog dialog = new MessageDialog(message, "Process Done");
            var result = dialog.ShowAsync();
        }

        // Methods
        private void ClearForm()
        {
            cbxTaxonName.ItemsSource = new TaxonSpecies().GetTaxonList();
            cbxReferenceAccession.ItemsSource = null;

            VerifyingDepositData = new PlantDeposit();
        }

        private bool ValidateForm()
        {
            bool formOK = true;
            msgTaxonName.Visibility = Visibility.Collapsed;
            msgReferenceAccession.Visibility = Visibility.Collapsed;

            if (cbxTaxonName.SelectedIndex == -1)
            {
                msgTaxonName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (chkSameAccession.IsChecked == true && cbxReferenceAccession.SelectedIndex == -1)
            {
                msgReferenceAccession.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }
    }
}
