﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Transaction\DepositTransactionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CF63BA36C1A15048F9FD3B9372109694"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectHerbariumMgmtIS.Transaction
{
    partial class DepositTransactionPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_DatePicker_Date(global::Windows.UI.Xaml.Controls.DatePicker obj, global::System.DateTimeOffset value)
            {
                obj.Date = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class DepositTransactionPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IDepositTransactionPage_Bindings
        {
            private global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ToggleSwitch obj7;
            private global::Windows.UI.Xaml.Controls.ComboBox obj8;
            private global::Windows.UI.Xaml.Controls.ComboBox obj10;
            private global::Windows.UI.Xaml.Controls.TextBox obj12;
            private global::Windows.UI.Xaml.Controls.ComboBox obj14;
            private global::Windows.UI.Xaml.Controls.ComboBox obj17;
            private global::Windows.UI.Xaml.Controls.ComboBox obj19;
            private global::Windows.UI.Xaml.Controls.DatePicker obj21;
            private global::Windows.UI.Xaml.Controls.DatePicker obj22;
            private global::Windows.UI.Xaml.Controls.DatePicker obj23;
            private global::Windows.UI.Xaml.Controls.ComboBox obj24;
            private global::Windows.UI.Xaml.Controls.TextBox obj26;

            private DepositTransactionPage_obj1_BindingsTracking bindingsTracking;

            public DepositTransactionPage_obj1_Bindings()
            {
                this.bindingsTracking = new DepositTransactionPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // Transaction\DepositTransactionPage.xaml line 60
                        this.obj7 = (global::Windows.UI.Xaml.Controls.ToggleSwitch)target;
                        break;
                    case 8: // Transaction\DepositTransactionPage.xaml line 63
                        this.obj8 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_8(this.obj8);
                        break;
                    case 10: // Transaction\DepositTransactionPage.xaml line 68
                        this.obj10 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_10(this.obj10);
                        break;
                    case 12: // Transaction\DepositTransactionPage.xaml line 75
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_12(this.obj12);
                        break;
                    case 14: // Transaction\DepositTransactionPage.xaml line 82
                        this.obj14 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_14(this.obj14);
                        break;
                    case 17: // Transaction\DepositTransactionPage.xaml line 92
                        this.obj17 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_17(this.obj17);
                        break;
                    case 19: // Transaction\DepositTransactionPage.xaml line 97
                        this.obj19 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_19(this.obj19);
                        break;
                    case 21: // Transaction\DepositTransactionPage.xaml line 103
                        this.obj21 = (global::Windows.UI.Xaml.Controls.DatePicker)target;
                        this.bindingsTracking.RegisterTwoWayListener_21(this.obj21);
                        break;
                    case 22: // Transaction\DepositTransactionPage.xaml line 107
                        this.obj22 = (global::Windows.UI.Xaml.Controls.DatePicker)target;
                        this.bindingsTracking.RegisterTwoWayListener_22(this.obj22);
                        break;
                    case 23: // Transaction\DepositTransactionPage.xaml line 112
                        this.obj23 = (global::Windows.UI.Xaml.Controls.DatePicker)target;
                        this.bindingsTracking.RegisterTwoWayListener_23(this.obj23);
                        break;
                    case 24: // Transaction\DepositTransactionPage.xaml line 117
                        this.obj24 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_24(this.obj24);
                        break;
                    case 26: // Transaction\DepositTransactionPage.xaml line 122
                        this.obj26 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_26(this.obj26);
                        break;
                    default:
                        break;
                }
            }

            // IDepositTransactionPage_Bindings

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
                    this.dataRoot = (global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_IsExisting(obj.IsExisting, phase);
                        this.Update_NewDepositData(obj.NewDepositData, phase);
                    }
                }
            }
            private void Update_IsExisting(global::System.Boolean obj, int phase)
            {
                if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                {
                    this.Update_IsExisting_Cast_IsExisting_To_Visibility(obj ? global::Windows.UI.Xaml.Visibility.Visible : global::Windows.UI.Xaml.Visibility.Collapsed, phase);
                }
            }
            private void Update_IsExisting_Cast_IsExisting_To_Visibility(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 60
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, obj);
                    // Transaction\DepositTransactionPage.xaml line 75
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj12, obj);
                }
            }
            private void Update_NewDepositData(global::projectHerbariumMgmtIS.Model.PlantDeposit obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_NewDepositData_PlantType(obj.PlantType, phase);
                        this.Update_NewDepositData_TaxonName(obj.TaxonName, phase);
                        this.Update_NewDepositData_DepositNumber(obj.DepositNumber, phase);
                        this.Update_NewDepositData_NewAccesion(obj.NewAccesion, phase);
                        this.Update_NewDepositData_Collector(obj.Collector, phase);
                        this.Update_NewDepositData_Validator(obj.Validator, phase);
                        this.Update_NewDepositData_DateCollected(obj.DateCollected, phase);
                        this.Update_NewDepositData_DateDeposited(obj.DateDeposited, phase);
                        this.Update_NewDepositData_DateVerified(obj.DateVerified, phase);
                        this.Update_NewDepositData_Locality(obj.Locality, phase);
                        this.Update_NewDepositData_Description(obj.Description, phase);
                    }
                }
            }
            private void Update_NewDepositData_PlantType(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 63
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj8, obj, null);
                }
            }
            private void Update_NewDepositData_TaxonName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 68
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj10, obj, null);
                }
            }
            private void Update_NewDepositData_DepositNumber(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 75
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj12, obj, null);
                }
            }
            private void Update_NewDepositData_NewAccesion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 82
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj14, obj, null);
                }
            }
            private void Update_NewDepositData_Collector(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 92
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj17, obj, null);
                }
            }
            private void Update_NewDepositData_Validator(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 97
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj19, obj, null);
                }
            }
            private void Update_NewDepositData_DateCollected(global::System.DateTimeOffset obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 103
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_DatePicker_Date(this.obj21, obj);
                }
            }
            private void Update_NewDepositData_DateDeposited(global::System.DateTimeOffset obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 107
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_DatePicker_Date(this.obj22, obj);
                }
            }
            private void Update_NewDepositData_DateVerified(global::System.DateTimeOffset obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 112
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_DatePicker_Date(this.obj23, obj);
                }
            }
            private void Update_NewDepositData_Locality(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 117
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj24, obj, null);
                }
            }
            private void Update_NewDepositData_Description(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Transaction\DepositTransactionPage.xaml line 122
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj26, obj, null);
                }
            }
            private void UpdateTwoWay_8_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.PlantType = (global::System.String)this.obj8.SelectedItem;
                }
            }
            private void UpdateTwoWay_10_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.TaxonName = (global::System.String)this.obj10.SelectedItem;
                }
            }
            private void UpdateTwoWay_12_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.DepositNumber = this.obj12.Text;
                }
            }
            private void UpdateTwoWay_14_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.NewAccesion = (global::System.String)this.obj14.SelectedItem;
                }
            }
            private void UpdateTwoWay_17_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.Collector = (global::System.String)this.obj17.SelectedItem;
                }
            }
            private void UpdateTwoWay_19_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.Validator = (global::System.String)this.obj19.SelectedItem;
                }
            }
            private void UpdateTwoWay_21_Date()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.DateCollected = this.obj21.Date;
                }
            }
            private void UpdateTwoWay_22_Date()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.DateDeposited = this.obj22.Date;
                }
            }
            private void UpdateTwoWay_23_Date()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.DateVerified = this.obj23.Date;
                }
            }
            private void UpdateTwoWay_24_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.Locality = (global::System.String)this.obj24.SelectedItem;
                }
            }
            private void UpdateTwoWay_26_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.NewDepositData.Description = this.obj26.Text;
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class DepositTransactionPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<DepositTransactionPage_obj1_Bindings> weakRefToBindingObj; 

                public DepositTransactionPage_obj1_BindingsTracking(DepositTransactionPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<DepositTransactionPage_obj1_Bindings>(obj);
                }

                public DepositTransactionPage_obj1_Bindings TryGetBindingObject()
                {
                    DepositTransactionPage_obj1_Bindings bindingObject = null;
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

                public void DependencyPropertyChanged_IsExisting(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    DepositTransactionPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage obj = sender as global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage;
                        if (obj != null)
                        {
                            bindings.Update_IsExisting(obj.IsExisting, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_NewDepositData(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    DepositTransactionPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage obj = sender as global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage;
                        if (obj != null)
                        {
                            bindings.Update_NewDepositData(obj.NewDepositData, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_IsExisting = 0;
                private long tokenDPC_NewDepositData = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage obj)
                {
                    DepositTransactionPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage.IsExistingProperty, tokenDPC_IsExisting);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage.NewDepositDataProperty, tokenDPC_NewDepositData);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_IsExisting = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage.IsExistingProperty, DependencyPropertyChanged_IsExisting);
                            tokenDPC_NewDepositData = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Transaction.DepositTransactionPage.NewDepositDataProperty, DependencyPropertyChanged_NewDepositData);
                        }
                    }
                }
                public void RegisterTwoWayListener_8(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_8_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_10(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_10_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_12(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_12_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_14(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_14_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_17(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_17_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_19(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_19_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_21(global::Windows.UI.Xaml.Controls.DatePicker sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.DatePicker.DateProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_21_Date();
                        }
                    });
                }
                public void RegisterTwoWayListener_22(global::Windows.UI.Xaml.Controls.DatePicker sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.DatePicker.DateProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_22_Date();
                        }
                    });
                }
                public void RegisterTwoWayListener_23(global::Windows.UI.Xaml.Controls.DatePicker sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.DatePicker.DateProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_23_Date();
                        }
                    });
                }
                public void RegisterTwoWayListener_24(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_24_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_26(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_26_Text();
                        }
                    });
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
            case 2: // Transaction\DepositTransactionPage.xaml line 11
                {
                    this.pnlDepositRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Transaction\DepositTransactionPage.xaml line 13
                {
                    this.PicturePane = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 4: // Transaction\DepositTransactionPage.xaml line 14
                {
                    this.DetailPane = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 5: // Transaction\DepositTransactionPage.xaml line 132
                {
                    this.btnSave = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSave).Click += this.btnSave_Click;
                }
                break;
            case 6: // Transaction\DepositTransactionPage.xaml line 134
                {
                    this.btnClear = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnClear).Click += this.btnClear_Click;
                }
                break;
            case 7: // Transaction\DepositTransactionPage.xaml line 60
                {
                    this.btnIsVerifiedDeposit = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 8: // Transaction\DepositTransactionPage.xaml line 63
                {
                    this.cbxPlantType = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 9: // Transaction\DepositTransactionPage.xaml line 66
                {
                    this.msgPlantType = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Transaction\DepositTransactionPage.xaml line 68
                {
                    this.cbxScientificName = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbxScientificName).SelectionChanged += this.cbxScientificName_SelectionChanged;
                }
                break;
            case 11: // Transaction\DepositTransactionPage.xaml line 73
                {
                    this.msgScientifcName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Transaction\DepositTransactionPage.xaml line 75
                {
                    this.txfOrgAccessionNo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txfOrgAccessionNo).LostFocus += this.txfOrgAccessionNo_LostFocus;
                }
                break;
            case 13: // Transaction\DepositTransactionPage.xaml line 80
                {
                    this.msgOrgAccessionNo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Transaction\DepositTransactionPage.xaml line 82
                {
                    this.cbxNewAccessionNo = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 15: // Transaction\DepositTransactionPage.xaml line 87
                {
                    this.msgNewAccessionNo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Transaction\DepositTransactionPage.xaml line 89
                {
                    this.chkSameAccession = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 17: // Transaction\DepositTransactionPage.xaml line 92
                {
                    this.cbxCollector = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 18: // Transaction\DepositTransactionPage.xaml line 95
                {
                    this.msgCollector = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // Transaction\DepositTransactionPage.xaml line 97
                {
                    this.cbxValidator = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 20: // Transaction\DepositTransactionPage.xaml line 101
                {
                    this.msgValidator = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21: // Transaction\DepositTransactionPage.xaml line 103
                {
                    this.dpkDateCollected = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.dpkDateCollected).DateChanged += this.dpkDateCollected_DateChanged;
                }
                break;
            case 22: // Transaction\DepositTransactionPage.xaml line 107
                {
                    this.dpkDateDeposited = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.dpkDateDeposited).DateChanged += this.dpkDateDeposited_DateChanged;
                }
                break;
            case 23: // Transaction\DepositTransactionPage.xaml line 112
                {
                    this.dpkDateVerified = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.dpkDateVerified).DateChanged += this.dpkDateVerified_DateChanged;
                }
                break;
            case 24: // Transaction\DepositTransactionPage.xaml line 117
                {
                    this.cbxLocality = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 25: // Transaction\DepositTransactionPage.xaml line 120
                {
                    this.msgLocality = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // Transaction\DepositTransactionPage.xaml line 122
                {
                    this.txfDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 27: // Transaction\DepositTransactionPage.xaml line 125
                {
                    this.msgDescription = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // Transaction\DepositTransactionPage.xaml line 127
                {
                    this.chkIsGoodCondition = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 29: // Transaction\DepositTransactionPage.xaml line 21
                {
                    this.btnUploadPhoto = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUploadPhoto).Click += this.btnUploadPhoto_Click;
                }
                break;
            case 30: // Transaction\DepositTransactionPage.xaml line 22
                {
                    this.btnCapturePhoto = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCapturePhoto).Click += this.btnCapturePhoto_Click;
                }
                break;
            case 31: // Transaction\DepositTransactionPage.xaml line 19
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
            case 1: // Transaction\DepositTransactionPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    DepositTransactionPage_obj1_Bindings bindings = new DepositTransactionPage_obj1_Bindings();
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

