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
    public sealed partial class TaxonClassPage : Page
    {
        public TaxonClassPage()
        {
            this.InitializeComponent();
            this.InitializePage();
        }

        public void InitializePage() => dgrClassTable.ItemsSource = new TaxonClass().GetClasses();

        private void btnAddClass_Click(object sender, RoutedEventArgs e) => this.LoadForm("Add Class");

        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            if (dgrClassTable.SelectedIndex != -1)
                this.LoadForm("Edit Class", dgrClassTable.SelectedItem as TaxonClass);
        }

        private async void LoadForm(string transaction, TaxonClass tclass = null)
        {
            ClassForm form = new ClassForm()
            {
                TransactionForm = transaction,
                ClassData = (tclass == null) ? new TaxonClass() : tclass,
                PrimaryButtonText = (transaction == "Add Class") ? "Save" : "Update"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string message = "";

                switch (form.TransactionResult)
                {
                    case 0:
                        message = (form.TransactionForm == "Add Class") ? "Class Added to the Database" : "Class Updated in the Database";
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
