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
    public sealed partial class ClassForm : ContentDialog
    {
        public int TransactionResult;
        private List<string> VerifiedClasses;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonClass ClassData
        {
            get { return (TaxonClass)GetValue(ClassDataProperty); }
            set { SetValue(ClassDataProperty, value); }
        }

        public static readonly DependencyProperty ClassDataProperty =
            DependencyProperty.Register("ClassData", typeof(TaxonClass), typeof(ClassForm), new PropertyMetadata(new TaxonClass()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(ClassForm), new PropertyMetadata(""));

        // Constructor
        public ClassForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void txfClassName_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = from tclass in VerifiedClasses
                                  where tclass.ToUpper().StartsWith(sender.Text.ToUpper())
                                  select tclass;
                
                if (suggestions.Count() > 0)
                    sender.ItemsSource = suggestions;
                else
                    sender.ItemsSource = null;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Class")
                {
                    TransactionResult = ClassData.AddClass();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Class")
                {
                    TransactionResult = ClassData.EditClass();
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
            msgPhylumName.Visibility = Visibility.Collapsed;
            msgClassName.Visibility = Visibility.Collapsed;

            if (cbxPhylumName.SelectedIndex == -1)
            {
                msgPhylumName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfClassName.Text == "")
            {
                msgClassName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgPhylumName.Visibility = Visibility.Collapsed;
            msgClassName.Visibility = Visibility.Collapsed;

            ClassData = new TaxonClass();
            VerifiedClasses = new TaxonClass().GetVerifiedClasses();
            cbxPhylumName.ItemsSource = new TaxonPhylum().GetPhylumList();

            TransactionForm = "Add Class";
            PrimaryButtonText = "Save";
        }
    }
}
