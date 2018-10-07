using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ResubmitDepositForm : ContentDialog
    {
        public byte[] image;
        public int TransactionResult;

        // Properties
        public PlantDeposit RejectedDepositData
        {
            get { return (PlantDeposit)GetValue(RejectedDepositDataProperty); }
            set { SetValue(RejectedDepositDataProperty, value); }
        }
        public BitmapImage HerbariumSheet
        {
            get { return (BitmapImage)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }
        
        public static readonly DependencyProperty RejectedDepositDataProperty =
            DependencyProperty.Register("RejectedDepositData", typeof(PlantDeposit), typeof(ResubmitDepositForm), new PropertyMetadata(new PlantDeposit()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(BitmapImage), typeof(ResubmitDepositForm), new PropertyMetadata(new BitmapImage()));
        
        // Constructor
        public ResubmitDepositForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) 
            => TransactionResult = RejectedDepositData.ResubmitDeposit(this.image);

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            FileOpenPicker filePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".png");

            StorageFile file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                picHerbariumSheet.Source = image;

                using (var inputStream = await file.OpenSequentialReadAsync())
                {
                    var readStream = inputStream.AsStreamForRead();

                    var byteArray = new byte[readStream.Length];
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                    this.image = byteArray;
                }
            }

            args.Cancel = true;
        }

        // Methods
        private void ClearForm()
        {
            RejectedDepositData = new PlantDeposit();

            cbxPlantType.ItemsSource = new PlantType().GetPlantTypeList();
            cbxLocality.ItemsSource = new PlantLocality().GetLocalityList();
        }
    }
}
