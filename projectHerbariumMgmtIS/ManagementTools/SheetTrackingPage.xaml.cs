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

namespace projectHerbariumMgmtIS.ManagementTools
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SheetTrackingPage : Page
    {
        public SheetTrackingPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrHerbariumSheetsTable.ItemsSource = new HerbariumSheet().GetHerbariumTraces();

        private async void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgrHerbariumSheetsTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrHerbariumSheetsTable.SelectedItem as HerbariumSheet;
                List<HerbariumImage> HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheets(SelectedDeposit.AccessionNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new List<HerbariumImage>();
                }

                ViewTrackedSheetForm form = new ViewTrackedSheetForm()
                {
                    HerbariumSheet = HerbariumImage,
                    HerbariumSheetData = SelectedDeposit
                };
                var result = await form.ShowAsync();
            }
        }
    }
}
