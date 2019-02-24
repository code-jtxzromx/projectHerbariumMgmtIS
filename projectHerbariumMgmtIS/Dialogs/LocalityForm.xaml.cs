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
    public sealed partial class LocalityForm : ContentDialog
    {
        private List<string[]> Cities = new List<string[]>();
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public PlantLocality LocalityData
        {
            get { return (PlantLocality)GetValue(LocalityDataProperty); }
            set
            {
                SetValue(LocalityDataProperty, value);
                cbxCountry_SelectionChanged(cbxCountry, null);
                cbxProvince_SelectionChanged(cbxProvince, null);
            }
        }
        public bool IsMaintenance
        {
            get { return (bool)GetValue(IsMaintenanceProperty); }
            set { SetValue(IsMaintenanceProperty, value); }
        }
        
        public static readonly DependencyProperty LocalityDataProperty =
            DependencyProperty.Register("LocalityData", typeof(PlantLocality), typeof(LocalityForm), new PropertyMetadata(new PlantLocality()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(LocalityForm), new PropertyMetadata(""));
        public static readonly DependencyProperty IsMaintenanceProperty =
            DependencyProperty.Register("IsMaintenance", typeof(bool), typeof(LocalityForm), new PropertyMetadata(true));

        // Constructor
        public LocalityForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void cbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxCountry.SelectedIndex != -1)
            {
                bool isCountryPH = (cbxCountry.SelectedItem.ToString() == "Philippines");
                cbxProvince.Visibility = isCountryPH ? Visibility.Visible : Visibility.Collapsed;
                cbxCity.Visibility = isCountryPH ? Visibility.Visible : Visibility.Collapsed;
                txfSpecificLocation.Visibility = isCountryPH ? Visibility.Visible : Visibility.Collapsed;
                txfFullLocality.Visibility = !isCountryPH ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void cbxProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxProvince.SelectedIndex != -1)
            {
                string selectedProvince = cbxProvince.SelectedItem.ToString();
                var resultCities = from city in Cities
                                   where city[0] == selectedProvince
                                   select city[1];
                cbxCity.ItemsSource = resultCities;
            }
            else
            {
                cbxCity.ItemsSource = null;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (IsMaintenance)
                {
                    if (TransactionForm == "Add Plant Locality")
                        TransactionResult = LocalityData.AddLocality();
                    else if (TransactionForm == "Edit Plant Locality")
                        TransactionResult = LocalityData.EditLocality();
                }
                args.Cancel = false;
            }
            else
                args.Cancel = true;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClearForm();
            args.Cancel = true;
        }

        // Methods
        private bool ValidateForm()
        {
            bool formOK = true;
            string selectedCountry = cbxCountry.SelectedItem.ToString();
            msgCountry.Visibility = Visibility.Collapsed;
            msgProvince.Visibility = Visibility.Collapsed;
            msgCity.Visibility = Visibility.Collapsed;
            msgSpecificLocation.Visibility = Visibility.Collapsed;
            msgFullLocality.Visibility = Visibility.Collapsed;
            msgShortLocality.Visibility = Visibility.Collapsed;

            if (cbxCountry.SelectedIndex == -1)
            {
                msgCountry.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (selectedCountry == "Philippines" && cbxProvince.SelectedIndex == -1)
            {
                msgProvince.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (selectedCountry == "Philippines" && cbxCity.SelectedIndex == -1)
            {
                msgCity.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (selectedCountry == "Philippines" && txfSpecificLocation.Text == "")
            {
                msgSpecificLocation.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (selectedCountry != "Philippines" && txfFullLocality.Text == "")
            {
                msgFullLocality.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfShortLocality.Text == "")
            {
                msgShortLocality.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgCountry.Visibility = Visibility.Collapsed;
            msgProvince.Visibility = Visibility.Collapsed;
            msgCity.Visibility = Visibility.Collapsed;
            msgSpecificLocation.Visibility = Visibility.Collapsed;
            msgFullLocality.Visibility = Visibility.Collapsed;
            msgShortLocality.Visibility = Visibility.Collapsed;

            LocalityData = new PlantLocality();
            cbxCountry.ItemsSource = new PlantLocality().GetCountryList();
            cbxProvince.ItemsSource = new PlantLocality().GetProvinceList();
            cbxCity.ItemsSource = null;
            Cities = new PlantLocality().GetCityList();
            cbxCountry_SelectionChanged(cbxCountry, null);

            TransactionForm = "Add Plant Locality";
            PrimaryButtonText = "Save";
        }
    }
}
