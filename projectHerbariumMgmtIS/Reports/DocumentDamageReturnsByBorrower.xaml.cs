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

namespace projectHerbariumMgmtIS.Reports
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DocumentDamageReturnsByBorrower : Page
    {
        // Properties
        public string Borrower
        {
            get { return (string)GetValue(BorrowerProperty); }
            set { SetValue(BorrowerProperty, value); }
        }
        public static readonly DependencyProperty BorrowerProperty =
            DependencyProperty.Register("Borrower", typeof(string), typeof(DocumentDamageReturnsByBorrower), new PropertyMetadata(""));
        
        public DocumentDamageReturnsByBorrower()
        {
            this.InitializeComponent();
        }

        public DocumentDamageReturnsByBorrower(List<HerbariumSheet> herbariumSheets)
        {
            this.InitializeComponent();
            dgrResultTable.ItemsSource = herbariumSheets;
        }
    }
}
