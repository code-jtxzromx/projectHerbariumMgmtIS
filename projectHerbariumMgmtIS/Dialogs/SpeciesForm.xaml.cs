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
    public sealed partial class SpeciesForm : ContentDialog
    {
        public int TransactionResult;
        private List<string> VerifiedSpecies;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonSpecies SpeciesData
        {
            get { return (TaxonSpecies)GetValue(SpeciesDataProperty); }
            set
            {
                SetValue(SpeciesDataProperty, value);
                chkIsKnownSpecies.IsChecked = value.IdentifiedStatus;
            }
        }

        public static readonly DependencyProperty SpeciesDataProperty =
            DependencyProperty.Register("SpeciesData", typeof(TaxonSpecies), typeof(SpeciesForm), new PropertyMetadata(new TaxonSpecies()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(SpeciesForm), new PropertyMetadata(""));

        // Constructor
        public SpeciesForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void txfSpeciesName_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = from species in VerifiedSpecies
                                  where species.ToUpper().StartsWith(sender.Text.ToUpper())
                                  select species;

                if (suggestions.Count() > 0)
                    sender.ItemsSource = suggestions;
                else
                    sender.ItemsSource = null;
            }
        }

        private void chkIsKnownSpecies_CheckChanged(object sender, RoutedEventArgs e)
        {
            txfSpeciesName.IsEnabled = (chkIsKnownSpecies.IsChecked == true);
            txfSpeciesName.Text = (chkIsKnownSpecies.IsChecked == true) ? "" : "sp.";
            SpeciesData.SpeciesName = (chkIsKnownSpecies.IsChecked == true) ? "" : "sp.";
            cbxAuthorsName.Visibility = (chkIsKnownSpecies.IsChecked == true) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Species")
                {
                    TransactionResult = SpeciesData.AddSpecies();
                    args.Cancel = true;
                }
                else if (TransactionForm == "Edit Species")
                {
                    TransactionResult = SpeciesData.EditSpecies();
                    args.Cancel = false;
                }
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
            msgGenusName.Visibility = Visibility.Collapsed;
            msgSpeciesName.Visibility = Visibility.Collapsed;
            msgCommonName.Visibility = Visibility.Collapsed;
            msgAuthorsName.Visibility = Visibility.Collapsed;

            if (cbxGenusName.SelectedIndex == -1)
            {
                msgGenusName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfSpeciesName.Text == "")
            {
                msgSpeciesName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfCommonName.Text == "")
            {
                msgCommonName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (chkIsKnownSpecies.IsChecked == true && cbxAuthorsName.SelectedIndex == -1)
            {
                msgAuthorsName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgGenusName.Visibility = Visibility.Collapsed;
            msgSpeciesName.Visibility = Visibility.Collapsed;
            msgCommonName.Visibility = Visibility.Collapsed;
            msgAuthorsName.Visibility = Visibility.Collapsed;
            
            cbxGenusName.ItemsSource = new TaxonGenus().GetGenusList();
            cbxAuthorsName.ItemsSource = new SpeciesAuthor().GetAuthorList();

            SpeciesData = new TaxonSpecies() { IdentifiedStatus = true };
            VerifiedSpecies = new TaxonSpecies().GetVerifiedSpecies();
            chkIsKnownSpecies_CheckChanged(chkIsKnownSpecies, null);

            TransactionForm = "Add Species";
            PrimaryButtonText = "Save";
        }
    }
}
