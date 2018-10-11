﻿using projectHerbariumMgmtIS.Dialogs;
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
        public MaintenancePage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        private void InitializePage()
        {
            lstMaintenanceMenu.ItemsSource = new SubMenu().GetSubMenu("Maintenance"); 
        }

        private void lstMaintenanceMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedItem = (SubMenu)e.ClickedItem;
            string pageName = "projectHerbariumMgmtIS.Maintenance." + ((string)selectedItem.Page);
            Type pageType = Type.GetType(pageName);
            frmPageContent.Navigate(pageType);
        }
    }
}
