using projectHerbariumMgmtIS.Model;
using projectHerbariumMgmtIS.Reports;
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

namespace projectHerbariumMgmtIS.MenuPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportsPage : Page
    {
        private List<SubMenu> ReportsMenu = new List<SubMenu>()
        {
            new SubMenu() { MenuItem = "List of New Deposits",              TypePage = typeof(ReportNewDepositPage) },
            new SubMenu() { MenuItem = "List of Rejected Deposits",         TypePage = typeof(ReportRejectedDepositPage) },
            new SubMenu() { MenuItem = "List of Verified Deposits",         TypePage = typeof(ReportVerifiedDepositPage) },
            new SubMenu() { MenuItem = "Externally Verified Collections",   TypePage = typeof(ReportExternalVerificationPage) },
            new SubMenu() { MenuItem = "List of Damaged Returns",           TypePage = typeof(ReportDamagedReturns) },
        };

        public ReportsPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage()
        {
            lstReportsMenu.ItemsSource = ReportsMenu;
        }

        private void lstReportsMenu_ItemClick(object sender, ItemClickEventArgs e) => frmPageContent.Navigate((e.ClickedItem as SubMenu).TypePage);
    }
}
