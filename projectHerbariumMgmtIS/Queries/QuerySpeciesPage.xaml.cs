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

namespace projectHerbariumMgmtIS.Queries
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuerySpeciesPage : Page
    {
        private List<TaxonSpecies> SpeciesList = new List<TaxonSpecies>();
        private List<string> Categories = new List<string>() { "Phylum", "Class", "Order", "Family", "Genus", "Author" };

        public QuerySpeciesPage()
        {
            this.InitializeComponent();
            this.IniitializePage();
        }

        public void IniitializePage()
        {
            SpeciesList = new TaxonSpecies().GetSpeciesQuery();
            cbxCategory.ItemsSource = Categories;
            dgrSpeciesTable.ItemsSource = SpeciesList;
        }

        private void cbxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxCategory.SelectedIndex != -1)
            {
                switch (cbxCategory.SelectedItem)
                {
                    case "Phylum":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetPhylumList();
                        break;
                    case "Class":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetClassList();
                        break;
                    case "Order":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetOrderList();
                        break;
                    case "Family":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetFamilyList();
                        break;
                    case "Genus":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetGenusList();
                        break;
                    case "Author":
                        lstCategoryResult.ItemsSource = new CheckBoxList().GetAuthorsList();
                        break;
                }
            }
        }

        private void btnLoadTable_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategory.SelectedIndex != 1)
            {
                List<string> selectedItems = new List<string>();
                foreach (CheckBoxList item in lstCategoryResult.Items)
                {
                    if (item.IsChecked)
                    {
                        selectedItems.Add(item.Item);
                    }
                }
                dgrSpeciesTable.ItemsSource = GetSpeciesList(cbxCategory.SelectedItem.ToString(), selectedItems);
            }
        }

        private List<TaxonSpecies> GetSpeciesList(string category, List<string> selectedItems)
        {
            List<TaxonSpecies> resultSpecies = new List<TaxonSpecies>();
            
            foreach (var item in selectedItems)
            {
                switch (category)
                {
                    case "Phylum":
                        var phylum = from species in SpeciesList
                                     where species.PhylumName == item
                                     select species;

                        foreach (var record in phylum)
                            resultSpecies.Add(record);

                        break;
                    case "Class":
                        var tclass = from species in SpeciesList
                                     where species.ClassName == item
                                     select species;

                        foreach (var record in tclass)
                            resultSpecies.Add(record);

                        break;
                    case "Order":
                        var order = from species in SpeciesList
                                    where species.OrderName == item
                                    select species;

                        foreach (var record in order)
                            resultSpecies.Add(record);

                        break;
                    case "Family":
                        var family = from species in SpeciesList
                                     where species.FamilyName == item
                                     select species;

                        foreach (var record in family)
                            resultSpecies.Add(record);

                        break;
                    case "Genus":
                        var genus = from species in SpeciesList
                                    where species.GenusName == item
                                    select species;

                        foreach (var record in genus)
                            resultSpecies.Add(record);

                        break;
                    case "Author":
                        var author = from species in SpeciesList
                                     where species.SpeciesAuthor == item
                                     select species;

                        foreach (var record in author)
                            resultSpecies.Add(record);

                        break;
                }
            }

            //foreach (var line in resultSpecies)
            //{
            //    Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog(line.ScientificName);
            //    var result = dialog.ShowAsync();
            //}

            return resultSpecies;
        }
    }
}
