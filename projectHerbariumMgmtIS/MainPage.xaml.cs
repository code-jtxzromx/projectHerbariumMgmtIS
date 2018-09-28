using projectHerbariumMgmtIS.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace projectHerbariumMgmtIS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            testConnection();
        }

        private void navMainMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //frmPageContent.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                string pageName = "projectHerbariumMgmtIS.MenuPages." + ((string)selectedItem.Tag);
                Type pageType = Type.GetType(pageName);
                frmPageContent.Navigate(pageType);
                navMainMenu.Header = selectedItem.Content;
            }
        }

        private void testConnection()
        {
            DatabaseConnection connection = new DatabaseConnection();
            if (connection.testConnection())
            {
                SampleDialog dialog = new SampleDialog();
                dialog.TextContent = "Database Connected";
                var result = dialog.ShowAsync();
            }
            else
            {
                SampleDialog dialog = new SampleDialog();
                dialog.TextContent = "Database Connected";
                var result = dialog.ShowAsync();
            }
        }
    }
}
