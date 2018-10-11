using projectHerbariumMgmtIS.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Transaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlantLoaningPage : Page
    {
        public PlantLoaningPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrLoanTable.ItemsSource = new PlantLoan().GetCurrentLoans();

        private void btnNewLoan_Click(object sender, RoutedEventArgs e)
        {
            RequestLoanForm form = new RequestLoanForm();
            var result = form.ShowAsync();

            this.InitializePage();
        }

        private void btnViewLoan_Click(object sender, RoutedEventArgs e)
        {
            if (dgrLoanTable.SelectedIndex != -1)
            {
                var selectedItem = dgrLoanTable.SelectedItem as PlantLoan;

                ViewLoanForm form = new ViewLoanForm()
                {
                    PlantLoanData = selectedItem
                };
                var result = form.ShowAsync();

                this.InitializePage();
            }
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (dgrLoanTable.SelectedIndex != -1)
            {
                var selectedItem = dgrLoanTable.SelectedItem as PlantLoan;

                ApproveLoanForm form = new ApproveLoanForm()
                {
                    PlantLoanData = selectedItem
                };
                var result = form.ShowAsync();

                this.InitializePage();
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
