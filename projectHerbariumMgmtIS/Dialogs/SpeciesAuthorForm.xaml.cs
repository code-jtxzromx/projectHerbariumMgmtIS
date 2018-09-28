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
    public sealed partial class SpeciesAuthorForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public SpeciesAuthor AuthorData
        {
            get { return (SpeciesAuthor)GetValue(AuthorDataProperty); }
            set { SetValue(AuthorDataProperty, value); }
        }

        public static readonly DependencyProperty AuthorDataProperty =
            DependencyProperty.Register("AuthorData", typeof(SpeciesAuthor), typeof(SpeciesAuthorForm), new PropertyMetadata(new SpeciesAuthor()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(SpeciesAuthorForm), new PropertyMetadata(""));

        // Constructor
        public SpeciesAuthorForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Species Author")
                {
                    TransactionResult = AuthorData.AddAuthor();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Species Author")
                {
                    TransactionResult = AuthorData.EditAuthor();
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
            msgAuthorsName.Visibility = Visibility.Collapsed;
            msgAuthorsSuffix.Visibility = Visibility.Collapsed;

            if (txfAuthorsName.Text == "")
            {
                msgAuthorsName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfAuthorsSuffix.Text == "")
            {
                msgAuthorsSuffix.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgAuthorsName.Visibility = Visibility.Collapsed;
            msgAuthorsSuffix.Visibility = Visibility.Collapsed;

            AuthorData = new SpeciesAuthor();
            
            TransactionForm = "Add Species Author";
            PrimaryButtonText = "Save";
        }
    }
}
