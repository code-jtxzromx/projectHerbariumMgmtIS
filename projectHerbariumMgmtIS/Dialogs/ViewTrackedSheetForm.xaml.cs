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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class ViewTrackedSheetForm : ContentDialog
    {
        // Properties
        public HerbariumSheet HerbariumSheetData
        {
            get { return (HerbariumSheet)GetValue(HerbariumSheetDataProperty); }
            set
            {
                SetValue(HerbariumSheetDataProperty, value);
                this.ToggleStatus(value);
            }
        }
        public List<HerbariumImage> HerbariumSheet
        {
            get { return (List<HerbariumImage>)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty HerbariumSheetDataProperty =
            DependencyProperty.Register("HerbariumSheetData", typeof(HerbariumSheet), typeof(ViewSheetForm), new PropertyMetadata(new HerbariumSheet()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(List<HerbariumImage>), typeof(ViewSheetForm), new PropertyMetadata(new List<HerbariumImage>()));

        // Constructor
        public ViewTrackedSheetForm()
        {
            this.InitializeComponent();
        }

        // Methods
        public void ToggleStatus(HerbariumSheet sheet)
        {
            switch (sheet.Status)
            {
                case "For Verification":
                    lblLocation.Text = "Plant Verification";
                    Row03.Height = new GridLength(0);
                    Row04.Height = new GridLength(0);
                    Row05.Height = new GridLength(0);
                    Row06.Height = new GridLength(0);
                    Row07.Height = new GridLength(0);
                    Row08.Height = new GridLength(0);
                    Row09.Height = new GridLength(0);
                    Row12.Height = new GridLength(0);
                    Row15.Height = new GridLength(0);
                    Row18.Height = new GridLength(0);
                    Row20.Height = new GridLength(0);
                    Row21.Height = new GridLength(0);
                    break;
                case "Further Verification":
                    lblLocation.Text = "External Verification";
                    Row03.Height = new GridLength(0);
                    Row05.Height = new GridLength(0);
                    Row06.Height = new GridLength(0);
                    Row07.Height = new GridLength(0);
                    Row09.Height = new GridLength(0);
                    Row12.Height = new GridLength(0);
                    Row15.Height = new GridLength(0);
                    Row18.Height = new GridLength(0);
                    Row20.Height = new GridLength(0);
                    Row21.Height = new GridLength(0);
                    break;
                case "Verified":
                    lblLocation.Text = "Plant Classification";
                    Row04.Height = new GridLength(0);
                    Row05.Height = new GridLength(0);
                    Row08.Height = new GridLength(0);
                    Row12.Height = new GridLength(0);
                    Row20.Height = new GridLength(0);
                    Row21.Height = new GridLength(0);
                    break;
                case "Stored":
                    lblLocation.Text = "Herbarium Inventory at " + sheet.BoxLocation;
                    Row04.Height = new GridLength(0);
                    Row08.Height = new GridLength(0);
                    Row12.Height = new GridLength(0);
                    Row20.Height = new GridLength(0);
                    break;
                case "Loaned":
                    lblLocation.Text = "Loaned by " + sheet.Borrower;
                    Row04.Height = new GridLength(0);
                    Row08.Height = new GridLength(0);
                    break;
                default:
                    break;
            }
        }
    }
}
