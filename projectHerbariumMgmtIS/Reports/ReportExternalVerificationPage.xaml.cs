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
    public sealed partial class ReportExternalVerificationPage : Page
    {
        private PrintHelper printHelper;

        public ReportExternalVerificationPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage()
        {
            dgrReportResult.ItemsSource = new PlantDeposit().GetFurtherVerifyDepositReport();
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DocumentExternalVerification form = new DocumentExternalVerification(new PlantDeposit().GetFurtherVerifyDepositReport());

            printHelper = new PrintHelper(this.PrintContainer);
            printHelper.AddFrameworkElementToPrint(form);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = PrintOrientation.Portrait;

            await printHelper.ShowPrintUIAsync("Herbarium Management IS - List of New Deposits", printHelperOptions);
            //printHelper.PreparePrintContent(new DocumentNewDeposit());
        }
    }
}
