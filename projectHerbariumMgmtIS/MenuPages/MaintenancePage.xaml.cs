using projectHerbariumMgmtIS.Dialogs;
using projectHerbariumMgmtIS.Maintenance;
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
    public sealed partial class MaintenancePage : Page
    {
        private List<SubMenu> MaintenanceMenu = new List<SubMenu>()
        {
            new SubMenu() { MenuItem = "Taxonomic Hierarchy",       Page = typeof(TaxonomicHierarchyPage) },
            new SubMenu() { MenuItem = "Species Author",            Page = typeof(SpeciesAuthorPage) },
            new SubMenu() { MenuItem = "Species Nomenclature",      Page = typeof(SpeciesNomenclaturePage) },
            new SubMenu() { MenuItem = "Plant Types",               Page = typeof(PlantTypePage) },
            new SubMenu() { MenuItem = "Herbarium Boxes",           Page = typeof(HerbariumBoxPage) },
            new SubMenu() { MenuItem = "Plant Locality",            Page = typeof(PlantLocalityPage) },
            new SubMenu() { MenuItem = "Collector",                 Page = typeof(CollectorPage) },
            new SubMenu() { MenuItem = "Borrower",                  Page = typeof(BorrowerPage) },
            new SubMenu() { MenuItem = "External Validator",        Page = typeof(ExternalValidatorPage) },
            new SubMenu() { MenuItem = "Herbarium Staff",           Page = typeof(HerbariumStaffPage) },
            new SubMenu() { MenuItem = "Access Accounts",           Page = typeof(AccessAccountsPage) }
        };

        public MaintenancePage()
        {
            this.InitializeComponent();
            lstMaintenanceMenu.ItemsSource = MaintenanceMenu;
        }

        private void lstMaintenanceMenu_ItemClick(object sender, ItemClickEventArgs e) => frmPageContent.Navigate((e.ClickedItem as SubMenu).Page);
    }
}
