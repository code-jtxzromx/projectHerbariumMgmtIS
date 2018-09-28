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
    public sealed partial class StaffForm : ContentDialog
    {
        public int TransactionResult;
        private List<string> Role = new List<string> { "ADMISTRATOR", "CURATOR", "STUDENT-ASSISTANT" }; 

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public Staff StaffData
        {
            get { return (Staff)GetValue(StaffDataProperty); }
            set { SetValue(StaffDataProperty, value); }
        }

        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(StaffForm), new PropertyMetadata(""));
        public static readonly DependencyProperty StaffDataProperty =
            DependencyProperty.Register("StaffData", typeof(Staff), typeof(StaffForm), new PropertyMetadata(new Staff()));

        // Constructor
        public StaffForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Herbarium Staff")
                {
                    TransactionResult = StaffData.AddStaff();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Herbarium Staff")
                {
                    TransactionResult = StaffData.EditStaff();
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
            msgFirstName.Visibility = Visibility.Collapsed;
            msgMiddleName.Visibility = Visibility.Collapsed;
            msgLastName.Visibility = Visibility.Collapsed;
            msgContactNumber.Visibility = Visibility.Collapsed;
            msgEmailAddress.Visibility = Visibility.Collapsed;
            msgRole.Visibility = Visibility.Collapsed;
            msgDepartment.Visibility = Visibility.Collapsed;

            if (txfFirstName.Text == "")
            {
                msgFirstName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfMiddleName.Text == "")
            {
                msgMiddleName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfLastName.Text == "")
            {
                msgLastName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfContactNumber.Text == "")
            {
                msgContactNumber.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfEmailAddress.Text == "")
            {
                msgEmailAddress.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (cbxRole.SelectedIndex == -1)
            {
                msgRole.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfDepartment.Text == "")
            {
                msgDepartment.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgFirstName.Visibility = Visibility.Collapsed;
            msgMiddleName.Visibility = Visibility.Collapsed;
            msgLastName.Visibility = Visibility.Collapsed;
            msgContactNumber.Visibility = Visibility.Collapsed;
            msgEmailAddress.Visibility = Visibility.Collapsed;
            msgRole.Visibility = Visibility.Collapsed;
            msgDepartment.Visibility = Visibility.Collapsed;

            StaffData = new Staff();
            cbxRole.ItemsSource = Role;

            TransactionForm = "Add Herbarium Staff";
            PrimaryButtonText = "Save";
        }
    }
}
