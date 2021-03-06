﻿using projectHerbariumMgmtIS.Model;
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
    public sealed partial class FamilyForm : ContentDialog
    {
        public int TransactionResult;
        private List<string> VerifiedFamilies;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public TaxonFamily FamilyData
        {
            get { return (TaxonFamily)GetValue(FamilyDataProperty); }
            set { SetValue(FamilyDataProperty, value); }
        }

        public static readonly DependencyProperty FamilyDataProperty =
            DependencyProperty.Register("FamilyData", typeof(TaxonFamily), typeof(FamilyForm), new PropertyMetadata(new TaxonFamily()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(FamilyForm), new PropertyMetadata(""));

        // Constructor
        public FamilyForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void txfFamilyName_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = from family in VerifiedFamilies
                                  where family.ToUpper().StartsWith(sender.Text.ToUpper())
                                  select family;

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
                if (TransactionForm == "Add Family")
                {
                    TransactionResult = FamilyData.AddFamily();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Family")
                {
                    TransactionResult = FamilyData.EditFamily();
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
            msgOrderName.Visibility = Visibility.Collapsed;
            msgFamilyName.Visibility = Visibility.Collapsed;

            if (cbxOrderName.SelectedIndex == -1)
            {
                msgOrderName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfFamilyName.Text == "")
            {
                msgFamilyName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgOrderName.Visibility = Visibility.Collapsed;
            msgFamilyName.Visibility = Visibility.Collapsed;

            FamilyData = new TaxonFamily();
            VerifiedFamilies = new TaxonFamily().GetVerifiedFamilies();
            cbxOrderName.ItemsSource = new TaxonOrder().GetOrderList();

            TransactionForm = "Add Family";
            PrimaryButtonText = "Save";
        }
    }
}
