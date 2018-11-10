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
    public sealed partial class EditSheetForm : ContentDialog
    {
        private List<HerbariumBox> HerbariumBoxes = new List<HerbariumBox>();
        private int TransactionResult;

        // Properties
        public HerbariumSheet HerbariumSheetData
        {
            get { return (HerbariumSheet)GetValue(HerbariumSheetDataProperty); }
            set
            {
                var result = from box in HerbariumBoxes
                             where box.Family == value.FamilyName
                             where box.CurrentNo > 0
                             select box.BoxNumber;
                cbxFamilyBox.ItemsSource = result;

                SetValue(HerbariumSheetDataProperty, value);

                if (value.Status == "Loaned" || value.Status == "Damaged")
                    btnLoanAvailable.IsEnabled = false;
            }
        }
        public List<HerbariumImage> HerbariumSheet
        {
            get { return (List<HerbariumImage>)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty HerbariumSheetDataProperty =
            DependencyProperty.Register("HerbariumSheetData", typeof(HerbariumSheet), typeof(EditSheetForm), new PropertyMetadata(new HerbariumSheet()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(List<HerbariumImage>), typeof(ViewSheetForm), new PropertyMetadata(new List<HerbariumImage>()));

        // Constructor
        public EditSheetForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string message = "";
            TransactionResult = HerbariumSheetData.UpdateHerbariumSheet();

            switch (TransactionResult)
            {
                case 0:
                    message = "Herbarium Sheet Information Updated in the Database";
                    break;
                case 1:
                    message = "Transaction Failed, The system had run to an Error";
                    break;
            }

            MessageDialog dialog = new MessageDialog(message, "Process Done");
            var result = dialog.ShowAsync();
        }

        // Methods
        private void ClearForm()
        {
            HerbariumSheetData = new HerbariumSheet();
            HerbariumBoxes = new HerbariumBox().GetAvailableBoxes();
        }
    }
}
