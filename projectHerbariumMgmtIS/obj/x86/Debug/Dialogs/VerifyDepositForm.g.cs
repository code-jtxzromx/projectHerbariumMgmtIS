﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Dialogs\VerifyDepositForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5636CA262483A68A54CEB8AA27E81C6C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectHerbariumMgmtIS.Dialogs
{
    partial class VerifyDepositForm : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class VerifyDepositForm_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IVerifyDepositForm_Bindings
        {
            private global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.Image obj13;

            private VerifyDepositForm_obj1_BindingsTracking bindingsTracking;

            public VerifyDepositForm_obj1_Bindings()
            {
                this.bindingsTracking = new VerifyDepositForm_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Dialogs\VerifyDepositForm.xaml line 57
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 8: // Dialogs\VerifyDepositForm.xaml line 67
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 9: // Dialogs\VerifyDepositForm.xaml line 69
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // Dialogs\VerifyDepositForm.xaml line 71
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // Dialogs\VerifyDepositForm.xaml line 73
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // Dialogs\VerifyDepositForm.xaml line 75
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // Dialogs\VerifyDepositForm.xaml line 23
                        this.obj13 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    default:
                        break;
                }
            }

            // IVerifyDepositForm_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VerifyingDepositData(obj.VerifyingDepositData, phase);
                        this.Update_HerbariumSheet(obj.HerbariumSheet, phase);
                    }
                }
            }
            private void Update_VerifyingDepositData(global::projectHerbariumMgmtIS.Model.PlantDeposit obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VerifyingDepositData_AccessionNumber(obj.AccessionNumber, phase);
                        this.Update_VerifyingDepositData_DateCollected(obj.DateCollected, phase);
                        this.Update_VerifyingDepositData_DateDeposited(obj.DateDeposited, phase);
                        this.Update_VerifyingDepositData_Locality(obj.Locality, phase);
                        this.Update_VerifyingDepositData_Collector(obj.Collector, phase);
                        this.Update_VerifyingDepositData_Description(obj.Description, phase);
                    }
                }
            }
            private void Update_VerifyingDepositData_AccessionNumber(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 57
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj, null);
                }
            }
            private void Update_VerifyingDepositData_DateCollected(global::System.DateTimeOffset obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 67
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, obj.ToString(), null);
                }
            }
            private void Update_VerifyingDepositData_DateDeposited(global::System.DateTimeOffset obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 69
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj9, obj.ToString(), null);
                }
            }
            private void Update_VerifyingDepositData_Locality(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 71
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                }
            }
            private void Update_VerifyingDepositData_Collector(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 73
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                }
            }
            private void Update_VerifyingDepositData_Description(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 75
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                }
            }
            private void Update_HerbariumSheet(global::Windows.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\VerifyDepositForm.xaml line 23
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj13, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class VerifyDepositForm_obj1_BindingsTracking
            {
                private global::System.WeakReference<VerifyDepositForm_obj1_Bindings> weakRefToBindingObj; 

                public VerifyDepositForm_obj1_BindingsTracking(VerifyDepositForm_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<VerifyDepositForm_obj1_Bindings>(obj);
                }

                public VerifyDepositForm_obj1_Bindings TryGetBindingObject()
                {
                    VerifyDepositForm_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void DependencyPropertyChanged_VerifyingDepositData(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    VerifyDepositForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm;
                        if (obj != null)
                        {
                            bindings.Update_VerifyingDepositData(obj.VerifyingDepositData, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_HerbariumSheet(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    VerifyDepositForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm;
                        if (obj != null)
                        {
                            bindings.Update_HerbariumSheet(obj.HerbariumSheet, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_VerifyingDepositData = 0;
                private long tokenDPC_HerbariumSheet = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm obj)
                {
                    VerifyDepositForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm.VerifyingDepositDataProperty, tokenDPC_VerifyingDepositData);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm.HerbariumSheetProperty, tokenDPC_HerbariumSheet);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_VerifyingDepositData = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm.VerifyingDepositDataProperty, DependencyPropertyChanged_VerifyingDepositData);
                            tokenDPC_HerbariumSheet = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.VerifyDepositForm.HerbariumSheetProperty, DependencyPropertyChanged_HerbariumSheet);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Dialogs\VerifyDepositForm.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // Dialogs\VerifyDepositForm.xaml line 55
                {
                    this.cbxTaxonName = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbxTaxonName).SelectionChanged += this.cbxTaxonName_SelectionChanged;
                }
                break;
            case 4: // Dialogs\VerifyDepositForm.xaml line 59
                {
                    this.msgTaxonName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Dialogs\VerifyDepositForm.xaml line 61
                {
                    this.chkSameAccession = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 6: // Dialogs\VerifyDepositForm.xaml line 63
                {
                    this.cbxReferenceAccession = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // Dialogs\VerifyDepositForm.xaml line 65
                {
                    this.msgReferenceAccession = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Dialogs\VerifyDepositForm.xaml line 23
                {
                    this.picHerbariumSheet = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Dialogs\VerifyDepositForm.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)target;
                    VerifyDepositForm_obj1_Bindings bindings = new VerifyDepositForm_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

