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
    public sealed partial class NomenclatureForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public SpeciesNomenclature NomenclatureData
        {
            get { return (SpeciesNomenclature)GetValue(NomenclatureDataProperty); }
            set { SetValue(NomenclatureDataProperty, value); }
        }

        public static readonly DependencyProperty NomenclatureDataProperty =
            DependencyProperty.Register("NomenclatureData", typeof(SpeciesNomenclature), typeof(NomenclatureForm), new PropertyMetadata(new SpeciesNomenclature()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(NomenclatureForm), new PropertyMetadata(""));

        // Constructor
        public NomenclatureForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        // Event Methods
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Species Nomenclature")
                {
                    TransactionResult = NomenclatureData.AddNomenclature();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Species Nomenclature")
                {
                    TransactionResult = NomenclatureData.EditNomenclature();
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
            msgTaxonName.Visibility = Visibility.Collapsed;
            msgLanguage.Visibility = Visibility.Collapsed;
            msgAlternateName.Visibility = Visibility.Collapsed;

            if (cbxTaxonName.SelectedIndex == -1)
            {
                msgTaxonName.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfLanguage.Text == "")
            {
                msgLanguage.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfAlternateName.Text == "")
            {
                msgAlternateName.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgTaxonName.Visibility = Visibility.Collapsed;
            msgLanguage.Visibility = Visibility.Collapsed;
            msgAlternateName.Visibility = Visibility.Collapsed;

            NomenclatureData = new SpeciesNomenclature();
            cbxTaxonName.ItemsSource = new TaxonSpecies().GetTaxonList();

            TransactionForm = "Add Species Nomenclature";
            PrimaryButtonText = "Save";
        }
    }
}
