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
    public sealed partial class ReportVerifiedDepositPage : Page
    {
        private PrintHelper printHelper;
        private DateTime MonthStart, MonthEnd;

        List<string> Months = new List<string>()
            { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public ReportVerifiedDepositPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage()
        {
            cbxMonth.ItemsSource = Months;

            cbxYear.Items.Clear();
            for (int yy = DateTime.Today.Year; yy >= 1970; yy--)
            {
                cbxYear.Items.Add(yy);
            }

            cbxMonth.SelectedIndex = DateTime.Today.Month - 1;
            cbxYear.SelectedItem = DateTime.Today.Year;
            btnPrint.Visibility = Visibility.Collapsed;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string date = (cbxMonth.SelectedIndex + 1) + "/" + "1/" + cbxYear.SelectedItem;
            DateTime startDate = DateTime.Parse(date);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            MonthStart = startDate;
            MonthEnd = endDate;
            dgrReportResult.ItemsSource = new HerbariumSheet().GetVerifiedDepositReport(startDate.ToString(), endDate.ToString());
            btnPrint.Visibility = Visibility.Visible;
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DocumentVerifiedDeposit form = new DocumentVerifiedDeposit(new HerbariumSheet().GetVerifiedDepositReport(MonthStart.ToString(), MonthEnd.ToString()))
            {
                Year = MonthStart.Year,
                Month = Months[MonthStart.Month - 1],
            };

            printHelper = new PrintHelper(this.PrintContainer);
            printHelper.AddFrameworkElementToPrint(form);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = PrintOrientation.Portrait;

            await printHelper.ShowPrintUIAsync("Herbarium Management IS - List of Verified Deposits", printHelperOptions);
            //printHelper.PreparePrintContent(new DocumentNewDeposit());
        }
    }
}
