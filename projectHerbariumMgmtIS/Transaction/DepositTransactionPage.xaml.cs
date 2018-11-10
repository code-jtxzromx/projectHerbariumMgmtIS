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

        // Properties
        public bool IsExisting
        {
            get { return (bool)GetValue(IsExistingProperty); }
            set
            {
                SetValue(IsExistingProperty, value);
            }
        }
        public PlantDeposit NewDepositData
        {
            get { return (PlantDeposit)GetValue(NewDepositDataProperty); }
            set { SetValue(NewDepositDataProperty, value); }
        }

        public static readonly DependencyProperty IsExistingProperty =
            DependencyProperty.Register("IsExisting", typeof(bool), typeof(DepositTransactionPage), new PropertyMetadata(false));
        public static readonly DependencyProperty NewDepositDataProperty =
            DependencyProperty.Register("NewDepositData", typeof(PlantDeposit), typeof(DepositTransactionPage), new PropertyMetadata(new PlantDeposit()));
        
        // Constructor
        public DepositTransactionPage()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
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
            string message = "";

            if (ValidateForm())
            {
                NewDepositData.DateCollected = dpkDateCollected.Date.ToString();
                NewDepositData.DateDeposited = dpkDateDeposited.Date.ToString();
                NewDepositData.DateVerified = dpkDateVerified.Date.ToString();

                if (IsExisting && btnIsVerifiedDeposit.IsOn)                
                    TransactionResult = NewDepositData.SaveVerifiedDeposit((chkSameAccession.IsChecked == true), 
                                                                            isFileUpload, imageBinary);
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

        private void btnCapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            isFileUpload = false;
        }

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
            if (cbxPlantType.SelectedIndex == -1)
            {
                msgPlantType.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (IsExisting && IsVerified && cbxScientificName.SelectedIndex == -1)
            {
                msgScientifcName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxCollector.SelectedIndex == -1)
            {
                msgCollector.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (IsExisting && IsVerified && cbxValidator.SelectedIndex == -1)
            {
                msgValidator.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxLocality.SelectedIndex == -1)
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
