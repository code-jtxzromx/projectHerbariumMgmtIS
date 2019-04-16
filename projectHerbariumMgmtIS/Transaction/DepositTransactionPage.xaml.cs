using projectHerbariumMgmtIS.Dialogs;
using projectHerbariumMgmtIS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace projectHerbariumMgmtIS.Transaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DepositTransactionPage : Page
    {
        private bool isFileUpload = false;
        private byte[] imageBinary;
        private int TransactionResult;
        private List<SpeciesAuthor> speciesAuthors;

        // Properties
        public bool IsExisting
        {
            get { return (bool)GetValue(IsExistingProperty); }
            set { SetValue(IsExistingProperty, value); }
        }
        public PlantDeposit NewDepositData
        {
            get { return (PlantDeposit)GetValue(NewDepositDataProperty); }
            set { SetValue(NewDepositDataProperty, value); }
        }
        public PlantType NewPlantType
        {
            get { return (PlantType)GetValue(NewPlantTypeProperty); }
            set { SetValue(NewPlantTypeProperty, value); }
        }
        public TaxonSpecies NewSpecies
        {
            get { return (TaxonSpecies)GetValue(NewSpeciesProperty); }
            set { SetValue(NewSpeciesProperty, value); }
        }
        public Collector NewCollector
        {
            get { return (Collector)GetValue(NewCollectorProperty); }
            set { SetValue(NewCollectorProperty, value); }
        }
        public Validator NewValidator
        {
            get { return (Validator)GetValue(NewValidatorProperty); }
            set { SetValue(NewValidatorProperty, value); }
        }
        public PlantLocality NewLocality
        {
            get { return (PlantLocality)GetValue(NewLocalityProperty); }
            set { SetValue(NewLocalityProperty, value); }
        }
        public bool IsVerified
        {
            get { return (bool)GetValue(IsVerifiedProperty); }
            set
            {
                SetValue(IsVerifiedProperty, value);
                int SpanCol = (value) ? 3 : 1;

                Grid.SetColumnSpan(cbxLocality, SpanCol);
                Grid.SetColumnSpan(msgLocality, SpanCol);
                Grid.SetColumnSpan(txfLocality, SpanCol);
                Grid.SetColumnSpan(txfDescription, SpanCol);
                Grid.SetColumnSpan(msgDescription, SpanCol);
                Grid.SetColumn(btnAddLocality, SpanCol);
                Grid.SetColumn(btnDeleteLocality, SpanCol);

                msgOrgAccessionNo.Visibility = Visibility.Collapsed;
                msgNewAccessionNo.Visibility = Visibility.Collapsed;
                msgPlantType.Visibility = Visibility.Collapsed;
                msgScientifcName.Visibility = Visibility.Collapsed;
                msgCollector.Visibility = Visibility.Collapsed;
                msgValidator.Visibility = Visibility.Collapsed;
                msgLocality.Visibility = Visibility.Collapsed;
                msgDescription.Visibility = Visibility.Collapsed;
            }
        }
        public static readonly DependencyProperty IsVerifiedProperty =
            DependencyProperty.Register("IsVerified", typeof(bool), typeof(DepositTransactionPage), new PropertyMetadata(false));
        public static readonly DependencyProperty NewDepositDataProperty =
            DependencyProperty.Register("NewDepositData", typeof(PlantDeposit), typeof(DepositTransactionPage), new PropertyMetadata(new PlantDeposit()));
        public static readonly DependencyProperty NewPlantTypeProperty =
            DependencyProperty.Register("NewPlantType", typeof(PlantType), typeof(DepositTransactionPage), new PropertyMetadata(new PlantType()));
        public static readonly DependencyProperty NewSpeciesProperty =
            DependencyProperty.Register("NewSpecies", typeof(TaxonSpecies), typeof(DepositTransactionPage), new PropertyMetadata(new TaxonSpecies()));
        public static readonly DependencyProperty NewCollectorProperty =
            DependencyProperty.Register("NewCollector", typeof(Collector), typeof(DepositTransactionPage), new PropertyMetadata(new Collector()));
        public static readonly DependencyProperty NewValidatorProperty =
            DependencyProperty.Register("NewValidator", typeof(Validator), typeof(Validator), new PropertyMetadata(new Validator()));
        public static readonly DependencyProperty NewLocalityProperty =
            DependencyProperty.Register("NewLocality", typeof(PlantLocality), typeof(DepositTransactionPage), new PropertyMetadata(new PlantLocality()));
        public static readonly DependencyProperty IsExistingProperty =
            DependencyProperty.Register("IsExisting", typeof(bool), typeof(DepositTransactionPage), new PropertyMetadata(false));

        // Constructor
        public DepositTransactionPage()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private async void btnAddPlantType_Click(object sender, RoutedEventArgs e)
        {
            PlantTypeForm form = new PlantTypeForm()
            {
                TransactionForm = "Add Plant Type",
                IsMaintenance = false,
                PrimaryButtonText = "Save"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                NewPlantType = form.PlantTypeData;
                cbxPlantType.Visibility = Visibility.Collapsed;
                btnAddPlantType.Visibility = Visibility.Collapsed;
                txfPlantType.Visibility = Visibility.Visible;
                btnDeletePlantType.Visibility = Visibility.Visible;
            }
        }

        private async void btnAddTaxon_Click(object sender, RoutedEventArgs e)
        {
            SpeciesForm form = new SpeciesForm()
            {
                TransactionForm = "Add Species",
                IsMaintenance = false,
                PrimaryButtonText = "Save"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var NewData = form.SpeciesData;
                string authorCode = "";
                try
                {
                    authorCode = (from data in speciesAuthors
                                  where data.AuthorName == NewData.SpeciesAuthor
                                  select data.AuthorSuffix).First();
                }
                catch (Exception) {  }

                NewData.ScientificName = (NewData.GenusName + " " + NewData.SpeciesName + " " + authorCode).Trim();
                NewSpecies = NewData;

                cbxScientificName.Visibility = Visibility.Collapsed;
                btnAddTaxon.Visibility = Visibility.Collapsed;
                txfScientificName.Visibility = Visibility.Visible;
                btnDeleteTaxon.Visibility = Visibility.Visible;
            }
        }

        private async void btnAddCollector_Click(object sender, RoutedEventArgs e)
        {
            CollectorForm form = new CollectorForm()
            {
                TransactionForm = "Add Collector",
                IsMaintenance = false,
                PrimaryButtonText = "Save"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var NewData = form.CollectorData;
                NewData.FullName = (NewData.FirstName + " " + NewData.LastName + " " + NewData.NameSuffix).Trim();
                NewCollector = NewData;

                cbxCollector.Visibility = Visibility.Collapsed;
                btnAddCollector.Visibility = Visibility.Collapsed;
                txfCollector.Visibility = Visibility.Visible;
                btnDeleteCollector.Visibility = Visibility.Visible;
            }
        }

        private async void btnAddValidator_Click(object sender, RoutedEventArgs e)
        {
            ValidatorForm form = new ValidatorForm()
            {
                TransactionForm = "Add External Validator",
                IsMaintenance = false,
                PrimaryButtonText = "Save"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var NewData = form.ValidatorData;
                NewData.FullName = (NewData.FirstName + " " + NewData.LastName + " " + NewData.NameSuffix).Trim();
                NewValidator = NewData;

                cbxValidator.Visibility = Visibility.Collapsed;
                btnAddValidator.Visibility = Visibility.Collapsed;
                txfValidator.Visibility = Visibility.Visible;
                btnDeleteValidator.Visibility = Visibility.Visible;
            }
        }

        private async void btnAddLocality_Click(object sender, RoutedEventArgs e)
        {
            LocalityForm form = new LocalityForm()
            {
                TransactionForm = "Add Plant Locality",
                IsMaintenance = false,
                PrimaryButtonText = "Save"
            };
            var result = await form.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                NewLocality = form.LocalityData;

                cbxLocality.Visibility = Visibility.Collapsed;
                btnAddLocality.Visibility = Visibility.Collapsed;
                txfLocality.Visibility = Visibility.Visible;
                btnDeleteLocality.Visibility = Visibility.Visible;
            }
        }

        private void btnDeletePlantType_Click(object sender, RoutedEventArgs e)
        {
            cbxPlantType.Visibility = Visibility.Visible;
            btnAddPlantType.Visibility = Visibility.Visible;
            txfPlantType.Visibility = Visibility.Collapsed;
            btnDeletePlantType.Visibility = Visibility.Collapsed;
        }

        private void btnDeleteTaxon_Click(object sender, RoutedEventArgs e)
        {
            cbxScientificName.Visibility = Visibility.Visible;
            btnAddTaxon.Visibility = Visibility.Visible;
            txfScientificName.Visibility = Visibility.Collapsed;
            btnDeleteTaxon.Visibility = Visibility.Collapsed;
        }

        private void btnDeleteCollector_Click(object sender, RoutedEventArgs e)
        {
            cbxCollector.Visibility = Visibility.Visible;
            btnAddCollector.Visibility = Visibility.Visible;
            txfCollector.Visibility = Visibility.Collapsed;
            btnDeleteCollector.Visibility = Visibility.Collapsed;
        }

        private void btnDeleteValidator_Click(object sender, RoutedEventArgs e)
        {
            cbxValidator.Visibility = Visibility.Visible;
            btnAddValidator.Visibility = Visibility.Visible;
            txfValidator.Visibility = Visibility.Collapsed;
            btnDeleteValidator.Visibility = Visibility.Collapsed;
        }

        private void btnDeleteLocality_Click(object sender, RoutedEventArgs e)
        {
            cbxLocality.Visibility = Visibility.Visible;
            btnAddLocality.Visibility = Visibility.Visible;
            txfLocality.Visibility = Visibility.Collapsed;
            btnDeleteLocality.Visibility = Visibility.Collapsed;
        }

        private void cbxScientificName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxScientificName.SelectedIndex != -1)
                cbxNewAccessionNo.ItemsSource = new PlantDeposit().GetVerifiedAccessions(cbxScientificName.SelectedItem as string);
        }

        private void txfOrgAccessionNo_LostFocus(object sender, RoutedEventArgs e)
        {
            int accessionNumber;
            if (Int32.TryParse(txfOrgAccessionNo.Text, out accessionNumber))
            {
                if (new PlantDeposit().IsAccessionUnique(accessionNumber))
                {
                    txfOrgAccessionNo.Text = "";
                    MessageDialog dialog = new MessageDialog("Accession Number already existed in the database");
                    var result = dialog.ShowAsync();
                }
            }
        }

        private void dpkDateCollected_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (e.NewDate > DateTimeOffset.Now)
                dpkDateCollected.Date = DateTimeOffset.Now.AddDays(-1);
        }

        private void dpkDateDeposited_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (e.NewDate > DateTimeOffset.Now)
                dpkDateDeposited.Date = DateTimeOffset.Now.AddDays(-1);
        }

        private void dpkDateVerified_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (e.NewDate > DateTimeOffset.Now)
                dpkDateVerified.Date = DateTimeOffset.Now.AddDays(-1);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool MaintenanceOK = true;
            string message = "";

            if (ValidateForm())
            {
                if (txfPlantType.Visibility == Visibility.Visible)
                {
                    var result = NewPlantType.AddPlantType();

                    if (result == 1)
                        MaintenanceOK = false;
                }
                if (MaintenanceOK && txfScientificName.Visibility == Visibility.Visible)
                {
                    var result = NewSpecies.AddSpecies();

                    if (result == 1)
                        MaintenanceOK = false;
                }
                if (MaintenanceOK && txfCollector.Visibility == Visibility.Visible)
                {
                    var result = NewCollector.AddCollector();

                    if (result == 1)
                        MaintenanceOK = false;
                }
                if (MaintenanceOK && txfValidator.Visibility == Visibility.Visible)
                {
                    var result = NewValidator.AddValidator();

                    if (result == 1)
                        MaintenanceOK = false;
                }
                if (MaintenanceOK && txfLocality.Visibility == Visibility.Visible)
                {
                    var result = NewLocality.AddLocality();

                    if (result == 1)
                        MaintenanceOK = false;
                }

                if (MaintenanceOK)
                {
                    NewDepositData.PlantType = (cbxPlantType.Visibility == Visibility.Visible) ? cbxPlantType.SelectedItem.ToString() : txfPlantType.Text;
                    NewDepositData.TaxonName = (cbxScientificName.Visibility == Visibility.Visible) ? cbxScientificName.SelectedItem.ToString() : txfScientificName.Text;
                    NewDepositData.Collector = (cbxCollector.Visibility == Visibility.Visible) ? cbxCollector.SelectedItem.ToString() : txfCollector.Text;
                    NewDepositData.Validator = (cbxValidator.Visibility == Visibility.Visible) ? cbxValidator.SelectedItem.ToString() : txfValidator.Text;
                    NewDepositData.Locality = (cbxLocality.Visibility == Visibility.Visible) ? cbxLocality.SelectedItem.ToString() : txfLocality.Text;
                    NewDepositData.DateCollected = dpkDateCollected.Date.ToString();
                    NewDepositData.DateDeposited = dpkDateDeposited.Date.ToString();
                    NewDepositData.DateVerified = dpkDateVerified.Date.ToString();

                    if (IsExisting && btnIsVerifiedDeposit.IsOn)
                        TransactionResult = NewDepositData.SaveVerifiedDeposit((chkSameAccession.IsChecked == true), isFileUpload, imageBinary);
                    else if (IsExisting)
                        TransactionResult = NewDepositData.SaveUnverifiedDeposit(isFileUpload, imageBinary);
                    else
                        TransactionResult = NewDepositData.SaveNewDeposit(isFileUpload, imageBinary);

                    switch (TransactionResult)
                    {
                        case 0:
                            if (IsExisting && btnIsVerifiedDeposit.IsOn)
                                message = "Plant Deposit Received and Verified";
                            else if (IsExisting)
                                message = "Existing Plant Deposit Recorded";
                            else
                                message = "New Plant Deposit Received";
                            break;
                        case 1:
                            message = "Transaction Failed, The system had run to an Error";
                            break;
                    }

                    MessageDialog dialog = new MessageDialog(message, "Process Done");
                    var result = dialog.ShowAsync();

                    this.ClearForm();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Some data were save but the Plant Deposit Form had run to an Error", "Process Run to an Error");
                    var result = dialog.ShowAsync();
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) => this.ClearForm();

        private async void btnUploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            isFileUpload = true;
            FileOpenPicker filePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".png");

            StorageFile file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                picHerbariumSheet.Source = image;

                using (var inputStream = await file.OpenSequentialReadAsync())
                {
                    var readStream = inputStream.AsStreamForRead();

                    var byteArray = new byte[readStream.Length];
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                    this.imageBinary = byteArray;
                }
            }
        }

        private void btnCapturePhoto_Click(object sender, RoutedEventArgs e) => isFileUpload = false;

        // Methods
        private void ClearForm()
        {
            isFileUpload = false;
            picHerbariumSheet.Source = null;
            NewDepositData = new PlantDeposit();
            btnIsVerifiedDeposit.IsOn = false;

            msgOrgAccessionNo.Visibility = Visibility.Collapsed;
            msgNewAccessionNo.Visibility = Visibility.Collapsed;
            msgPlantType.Visibility = Visibility.Collapsed;
            msgScientifcName.Visibility = Visibility.Collapsed;
            msgCollector.Visibility = Visibility.Collapsed;
            msgValidator.Visibility = Visibility.Collapsed;
            msgLocality.Visibility = Visibility.Collapsed;
            msgDescription.Visibility = Visibility.Collapsed;

            cbxCollector.ItemsSource = new Collector().GetCollectorList();
            cbxLocality.ItemsSource = new PlantLocality().GetLocalityList();
            cbxPlantType.ItemsSource = new PlantType().GetPlantTypeList();
            cbxScientificName.ItemsSource = new TaxonSpecies().GetTaxonList();
            cbxValidator.ItemsSource = new Validator().GetValidatorList();
            speciesAuthors = new SpeciesAuthor().GetAuthors();
        }

        private bool ValidateForm()
        {
            bool formOK = true;
            bool IsVerified = btnIsVerifiedDeposit.IsOn;
            bool IsSameAccession = chkSameAccession.IsChecked == true;
            msgOrgAccessionNo.Visibility = Visibility.Collapsed;
            msgNewAccessionNo.Visibility = Visibility.Collapsed;
            msgPlantType.Visibility = Visibility.Collapsed;
            msgScientifcName.Visibility = Visibility.Collapsed;
            msgCollector.Visibility = Visibility.Collapsed;
            msgValidator.Visibility = Visibility.Collapsed;
            msgLocality.Visibility = Visibility.Collapsed;
            msgDescription.Visibility = Visibility.Collapsed;

            if (IsExisting && txfOrgAccessionNo.Text == "")
            {
                msgOrgAccessionNo.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (IsExisting && IsVerified && IsSameAccession && cbxNewAccessionNo.SelectedIndex == -1)
            {
                msgNewAccessionNo.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxPlantType.SelectedIndex == -1 && txfPlantType.Text == "")
            {
                msgPlantType.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (IsExisting && IsVerified && cbxScientificName.SelectedIndex == -1 && txfScientificName.Text == "")
            {
                msgScientifcName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxCollector.SelectedIndex == -1 && txfCollector.Text == "")
            {
                msgCollector.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (IsExisting && IsVerified && cbxValidator.SelectedIndex == -1 && txfValidator.Text == "")
            {
                msgValidator.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxLocality.SelectedIndex == -1 && txfLocality.Text == "")
            {
                msgLocality.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfDescription.Text == "")
            {
                msgDescription.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }
    }
}
