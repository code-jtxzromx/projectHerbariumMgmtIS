﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Dialogs\GenusForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4FA009FD645F22D97AB85CBA1A262C16"
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
    partial class GenusForm : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ContentDialog_Title(global::Windows.UI.Xaml.Controls.ContentDialog obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Title = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GenusForm_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGenusForm_Bindings
        {
            private global::projectHerbariumMgmtIS.Dialogs.GenusForm dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::System.WeakReference obj1;
            private global::Windows.UI.Xaml.Controls.TextBox obj3;
            private global::Windows.UI.Xaml.Controls.ComboBox obj4;
            private global::Windows.UI.Xaml.Controls.TextBox obj5;

            private GenusForm_obj1_BindingsTracking bindingsTracking;

            public GenusForm_obj1_Bindings()
            {
                this.bindingsTracking = new GenusForm_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 1: // Dialogs\GenusForm.xaml line 1
                        this.obj1 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.ContentDialog)target);
                        break;
                    case 3: // Dialogs\GenusForm.xaml line 34
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Dialogs\GenusForm.xaml line 38
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    case 5: // Dialogs\GenusForm.xaml line 41
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_5(this.obj5);
                        break;
                    default:
                        break;
                }
            }

            // IGenusForm_Bindings

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
                    this.dataRoot = (global::projectHerbariumMgmtIS.Dialogs.GenusForm)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.Dialogs.GenusForm obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_TransactionForm(obj.TransactionForm, phase);
                        this.Update_GenusData(obj.GenusData, phase);
                    }
                }
            }
            private void Update_TransactionForm(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\GenusForm.xaml line 1
                    if ((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog) != null)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentDialog_Title((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog), obj, null);
                    }
                }
            }
            private void Update_GenusData(global::projectHerbariumMgmtIS.Model.TaxonGenus obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_GenusData_GenusID(obj.GenusID, phase);
                        this.Update_GenusData_FamilyName(obj.FamilyName, phase);
                        this.Update_GenusData_GenusName(obj.GenusName, phase);
                    }
                }
            }
            private void Update_GenusData_GenusID(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\GenusForm.xaml line 34
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj, null);
                }
            }
            private void Update_GenusData_FamilyName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\GenusForm.xaml line 38
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj4, obj, null);
                }
            }
            private void Update_GenusData_GenusName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\GenusForm.xaml line 41
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj5, obj, null);
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.GenusData.GenusID = this.obj3.Text;
                }
            }
            private void UpdateTwoWay_4_SelectedItem()
            {
                if (this.initialized)
                {
                    this.dataRoot.GenusData.FamilyName = (global::System.String)this.obj4.SelectedItem;
                }
            }
            private void UpdateTwoWay_5_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.GenusData.GenusName = this.obj5.Text;
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class GenusForm_obj1_BindingsTracking
            {
                private global::System.WeakReference<GenusForm_obj1_Bindings> weakRefToBindingObj; 

                public GenusForm_obj1_BindingsTracking(GenusForm_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<GenusForm_obj1_Bindings>(obj);
                }

                public GenusForm_obj1_Bindings TryGetBindingObject()
                {
                    GenusForm_obj1_Bindings bindingObject = null;
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

                public void DependencyPropertyChanged_TransactionForm(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    GenusForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.GenusForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.GenusForm;
                        if (obj != null)
                        {
                            bindings.Update_TransactionForm(obj.TransactionForm, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_GenusData(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    GenusForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.GenusForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.GenusForm;
                        if (obj != null)
                        {
                            bindings.Update_GenusData(obj.GenusData, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_TransactionForm = 0;
                private long tokenDPC_GenusData = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.Dialogs.GenusForm obj)
                {
                    GenusForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.GenusForm.TransactionFormProperty, tokenDPC_TransactionForm);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.GenusForm.GenusDataProperty, tokenDPC_GenusData);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_TransactionForm = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.GenusForm.TransactionFormProperty, DependencyPropertyChanged_TransactionForm);
                            tokenDPC_GenusData = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.GenusForm.GenusDataProperty, DependencyPropertyChanged_GenusData);
                        }
                    }
                }
                public void RegisterTwoWayListener_3(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_4(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_4_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_5(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_5_Text();
                        }
                    };
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
            case 1: // Dialogs\GenusForm.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 3: // Dialogs\GenusForm.xaml line 34
                {
                    this.txfGenusID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Dialogs\GenusForm.xaml line 38
                {
                    this.cbxFamilyName = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // Dialogs\GenusForm.xaml line 41
                {
                    this.txfGenusName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Dialogs\GenusForm.xaml line 44
                {
                    this.msgFamilyName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Dialogs\GenusForm.xaml line 46
                {
                    this.msgGenusName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // Dialogs\GenusForm.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)target;
                    GenusForm_obj1_Bindings bindings = new GenusForm_obj1_Bindings();
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

