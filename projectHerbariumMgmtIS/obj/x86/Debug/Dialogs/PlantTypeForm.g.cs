﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Dialogs\PlantTypeForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A003BF7333173159DADB241BEA510CF0"
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
    partial class PlantTypeForm : 
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
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class PlantTypeForm_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPlantTypeForm_Bindings
        {
            private global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::System.WeakReference obj1;
            private global::Windows.UI.Xaml.Controls.TextBox obj3;
            private global::Windows.UI.Xaml.Controls.TextBox obj4;
            private global::Windows.UI.Xaml.Controls.TextBox obj5;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj1TitleDisabled = false;
            private static bool isobj3TextDisabled = false;
            private static bool isobj4TextDisabled = false;
            private static bool isobj5TextDisabled = false;

            private PlantTypeForm_obj1_BindingsTracking bindingsTracking;

            public PlantTypeForm_obj1_Bindings()
            {
                this.bindingsTracking = new PlantTypeForm_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 10 && columnNumber == 5)
                {
                    isobj1TitleDisabled = true;
                }
                else if (lineNumber == 68 && columnNumber == 18)
                {
                    isobj3TextDisabled = true;
                }
                else if (lineNumber == 72 && columnNumber == 18)
                {
                    isobj4TextDisabled = true;
                }
                else if (lineNumber == 75 && columnNumber == 18)
                {
                    isobj5TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 1: // Dialogs\PlantTypeForm.xaml line 1
                        this.obj1 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.ContentDialog)target);
                        break;
                    case 3: // Dialogs\PlantTypeForm.xaml line 67
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Dialogs\PlantTypeForm.xaml line 71
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    case 5: // Dialogs\PlantTypeForm.xaml line 74
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_5(this.obj5);
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // IPlantTypeForm_Bindings

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
                    this.dataRoot = (global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_TransactionForm(obj.TransactionForm, phase);
                        this.Update_PlantTypeData(obj.PlantTypeData, phase);
                    }
                }
            }
            private void Update_TransactionForm(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\PlantTypeForm.xaml line 1
                    if (!isobj1TitleDisabled)
                    {
                        if ((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog) != null)
                        {
                            XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentDialog_Title((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog), obj, null);
                        }
                    }
                }
            }
            private void Update_PlantTypeData(global::projectHerbariumMgmtIS.Model.PlantType obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_PlantTypeData_PlantTypeID(obj.PlantTypeID, phase);
                        this.Update_PlantTypeData_Code(obj.Code, phase);
                        this.Update_PlantTypeData_Type(obj.Type, phase);
                    }
                }
            }
            private void Update_PlantTypeData_PlantTypeID(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\PlantTypeForm.xaml line 67
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj.ToString(), null);
                    }
                }
            }
            private void Update_PlantTypeData_Code(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\PlantTypeForm.xaml line 71
                    if (!isobj4TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, obj, null);
                    }
                }
            }
            private void Update_PlantTypeData_Type(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\PlantTypeForm.xaml line 74
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj5, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.PlantTypeData != null)
                        {
                            this.dataRoot.PlantTypeData.PlantTypeID = (global::System.Int32) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Int32), this.obj3.Text);
                        }
                    }
                }
            }
            private void UpdateTwoWay_4_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.PlantTypeData != null)
                        {
                            this.dataRoot.PlantTypeData.Code = this.obj4.Text;
                        }
                    }
                }
            }
            private void UpdateTwoWay_5_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.PlantTypeData != null)
                        {
                            this.dataRoot.PlantTypeData.Type = this.obj5.Text;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class PlantTypeForm_obj1_BindingsTracking
            {
                private global::System.WeakReference<PlantTypeForm_obj1_Bindings> weakRefToBindingObj; 

                public PlantTypeForm_obj1_BindingsTracking(PlantTypeForm_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<PlantTypeForm_obj1_Bindings>(obj);
                }

                public PlantTypeForm_obj1_Bindings TryGetBindingObject()
                {
                    PlantTypeForm_obj1_Bindings bindingObject = null;
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
                    PlantTypeForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm;
                        if (obj != null)
                        {
                            bindings.Update_TransactionForm(obj.TransactionForm, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_PlantTypeData(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    PlantTypeForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm;
                        if (obj != null)
                        {
                            bindings.Update_PlantTypeData(obj.PlantTypeData, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_TransactionForm = 0;
                private long tokenDPC_PlantTypeData = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm obj)
                {
                    PlantTypeForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm.TransactionFormProperty, tokenDPC_TransactionForm);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm.PlantTypeDataProperty, tokenDPC_PlantTypeData);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_TransactionForm = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm.TransactionFormProperty, DependencyPropertyChanged_TransactionForm);
                            tokenDPC_PlantTypeData = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.PlantTypeForm.PlantTypeDataProperty, DependencyPropertyChanged_PlantTypeData);
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
                public void RegisterTwoWayListener_4(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_4_Text();
                        }
                    };
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
            case 1: // Dialogs\PlantTypeForm.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 3: // Dialogs\PlantTypeForm.xaml line 67
                {
                    this.txfPlantTypeID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Dialogs\PlantTypeForm.xaml line 71
                {
                    this.txfPlantCode = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Dialogs\PlantTypeForm.xaml line 74
                {
                    this.txfPlantType = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Dialogs\PlantTypeForm.xaml line 77
                {
                    this.msgPlantCode = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Dialogs\PlantTypeForm.xaml line 79
                {
                    this.msgPlantType = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // Dialogs\PlantTypeForm.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)target;
                    PlantTypeForm_obj1_Bindings bindings = new PlantTypeForm_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

