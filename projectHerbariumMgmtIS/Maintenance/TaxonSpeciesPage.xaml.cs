using projectHerbariumMgmtIS.Dialogs;
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

namespace projectHerbariumMgmtIS.Maintenance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaxonSpeciesPage : Page
    {
        public TaxonSpeciesPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrSpeciesTable.ItemsSource = new TaxonSpecies().GetSpecies();

        private void btnAddSpecies_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Species");

        private void btnEditSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (dgrSpeciesTable.SelectedIndex != -1)
                this.LoadForm("Edit Species", dgrSpeciesTable.SelectedItem as TaxonSpecies);
        }

        private async void LoadForm(string transaction, TaxonSpecies species = null)
        {
            SpeciesForm form = new SpeciesForm()
            {
                TransactionForm = transaction,
                SpeciesData = (species == null) ? new TaxonSpecies() : species,
                PrimaryButtonText = (transaction == "Add Species") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Species") ? "Species Added to the Database" : "Species Updated in the Database";
                        break;
                    case 1:
                        message = "The System had run to an Error";
                        break;
                    case 2:
                        message = "Information is Already Exists in the Database";
                        break;
                }

                MessageDialog dialog = new MessageDialog(message);
                await dialog.ShowAsync();

                this.InitializePage();
            }
        }
    }
}
