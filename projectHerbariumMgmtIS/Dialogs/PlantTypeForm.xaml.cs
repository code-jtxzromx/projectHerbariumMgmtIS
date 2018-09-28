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
    public sealed partial class PlantTypeForm : ContentDialog
    {
        public int TransactionResult;

        // Properties
        public string TransactionForm
        {
            get { return (string)GetValue(TransactionFormProperty); }
            set { SetValue(TransactionFormProperty, value); }
        }
        public PlantType PlantTypeData
        {
            get { return (PlantType)GetValue(PlantTypeDataProperty); }
            set { SetValue(PlantTypeDataProperty, value); }
        }

        public static readonly DependencyProperty PlantTypeDataProperty =
            DependencyProperty.Register("PlantTypeData", typeof(PlantType), typeof(PlantTypeForm), new PropertyMetadata(new PlantType()));
        public static readonly DependencyProperty TransactionFormProperty =
            DependencyProperty.Register("TransactionForm", typeof(string), typeof(PlantTypeForm), new PropertyMetadata(""));

        // Constructor
        public PlantTypeForm()
        {
            this.InitializeComponent();
            this.ClearForm();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (this.ValidateForm())
            {
                if (TransactionForm == "Add Plant Type")
                {
                    TransactionResult = PlantTypeData.AddPlantType();
                    args.Cancel = false;
                }
                else if (TransactionForm == "Edit Plant Type")
                {
                    TransactionResult = PlantTypeData.EditPlantType();
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
            msgPlantCode.Visibility = Visibility.Collapsed;
            msgPlantType.Visibility = Visibility.Collapsed;

            if (txfPlantCode.Text == "")
            {
                msgPlantCode.Visibility = Visibility.Visible;
                formOK = false;
            }
            if (txfPlantType.Text == "")
            {
                msgPlantType.Visibility = Visibility.Visible;
                formOK = false;
            }

            return formOK;
        }

        private void ClearForm()
        {
            msgPlantCode.Visibility = Visibility.Collapsed;
            msgPlantType.Visibility = Visibility.Collapsed;

            PlantTypeData = new PlantType();

            TransactionForm = "Add Plant Type";
            PrimaryButtonText = "Save";
        }
    }
}
