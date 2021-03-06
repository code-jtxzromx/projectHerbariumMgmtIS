﻿using projectHerbariumMgmtIS.Model;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ApproveLoanForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public PlantLoan PlantLoanData
        {
            get { return (PlantLoan)GetValue(PlantLoanDataProperty); }
            set
            {
                SetValue(PlantLoanDataProperty, value);
                dgrLoanedSpecies.ItemsSource = new TaxonSpecies().GetLoanedSpecies(value.LoanNumber);
            }
        }

        public static readonly DependencyProperty PlantLoanDataProperty =
            DependencyProperty.Register("PlantLoanData", typeof(PlantLoan), typeof(ViewLoanForm), new PropertyMetadata(new PlantLoan()));

        // Constructor
        public ApproveLoanForm()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            TransactionResult = PlantLoanData.ConfirmPlantLoan("Approved");

            switch (TransactionResult)
            {
                case 0:
                    message = "Plant Loan will be processed";
                    break;
                case 1:
                    message = "Transaction Failed, The system had run to an Error";
                    break;
            }

            MessageDialog dialog = new MessageDialog(message, "Process Done");
            var result = dialog.ShowAsync();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            TransactionResult = PlantLoanData.ConfirmPlantLoan("Rejected");

            switch (TransactionResult)
            {
                case 0:
                    message = "Plant Loan will not be processed";
                    break;
                case 1:
                    message = "Transaction Failed, The system had run to an Error";
                    break;
            }

            MessageDialog dialog = new MessageDialog(message, "Process Done");
            var result = dialog.ShowAsync();
        }
    }
}
