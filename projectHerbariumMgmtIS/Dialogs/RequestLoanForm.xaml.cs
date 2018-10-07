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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Dialogs
{
    public sealed partial class RequestLoanForm : ContentDialog
    {
        private PlantLoan NewLoan = new PlantLoan();
        private List<string> DurationType = new List<string>() { "Day/s", "Month/s" };
        private List<TaxonGenus> GenusList;
        private List<TaxonSpecies> SpeciesList;
        private int TransactionResult;

        // Constuctor
        public RequestLoanForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm() && this.ValidateLoaningSpecies())
            {
                List<TaxonSpecies> SelectedSpecies = new List<TaxonSpecies>();

                NewLoan.Status = (StaticAccess.Role == "STUDENT ASSISTANT") ? "Requesting" : "Approved";
                NewLoan.Borrower = cbxBorrower.SelectedItem.ToString();
                NewLoan.StartDate = dpkLoanDate.Date.ToString();

                if (rbtPurpose1.IsChecked == true) NewLoan.Purpose = "Research";
                else if (rbtPurpose2.IsChecked == true) NewLoan.Purpose = "Academic";
                else if (rbtPurpose3.IsChecked == true) NewLoan.Purpose = txfOtherPurpose.Text;

                NewLoan.ReturningDate = ((cbxDuration.SelectedIndex == 0) ?
                                        dpkLoanDate.Date.AddDays(Convert.ToDouble(txfDuration.Text)) :
                                        dpkLoanDate.Date.AddMonths(Convert.ToInt32(txfDuration.Text))).ToString();

                foreach (TaxonSpecies species in dgrSpeciesList.ItemsSource)
                {
                    if (species.IsChecked)
                        SelectedSpecies.Add(species);
                }


                string message = "";
                TransactionResult = NewLoan.ProcessNewLoan(SelectedSpecies);

                switch (TransactionResult)
                {
                    case 0:
                        message = "Plant Deposit Transaction Processed Successfully";
                        break;
                    case 1:
                        message = "Plant Deposit Transaction Processed with Some Records got Error";
                        break;
                    case -1:
                        message = "Transaction Failed, The system had run to an Error";
                        break;
                    default:
                        message = TransactionResult.ToString();
                        break;
                }
                MessageDialog dialog = new MessageDialog(message, "Process Done");
                var result = dialog.ShowAsync();
            }
            else
                args.Cancel = true;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClearForm();
            args.Cancel = true;
        }

        private void dpkLoanDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (e.NewDate <= DateTimeOffset.Now)
                dpkLoanDate.Date = DateTimeOffset.Now.AddDays(1);
        }
        
        private void rbtPurpose_CheckChange(object sender, RoutedEventArgs e)
        {
            bool otherPurpose = (rbtPurpose3.IsChecked == true);
            txfOtherPurpose.Visibility = otherPurpose ? Visibility.Visible : Visibility.Collapsed;
            msgOtherPurpose.Visibility = Visibility.Collapsed;
        }

        private void btnLoadGenus_Click(object sender, RoutedEventArgs e)
        {
            List<TaxonGenus> selectedGenera = new List<TaxonGenus>();

            foreach (TaxonFamily family in lstFamilyList.Items)
            {
                if (family.IsChecked)
                {
                    var result = from genus in GenusList
                                 where genus.FamilyName == family.FamilyName
                                 select genus;

                    foreach (var item in result)
                        selectedGenera.Add(item);

                }
            }

            lstGenusList.ItemsSource = selectedGenera;
        }

        private void btnLoadSpecies_Click(object sender, RoutedEventArgs e)
        {
            List<TaxonSpecies> selectedSpecies = new List<TaxonSpecies>();

            foreach (TaxonGenus genus in lstGenusList.Items)
            {
                if (genus.IsChecked)
                {
                    var result = from species in SpeciesList
                                 where species.GenusName == genus.GenusName
                                 select species;

                    foreach (var item in result)
                        selectedSpecies.Add(item);
                }
            }

            dgrSpeciesList.ItemsSource = selectedSpecies;
        }

        // Methods
        private bool ValidateForm()
        {
            bool formOK = true;
            bool familyOK = false;
            bool genusOK = false;
            bool speciesOK = false;
            msgBorrower.Visibility = Visibility.Collapsed;
            msgDuration.Visibility = Visibility.Collapsed;
            msgOtherPurpose.Visibility = Visibility.Collapsed;
            msgFamilyList.Visibility = Visibility.Collapsed;
            msgGenusList.Visibility = Visibility.Collapsed;
            msgSpeciesList.Visibility = Visibility.Collapsed;
            
            foreach (TaxonFamily family in lstFamilyList.Items)
            {
                if (family.IsChecked)
                    familyOK = true;
            }
            foreach (TaxonGenus genus in lstGenusList.Items)
            {
                if (genus.IsChecked)
                    genusOK = true;
            }
            if (!(dgrSpeciesList.ItemsSource is null))
            {
                foreach (var species in dgrSpeciesList.ItemsSource)
                {
                    if ((species as TaxonSpecies).IsChecked)
                        speciesOK = true;
                }
            }

            if (cbxBorrower.SelectedIndex == -1)
            {
                msgBorrower.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfDuration.Text == "" || cbxDuration.SelectedIndex == -1)
            {
                msgDuration.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (rbtPurpose3.IsChecked == true && txfOtherPurpose.Text == "")
            {
                msgOtherPurpose.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (!familyOK)
            {
                msgFamilyList.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (!genusOK)
            {
                msgGenusList.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (!speciesOK)
            {
                msgSpeciesList.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private bool ValidateLoaningSpecies()
        {
            bool formOK = true;
            bool exceedError = false;

            if (!(dgrSpeciesList.ItemsSource is null))
            foreach (TaxonSpecies species in dgrSpeciesList.ItemsSource)
            {
                if (species.IsChecked && species.Specimens < species.Copies)
                {
                    exceedError = true;
                    formOK = false;
                }
            }

            if (exceedError)
            {
                MessageDialog message = new MessageDialog("The Number of Copies you Request should not be more than the actual Available Specimens",
                                                          "Required Copies exceeded available Specimens");
                var result = message.ShowAsync();
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgBorrower.Visibility = Visibility.Collapsed;
            msgDuration.Visibility = Visibility.Collapsed;
            msgOtherPurpose.Visibility = Visibility.Collapsed;
            msgFamilyList.Visibility = Visibility.Collapsed;
            msgGenusList.Visibility = Visibility.Collapsed;
            msgSpeciesList.Visibility = Visibility.Collapsed;

            NewLoan = new PlantLoan();
            cbxBorrower.ItemsSource = new Borrower().GetBorrowerList();
            cbxDuration.ItemsSource = DurationType;
            lstFamilyList.ItemsSource = new TaxonFamily().GetFamilies();
            GenusList = new TaxonGenus().GetGenera();
            SpeciesList = new TaxonSpecies().GetSpeciesWithCheck();
            lstGenusList.ItemsSource = null;
            dgrSpeciesList.ItemsSource = null;

            cbxBorrower.SelectedIndex = -1;
            dpkLoanDate.Date = DateTimeOffset.Now.AddDays(1);
            txfDuration.Text = "";
            cbxDuration.SelectedIndex = -1;
            txfOtherPurpose.Text = "";
            txfOtherPurpose.Visibility = Visibility.Collapsed;

            rbtPurpose1.IsChecked = true;
        }
    }
}
