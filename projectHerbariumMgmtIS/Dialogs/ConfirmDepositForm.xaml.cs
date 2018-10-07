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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ConfirmDepositForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public PlantDeposit ReceivedDepositData
        {
            get { return (PlantDeposit)GetValue(ReceivedDepositDataProperty); }
            set { SetValue(ReceivedDepositDataProperty, value); }
        }
        public BitmapImage HerbariumSheet
        {
            get { return (BitmapImage)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty ReceivedDepositDataProperty =
            DependencyProperty.Register("ReceivedDepositData", typeof(PlantDeposit), typeof(ConfirmDepositForm), new PropertyMetadata(new PlantDeposit()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(BitmapImage), typeof(ConfirmDepositForm), new PropertyMetadata(new BitmapImage()));

        // Constructor
        public ConfirmDepositForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) 
            => TransactionResult = ReceivedDepositData.ConfirmDeposit("Accepted");

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) 
            => TransactionResult = ReceivedDepositData.ConfirmDeposit("Rejected");

        // Methods
        private void ClearForm() => ReceivedDepositData = new PlantDeposit();
    }
}
