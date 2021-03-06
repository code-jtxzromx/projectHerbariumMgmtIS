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
    public sealed partial class ViewLoanForm : ContentDialog
    {
        // Properties
        public List<TaxonSpecies> LoanedSpecies;
        public PlantLoan PlantLoanData
        {
            get { return (PlantLoan)GetValue(PlantLoanDataProperty); }
            set
            {
                SetValue(PlantLoanDataProperty, value);
                dgrLoanedSpecies.ItemsSource = new TaxonSpecies().GetLoanedSpecies(value.LoanNumber);

                if (value.Status == "Approved")
                    dgrLoanedSheets.ItemsSource = new HerbariumSheet().GetLoanedSheets(value.LoanNumber);
                else
                    pnlLoanedSheets.Visibility = Visibility.Collapsed;
            }
        }

        public static readonly DependencyProperty PlantLoanDataProperty =
            DependencyProperty.Register("PlantLoanData", typeof(PlantLoan), typeof(ViewLoanForm), new PropertyMetadata(new PlantLoan()));
        
        // Constructor
        public ViewLoanForm()
        {
            this.InitializeComponent();
        }
    }
}
