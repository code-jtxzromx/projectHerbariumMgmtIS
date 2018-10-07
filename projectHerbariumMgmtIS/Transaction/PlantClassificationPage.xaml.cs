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
    public sealed partial class PlantClassificationPage : Page
    {
        public PlantClassificationPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage() => dgrVerifiedSheetTable.ItemsSource = new HerbariumSheet().GetUnclassifiedSheets();

        private async void btnClassify_Click(object sender, RoutedEventArgs e)
        {
            if (dgrVerifiedSheetTable.SelectedIndex != -1)
            {
                var SelectedDeposit = dgrVerifiedSheetTable.SelectedItem as HerbariumSheet;
                BitmapImage HerbariumImage;
                try
                {
                    HerbariumImage = await new HerbariumImage().GetHerbariumSheet(true, SelectedDeposit.AccessionNumber);
                }
                catch (Exception)
                {
                    HerbariumImage = new BitmapImage();
                }
                
                ClassifySheetForm form = new ClassifySheetForm()
                {
                    HerbariumSheet = HerbariumImage,
                    VerifiedSheetData = SelectedDeposit
                };
                if (!form.CheckAvailableBox())
                {
                    MessageDialog dialog = new MessageDialog("No Available Family Box for this Herbarium Sheet");
                    var result = dialog.ShowAsync();
                }
                else
                {
                    var result = await form.ShowAsync();
                }

                this.InitializePage();
            }

        }
    }
}
