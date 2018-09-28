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
    public sealed partial class BorrowerForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public Borrower BorrowerData
        {
            get { return (Borrower)GetValue(BorrowerDataProperty); }
            set { SetValue(BorrowerDataProperty, value); }
        }

        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(BorrowerForm), new PropertyMetadata(""));
        public static readonly DependencyProperty BorrowerDataProperty =
            DependencyProperty.Register("BorrowerData", typeof(Borrower), typeof(BorrowerForm), new PropertyMetadata(new Borrower()));

        // Constructor
        public BorrowerForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Borrower")
                {
                    TransactionResult = BorrowerData.AddBorrower();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Borrower")
                {
                    TransactionResult = BorrowerData.EditBorrower();
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
            msgHomeAddress.Visibility = Visibility.Collapsed;
            msgContactNumber.Visibility = Visibility.Collapsed;
            msgEmailAddress.Visibility = Visibility.Collapsed;
            msgAffiliation.Visibility = Visibility.Collapsed;

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
            if (txfHomeAddress.Text == "")
            {
                msgHomeAddress.Visibility = Visibility.Visible;
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
            if (txfAffiliation.Text == "")
            {
                msgAffiliation.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgFirstName.Visibility = Visibility.Collapsed;
            msgMiddleName.Visibility = Visibility.Collapsed;
            msgLastName.Visibility = Visibility.Collapsed;
            msgHomeAddress.Visibility = Visibility.Collapsed;
            msgContactNumber.Visibility = Visibility.Collapsed;
            msgEmailAddress.Visibility = Visibility.Collapsed;
            msgAffiliation.Visibility = Visibility.Collapsed;

            BorrowerData = new Borrower();

            TransactionForm = "Add Borrower";
            PrimaryButtonText = "Save";
        }
    }
}
