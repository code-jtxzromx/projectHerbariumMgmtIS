using Microsoft.Toolkit.Uwp.Helpers;
using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Reports
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportDamagedReturns : Page
    {
        private PrintHelper printHelper;
        private DateTime MonthStart, MonthEnd;
        private string SelectedBorrower, SelectedLoan;

        private List<string> BorrowersList;
        private List<string> LoanList;
        List<string> Months = new List<string>()
            { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public ReportDamagedReturns()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage()
        {
            cbxMonth.ItemsSource = Months;
            BorrowersList = new Borrower().GetBorrowerList();
            LoanList = new PlantLoan().GetPastLoanList();

            cbxYear.Items.Clear();
            for (int yy = DateTime.Today.Year; yy >= 1970; yy--)
            {
                cbxYear.Items.Add(yy);
            }

            cbxMonth.SelectedIndex = DateTime.Today.Month - 1;
            cbxYear.SelectedItem = DateTime.Today.Year;

            rbtByMonth.IsChecked = true;
            rbtReportType_CheckChanged(rbtByMonth, null);
        }

        private void rbtReportType_CheckChanged(object sender, RoutedEventArgs e)
        {
            dgrReportResult.ItemsSource = null;

            btnPrintA.Visibility = Visibility.Collapsed;
            btnPrintB.Visibility = Visibility.Collapsed;
            btnPrintC.Visibility = Visibility.Collapsed;
        }

        #region Month

        private void btnLoadA_Click(object sender, RoutedEventArgs e)
        {
            string date = (cbxMonth.SelectedIndex + 1) + "/" + "1/" + cbxYear.SelectedItem;
            DateTime startDate = DateTime.Parse(date);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            MonthStart = startDate;
            MonthEnd = endDate;
            dgrReportResult.ItemsSource = new HerbariumSheet().GetDamagedSheetReport(MonthStart.ToString(), MonthEnd.ToString());
            btnPrintA.Visibility = Visibility.Visible;
        }

        private async void btnPrintA_Click(object sender, RoutedEventArgs e)
        {
            DocumentDamageReturnsByMonth form = new DocumentDamageReturnsByMonth(
                new HerbariumSheet().GetDamagedSheetReport(MonthStart.ToString(), MonthEnd.ToString()))
            {
                Year = MonthStart.Year,
                Month = Months[MonthStart.Month - 1],
            };

            printHelper = new PrintHelper(this.PrintContainer);
            printHelper.AddFrameworkElementToPrint(form);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = PrintOrientation.Portrait;

            await printHelper.ShowPrintUIAsync("Herbarium Management IS - List of New Deposits", printHelperOptions);
            //printHelper.PreparePrintContent(new DocumentNewDeposit());
        }

        #endregion

        #region Borrower

        private void txfBorrower_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = from borrower in BorrowersList
                                  where borrower.ToUpper().Contains(sender.Text.ToUpper())
                                  select borrower;

                if (suggestions.Count() > 0)
                    sender.ItemsSource = suggestions;
                else
                    sender.ItemsSource = null;
            }
        }

        private void btnLoadB_Click(object sender, RoutedEventArgs e)
        {
            SelectedBorrower = txfBorrower.Text;
            dgrReportResult.ItemsSource = new HerbariumSheet().GetDamagedSheetReportByBorrower(SelectedBorrower);
            btnPrintB.Visibility = Visibility.Visible;
        }

        private async void btnPrintB_Click(object sender, RoutedEventArgs e)
        {
            DocumentDamageReturnsByBorrower form = new DocumentDamageReturnsByBorrower(
                new HerbariumSheet().GetDamagedSheetReportByBorrower(SelectedBorrower))
            {
                Borrower = SelectedBorrower
            };

            printHelper = new PrintHelper(this.PrintContainer);
            printHelper.AddFrameworkElementToPrint(form);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = PrintOrientation.Portrait;

            await printHelper.ShowPrintUIAsync("Herbarium Management IS - List of New Deposits", printHelperOptions);
            //printHelper.PreparePrintContent(new DocumentNewDeposit());
        }

        #endregion

        #region LoanTransactions

        private void txfLoanNumber_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = from loan in LoanList
                                  where loan.ToUpper().Contains(sender.Text.ToUpper())
                                  select loan;

                if (suggestions.Count() > 0)
                    sender.ItemsSource = suggestions;
                else
                    sender.ItemsSource = null;
            }
        }

        private void btnLoadC_Click(object sender, RoutedEventArgs e)
        {
            SelectedLoan = txfLoanNumber.Text;
            dgrReportResult.ItemsSource = new HerbariumSheet().GetDamagedSheetReportByLoan(SelectedLoan);
            btnPrintC.Visibility = Visibility.Visible;
        }

        private async void btnPrintC_Click(object sender, RoutedEventArgs e)
        {
            DocumentDamageReturnsByLoan form = new DocumentDamageReturnsByLoan(
                new HerbariumSheet().GetDamagedSheetReportByLoan(SelectedLoan));
            printHelper = new PrintHelper(this.PrintContainer);
            printHelper.AddFrameworkElementToPrint(form);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = PrintOrientation.Portrait;

            await printHelper.ShowPrintUIAsync("Herbarium Management IS - List of New Deposits", printHelperOptions);
            //printHelper.PreparePrintContent(new DocumentNewDeposit());
        }

        #endregion
    }
}
