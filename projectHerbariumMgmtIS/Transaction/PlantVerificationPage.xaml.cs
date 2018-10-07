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
    public sealed partial class PlantVerificationPage : Page
    {
        public PlantVerificationPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrVerifyingDepositTable.ItemsSource = new PlantDeposit().GetVerifyingDeposits();

        private async void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (dgrVerifyingDepositTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrVerifyingDepositTable.SelectedItem as PlantDeposit;
                BitmapImage HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheet(true, SelectedDeposit.AccessionNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new BitmapImage();
                }

                VerifyDepositForm form = new VerifyDepositForm()
                {
                    HerbariumSheet = HerbariumImage,
                    VerifyingDepositData = SelectedDeposit
                };
                var result = await form.ShowAsync();

                this.InitializePage();
            }
        }
    }
}
