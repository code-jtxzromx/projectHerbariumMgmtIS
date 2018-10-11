using projectHerbariumMgmtIS.Dialogs;
using projectHerbariumMgmtIS.MenuPages;
using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
        DispatcherTimer Timer;
        public string StaffName
        {
            get { return (string)GetValue(StaffNameProperty); }
            set { SetValue(StaffNameProperty, value); }
        }
        public string AccountLevel
        {
            get { return (string)GetValue(AccountLevelProperty); }
            set { SetValue(AccountLevelProperty, value); }
        }

        public static readonly DependencyProperty StaffNameProperty =
            DependencyProperty.Register("StaffName", typeof(string), typeof(MainPage), new PropertyMetadata(""));
        public static readonly DependencyProperty AccountLevelProperty =
            DependencyProperty.Register("AccountLevel", typeof(string), typeof(MainPage), new PropertyMetadata(""));


        public MainPage()
        {
            this.InitializeComponent();
            this.AnimateFlipView();
            this.TestConnection();
            
            MainNavigation.Visibility = Visibility.Collapsed;
        }

        private void AnimateFlipView()
        {
            int intervalPic = 1;

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 5);
            Timer.Tick += (sender, e) =>
            {
                int newIndex = flvBackgrounds.SelectedIndex + 1;
                if (newIndex >= flvBackgrounds.Items.Count || newIndex <= 0)
                {
                    intervalPic *= -1;
                }
                flvBackgrounds.SelectedIndex += intervalPic;
            };
            Timer.Start();
        }

        private void navMainMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (MainMenu)args.SelectedItem;
            string pageName = "projectHerbariumMgmtIS.MenuPages." + ((string)selectedItem.TagPage);
            Type pageType = Type.GetType(pageName);
            frmPageContent.Navigate(pageType);
            navMainMenu.Header = selectedItem.Menu;
        }

        private void KeyBoardEnter_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                btnLogin_Click(btnLogin, null);
        }

        private void TestConnection()
        {
            DatabaseConnection connection = new DatabaseConnection();
            if (!connection.testConnection())
            {
                MessageDialog dialog = new MessageDialog("System cannot Connect to the Database Server\n" +
                                                            "Please Consider the following:\n" +
                                                            "1 > Device should connected to the same Network where the Database Server exists \n" +
                                                            "2 > You may need to change the Database Server \n" +
                                                            "3 > You might need to restart this PC \n" +
                                                            "Or Contact the Developers to fix this problem",
                                                         "Database Connection Failed");
                var result = dialog.ShowAsync();
                Application.Current.Exit();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int result = StaticAccess.LogIn(txfUsername.Text, txfPassword.Password);
            lblLoginError.Visibility = Visibility.Collapsed;

            if (result == 0)
            {
                StaffName = StaticAccess.StaffName;
                AccountLevel = StaticAccess.Role;

                foreach (var item in new MainMenu().GetMenus())
                {
                    navMainMenu.MenuItems.Add(item);
                }

                frmPageContent.Navigate(typeof(HomePage));
                navMainMenu.Header = "Homepage";

                LoginScreen.Visibility = Visibility.Collapsed;
                MainNavigation.Visibility = Visibility.Visible;
            }
            else
            {
                lblLoginError.Visibility = Visibility.Visible;
                txfPassword.Password = "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblLoginError.Visibility = Visibility.Collapsed;
            txfUsername.Text = "";
            txfPassword.Password = "";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
            StaffName = "";
            btnClear_Click(btnClear, null);

            navMainMenu.MenuItems.Clear();

            MainNavigation.Visibility = Visibility.Collapsed;
            LoginScreen.Visibility = Visibility.Visible;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Herbarium Management Information System \n" +
                                                     "Copyright © 2018 \n\n" +
                                                     "Developed by: PUPCCIS BSIT 4-1 ISD [Casingal, Cruz, Escueta, Leynes]");
            var result = dialog.ShowAsync();
        }
    }
}
