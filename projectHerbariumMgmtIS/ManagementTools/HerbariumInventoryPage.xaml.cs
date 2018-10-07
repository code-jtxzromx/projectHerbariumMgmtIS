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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.ManagementTools
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HerbariumInventoryPage : Page
    {
        private List<HerbariumSheet> HerbariumSheets;

        public HerbariumInventoryPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage()
        {
            dgrHerbariumSheetTable.ItemsSource = null;
            HerbariumSheets = new HerbariumSheet().GetHerbariumInventory();
            lstHerbariumBoxes.ItemsSource = new HerbariumBox().GetAvailableBoxes();
        }

        private async void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgrHerbariumSheetTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrHerbariumSheetTable.SelectedItem as HerbariumSheet;
                List<HerbariumImage> HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheets(SelectedDeposit.AccessionNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new List<HerbariumImage>();
                }

                ViewSheetForm form = new ViewSheetForm()
                {
                    HerbariumSheet = HerbariumImage,
                    HerbariumSheetData = SelectedDeposit
                };
                var result = await form.ShowAsync();
            }
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrHerbariumSheetTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrHerbariumSheetTable.SelectedItem as HerbariumSheet;
                List<HerbariumImage> HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheets(SelectedDeposit.AccessionNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new List<HerbariumImage>();
                }

                EditSheetForm form = new EditSheetForm()
                {
                    HerbariumSheet = HerbariumImage,
                    HerbariumSheetData = SelectedDeposit
                };
                var result = await form.ShowAsync();

                this.InitializePage();
            }
        }

        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstHerbariumBoxes_ItemClick(object sender, ItemClickEventArgs e)
        {
            string boxnumber = (e.ClickedItem as HerbariumBox).BoxNumber;

            var result = from sheet in HerbariumSheets
                         where sheet.BoxLocation == boxnumber
                         select sheet;

            dgrHerbariumSheetTable.ItemsSource = result;
        }
    }
}
