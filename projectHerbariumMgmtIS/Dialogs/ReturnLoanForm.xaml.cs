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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ReturnLoanForm : ContentDialog
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
                dgrLoanedSheets.ItemsSource = new HerbariumSheet().GetLoanedSheets(value.LoanNumber);
            }
        }

        public static readonly DependencyProperty PlantLoanDataProperty =
            DependencyProperty.Register("PlantLoanData", typeof(PlantLoan), typeof(ViewLoanForm), new PropertyMetadata(new PlantLoan()));

        // Constructor
        public ReturnLoanForm()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            TransactionResult = PlantLoanData.ReturnPlantLoan();

            switch (TransactionResult)
            {
                case 0:
                    message = "Loaned Species are now returned to the center";
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
