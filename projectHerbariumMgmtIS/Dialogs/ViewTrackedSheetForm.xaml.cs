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
        public PlantDeposit HerbariumSheetData
        {
            get { return (PlantDeposit)GetValue(HerbariumSheetDataProperty); }
            set { SetValue(HerbariumSheetDataProperty, value); }
        }
        public List<HerbariumImage> HerbariumSheet
        {
            get { return (List<HerbariumImage>)GetValue(HerbariumSheetProperty); }
            set { SetValue(HerbariumSheetProperty, value); }
        }

        public static readonly DependencyProperty HerbariumSheetDataProperty =
            DependencyProperty.Register("HerbariumSheetData", typeof(PlantDeposit), typeof(ViewSheetForm), new PropertyMetadata(new PlantDeposit()));
        public static readonly DependencyProperty HerbariumSheetProperty =
            DependencyProperty.Register("HerbariumSheet", typeof(List<HerbariumImage>), typeof(ViewSheetForm), new PropertyMetadata(new List<HerbariumImage>()));

        // Constructor
        public ViewTrackedSheetForm()
        {
            this.InitializeComponent();
        }
    }
}
