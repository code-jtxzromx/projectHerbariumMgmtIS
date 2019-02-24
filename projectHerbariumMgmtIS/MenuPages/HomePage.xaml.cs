using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public sealed partial class HomePage : Page
    {
        private Random _random = new Random();
         ObservableCollection<ChartData> items1 = new ObservableCollection<ChartData>();

        public List<ItemListView> Cards = new List<ItemListView>()
        {
            new ItemListView() { Title = "Herbarium Sheets",                Count = new ItemListView().CountHerbariumSheets() },
            new ItemListView() { Title = "Verified Species",                Count = new ItemListView().CountVerifiedSpecies() },
            new ItemListView() { Title = "Available Family Boxes",          Count = new ItemListView().CountFamilyBox() },
            new ItemListView() { Title = "Available Sheets for Loaning",    Count = new ItemListView().CountLoanAvailable() },
            new ItemListView() { Title = "New Plant Deposits",              Count = new ItemListView().CountNewDeposit() },
            new ItemListView() { Title = "Resubmitting Deposits",           Count = new ItemListView().CountRejectedDeposit() },
        };

        public HomePage()
        {
            this.InitializeComponent();
            lblUser.Text = StaticAccess.StaffName;
            grvCard.ItemsSource = Cards;

            for (int i = 0; i < 5; i++)
            {
                this.items1 = new ObservableCollection<ChartData>();
            }
        }
    }

    public class ChartData : INotifyPropertyChanged
    {
        private int _value;

        public string Name { get; set; }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
