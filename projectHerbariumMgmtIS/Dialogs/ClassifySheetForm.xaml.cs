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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ClassifySheetForm : ContentDialog
    {
        private int TransactionResult;
        private List<HerbariumBox> FamilyBoxes; 

        // Properties
        public HerbariumSheet VerifiedSheetData
        {
            get { return (HerbariumSheet)GetValue(VerifiedSheetDataProperty); }
            set { SetValue(VerifiedSheetDataProperty, value); }
        }
        public BitmapImage HerbariumSheet
        {
            get { return (BitmapImage)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty VerifiedSheetDataProperty =
            DependencyProperty.Register("VerifiedSheetData", typeof(HerbariumSheet), typeof(ClassifySheetForm), new PropertyMetadata(new HerbariumSheet()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(BitmapImage), typeof(ClassifySheetForm), new PropertyMetadata(new BitmapImage()));

        // Constructor
        public ClassifySheetForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            TransactionResult = VerifiedSheetData.ClassifyHerbariumSheet(lblBoxNumber.Text);

            switch (TransactionResult)
            {
                case 0:
                    message = "Herbarium Sheet is now Stored in " + lblBoxNumber.Text;
                    break;
                case 1:
                    message = "Transaction Failed, The system had run to an Error";
                    break;
            }

            MessageDialog dialog = new MessageDialog(message, "Process Done");
            var result = dialog.ShowAsync();
        }

        private void ClearForm()
        {
            FamilyBoxes = new HerbariumBox().GetAvailableBoxes();
            VerifiedSheetData = new HerbariumSheet();
        }

        public bool CheckAvailableBox()
        {
            var result = from family in FamilyBoxes
                         where family.Family == VerifiedSheetData.FamilyName
                         where family.CurrentNo > 0
                         select family.BoxNumber;

            if (result.Count() == 0)
                return false;
            else
            {
                lblBoxNumber.Text = result.First();
                return true;
            }
        }
    }
}
