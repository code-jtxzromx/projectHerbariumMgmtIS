using projectHerbariumMgmtIS.ManagementTools;
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

namespace projectHerbariumMgmtIS.MenuPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UtilitiesPage : Page
    {
        private List<SubMenu> MaintenanceMenu = new List<SubMenu>()
        {
            new SubMenu() { MenuItem = "Herbarium Inventory",       Page = typeof(HerbariumInventoryPage) },
            new SubMenu() { MenuItem = "Sheet Tracking",            Page = typeof(SheetTrackingPage) },
            new SubMenu() { MenuItem = "Audit Trailing",            Page = typeof(AuditTrailingPage) }
        };

        public UtilitiesPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage()
        {
            lstUtilitiesMenu.ItemsSource = MaintenanceMenu;
            frmPageContent.Navigate(typeof(HerbariumInventoryPage));
        }

        private void lstUtilitiesMenu_ItemClick(object sender, ItemClickEventArgs e) => frmPageContent.Navigate((e.ClickedItem as SubMenu).Page);
    }
}
