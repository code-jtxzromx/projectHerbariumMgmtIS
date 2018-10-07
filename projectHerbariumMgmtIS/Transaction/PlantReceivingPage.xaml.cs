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
    public sealed partial class PlantReceivingPage : Page
    {
        public PlantReceivingPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrNewDepositTable.ItemsSource = new PlantDeposit().GetReceivedDeposits();

        private async void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (dgrNewDepositTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrNewDepositTable.SelectedItem as PlantDeposit;
                BitmapImage HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheet(false, SelectedDeposit.DepositNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new BitmapImage();
                }

                ConfirmDepositForm form = new ConfirmDepositForm()
                {
                    ReceivedDepositData = SelectedDeposit,
                    HerbariumSheet = HerbariumImage
                };
                var result = await form.ShowAsync();

                if (result == ContentDialogResult.Primary || result == ContentDialogResult.Secondary)
                {
                    string message = "";

                    switch (form.TransactionResult)
                    {
                        case 0:
                            message = (result == ContentDialogResult.Primary)
                                ? "Plant Deposit will be Processed for Verification" : "Plant Deposit Rejected";
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
