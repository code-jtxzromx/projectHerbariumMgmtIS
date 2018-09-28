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
    public sealed partial class ValidatorForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public Validator ValidatorData
        {
            get { return (Validator)GetValue(ValidatorDataProperty); }
            set { SetValue(ValidatorDataProperty, value); }
        }

        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(ValidatorForm), new PropertyMetadata(""));
        public static readonly DependencyProperty ValidatorDataProperty =
            DependencyProperty.Register("ValidatorData", typeof(Validator), typeof(ValidatorForm), new PropertyMetadata(new Validator()));

        // Constructor
        public ValidatorForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add External Validator")
                {
                    TransactionResult = ValidatorData.AddValidator();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit External Validator")
                {
                    TransactionResult = ValidatorData.EditValidator();
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
            msgInstitution.Visibility = Visibility.Collapsed;

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
            if (txfInstitution.Text == "")
            {
                msgInstitution.Visibility = Visibility.Visible;
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
            msgInstitution.Visibility = Visibility.Collapsed;

            ValidatorData = new Validator();

            TransactionForm = "Add External Validator";
            PrimaryButtonText = "Save";
        }
    }
}
