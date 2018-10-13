using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Queries
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QueryHerbariumSheetPage : Page
    {
        private List<HerbariumSheet> SheetList = new List<HerbariumSheet>();
        private List<HerbariumSheet> TempList = new List<HerbariumSheet>();
        private List<string> Categories 
            = new List<string>() { "Taxon Species", "Plant Types", "Province", "Collector", "Herbarium Box", "Specimen Status" };
        private List<CheckBoxList> Status = new List<CheckBoxList>()
        {
            new CheckBoxList() { IsChecked = false, Item = "For Verification" },
            new CheckBoxList() { IsChecked = false, Item = "Further Verification" },
            new CheckBoxList() { IsChecked = false, Item = "Verified" },
            new CheckBoxList() { IsChecked = false, Item = "Stored" },
            new CheckBoxList() { IsChecked = false, Item = "Loaned" },
        };

        public QueryHerbariumSheetPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage()
        {
            SheetList = new HerbariumSheet().GetHerbariumSheetQuery();
            TempList = new HerbariumSheet().GetHerbariumSheetQuery();
            cbxCategory.ItemsSource = Categories;
            dgrSheetsTable.ItemsSource = SheetList;

            cbxCategory.SelectedIndex = -1;
            lstCategoryResult.ItemsSource = null;
        }

        private void cbxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxCategory.SelectedIndex != -1)
            {
                switch (cbxCategory.SelectedItem)
                {
                    case "Taxon Species":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetSpeciesList();
                        break;
                    case "Plant Types":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetPlantTypeList();
                        break;
                    case "Province":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetProvinceList();
                        break;
                    case "Collector":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetCollectorList();
                        break;
                    case "Herbarium Box":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetHerbariumBoxList();
                        break;
                    case "Specimen Status":
                        lstCategoryResult.ItemsSource = Status;
                        break;
                }
            }
        }

        private void btnLoadTable_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategory.SelectedIndex != -1)
            {
                List<string> selectedItems = new List<string>();
                foreach (CheckBoxList item in lstCategoryResult.Items)
                {
                    if (item.IsChecked)
                    {
                        selectedItems.Add(item.Item);
                    }
                }
                TempList = GetSpeciesList(cbxCategory.SelectedItem.ToString(), selectedItems);
                dgrSheetsTable.ItemsSource = TempList;
            }
        }

        private void txfSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txfSearch.Text.ToUpper();

            var result = from sheet in TempList
                         where sheet.AccessionNumber.ToUpper().Contains(input) ||
                               sheet.ReferenceNumber.ToUpper().Contains(input) ||
                               sheet.PlantType.ToUpper().Contains(input) ||
                               sheet.BoxLocation.ToUpper().Contains(input) ||
                               sheet.FamilyName.ToUpper().Contains(input) ||
                               sheet.TaxonNomenclature.ToUpper().Contains(input) ||
                               sheet.Locality.ToUpper().Contains(input) ||
                               sheet.Collector.ToUpper().Contains(input) ||
                               sheet.Staff.ToUpper().Contains(input) ||
                               sheet.Validator.ToUpper().Contains(input)
                         select sheet;
            dgrSheetsTable.ItemsSource = result;
        }

        private void btnResetTable_Click(object sender, RoutedEventArgs e) => this.InitializePage();

        private List<HerbariumSheet> GetSpeciesList(string category, List<string> selectedItems)
        {
            List<HerbariumSheet> resultSpecies = new List<HerbariumSheet>();

            foreach (var item in selectedItems)
            {
                switch (category)
                {
                    case "Taxon Species":
                        var species = from sheet in SheetList
                                      where sheet.ScientificName == item
                                      select sheet;

                        foreach (var record in species)
                            resultSpecies.Add(record);

                        break;
                    case "Plant Types":
                        var types = from sheet in SheetList
                                    where sheet.PlantType == item
                                    select sheet;

                        foreach (var record in types)
                            resultSpecies.Add(record);

                        break;
                    case "Province":
                        var locality = from sheet in SheetList
                                        where sheet.Province == item
                                        select sheet;

                        foreach (var record in locality)
                            resultSpecies.Add(record);

                        break;
                    case "Collector":
                        var collector = from sheet in SheetList
                                        where sheet.Collector == item
                                        select sheet;

                        foreach (var record in collector)
                            resultSpecies.Add(record);

                        break;
                    case "Herbarium Box":
                        var box = from sheet in SheetList
                                  where sheet.BoxLocation == item
                                  select sheet;

                        foreach (var record in box)
                            resultSpecies.Add(record);

                        break;
                    case "Specimen Status":
                        var status = from sheet in SheetList
                                     where sheet.Status == item
                                     select sheet;

                        foreach (var record in status)
                            resultSpecies.Add(record);

                        break;
                }
            }

            return resultSpecies;
        }
    }
}
