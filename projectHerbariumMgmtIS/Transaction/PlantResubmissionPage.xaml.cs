using projectHerbariumMgmtIS.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Transaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlantResubmissionPage : Page
    {
        public PlantResubmissionPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrRejectedDepositTable.ItemsSource = new PlantDeposit().GetRejectedDeposits();

        private async void btnResubmit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrRejectedDepositTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrRejectedDepositTable.SelectedItem as PlantDeposit;
                BitmapImage HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheet(false, SelectedDeposit.DepositNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new BitmapImage();
                }

                ResubmitDepositForm form = new ResubmitDepositForm()
                {
                    HerbariumSheet = HerbariumImage,
                    RejectedDepositData = SelectedDeposit
                };
                var result = await form.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    string message = "";

                    switch (form.TransactionResult)
                    {
                        case 0:
                            message = "Plant Deposit Resubmitted";
                            break;
                        case 1:
                            message = "Transaction Failed";
                            break;
                    }

                    MessageDialog prompt = new MessageDialog(message, "Process Done");
                    await prompt.ShowAsync();

                    this.InitializePage();
                }
            }
        }
    }
}
