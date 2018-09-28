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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Maintenance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpeciesAuthorPage : Page
    {
        public SpeciesAuthorPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrAuthorTable.ItemsSource = new SpeciesAuthor().GetAuthors();

        private void btnAddAuthor_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Species Author");

        private void btnEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (dgrAuthorTable.SelectedIndex != -1)
                this.LoadForm("Edit Species Author", dgrAuthorTable.SelectedItem as SpeciesAuthor);
        }

        private async void LoadForm(string transaction, SpeciesAuthor author = null)
        {
            SpeciesAuthorForm form = new SpeciesAuthorForm()
            {
                TransactionForm = transaction,
                AuthorData = (author == null) ? new SpeciesAuthor() : author,
                PrimaryButtonText = (transaction == "Add Species Author") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Species Author") ? "Species Author Added to the Database" : "Species Author Updated in the Database";
                        break;
                    case 1:
                        message = "The System had run to an Error";
                        break;
                    case 2:
                        message = "Information is Already Exists in the Database";
                        break;
                }

                ResultDialog dialog = new ResultDialog()
                {
                    TextContent = message
                };
                await dialog.ShowAsync();

                this.InitializePage();
            }
        }
    }
}
