﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Dialogs\SpeciesAuthorForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E60A064A8FA34CA23E5664023BA4A42D"
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
    partial class SpeciesAuthorForm : 
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
        private class SpeciesAuthorForm_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ISpeciesAuthorForm_Bindings
        {
            private global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm dataRoot;
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

            private SpeciesAuthorForm_obj1_BindingsTracking bindingsTracking;

            public SpeciesAuthorForm_obj1_Bindings()
            {
                this.bindingsTracking = new SpeciesAuthorForm_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 10 && columnNumber == 5)
                {
                    isobj1TitleDisabled = true;
                }
                else if (lineNumber == 66 && columnNumber == 18)
                {
                    isobj3TextDisabled = true;
                }
                else if (lineNumber == 70 && columnNumber == 18)
                {
                    isobj4TextDisabled = true;
                }
                else if (lineNumber == 73 && columnNumber == 18)
                {
                    isobj5TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 1: // Dialogs\SpeciesAuthorForm.xaml line 1
                        this.obj1 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.ContentDialog)target);
                        break;
                    case 3: // Dialogs\SpeciesAuthorForm.xaml line 65
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Dialogs\SpeciesAuthorForm.xaml line 69
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    case 5: // Dialogs\SpeciesAuthorForm.xaml line 72
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

            // ISpeciesAuthorForm_Bindings

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
                    this.dataRoot = (global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_TransactionForm(obj.TransactionForm, phase);
                        this.Update_AuthorData(obj.AuthorData, phase);
                    }
                }
            }
            private void Update_TransactionForm(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\SpeciesAuthorForm.xaml line 1
                    if (!isobj1TitleDisabled)
                    {
                        if ((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog) != null)
                        {
                            XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentDialog_Title((this.obj1.Target as global::Windows.UI.Xaml.Controls.ContentDialog), obj, null);
                        }
                    }
                }
            }
            private void Update_AuthorData(global::projectHerbariumMgmtIS.Model.SpeciesAuthor obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_AuthorData_AuthorID(obj.AuthorID, phase);
                        this.Update_AuthorData_AuthorName(obj.AuthorName, phase);
                        this.Update_AuthorData_AuthorSuffix(obj.AuthorSuffix, phase);
                    }
                }
            }
            private void Update_AuthorData_AuthorID(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\SpeciesAuthorForm.xaml line 65
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj.ToString(), null);
                    }
                }
            }
            private void Update_AuthorData_AuthorName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\SpeciesAuthorForm.xaml line 69
                    if (!isobj4TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, obj, null);
                    }
                }
            }
            private void Update_AuthorData_AuthorSuffix(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Dialogs\SpeciesAuthorForm.xaml line 72
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
                        if (this.dataRoot.AuthorData != null)
                        {
                            this.dataRoot.AuthorData.AuthorID = (global::System.Int32) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Int32), this.obj3.Text);
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
                        if (this.dataRoot.AuthorData != null)
                        {
                            this.dataRoot.AuthorData.AuthorName = this.obj4.Text;
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
                        if (this.dataRoot.AuthorData != null)
                        {
                            this.dataRoot.AuthorData.AuthorSuffix = this.obj5.Text;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class SpeciesAuthorForm_obj1_BindingsTracking
            {
                private global::System.WeakReference<SpeciesAuthorForm_obj1_Bindings> weakRefToBindingObj; 

                public SpeciesAuthorForm_obj1_BindingsTracking(SpeciesAuthorForm_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<SpeciesAuthorForm_obj1_Bindings>(obj);
                }

                public SpeciesAuthorForm_obj1_Bindings TryGetBindingObject()
                {
                    SpeciesAuthorForm_obj1_Bindings bindingObject = null;
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
                    SpeciesAuthorForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm;
                        if (obj != null)
                        {
                            bindings.Update_TransactionForm(obj.TransactionForm, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_AuthorData(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    SpeciesAuthorForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm obj = sender as global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm;
                        if (obj != null)
                        {
                            bindings.Update_AuthorData(obj.AuthorData, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_TransactionForm = 0;
                private long tokenDPC_AuthorData = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm obj)
                {
                    SpeciesAuthorForm_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm.TransactionFormProperty, tokenDPC_TransactionForm);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm.AuthorDataProperty, tokenDPC_AuthorData);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_TransactionForm = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm.TransactionFormProperty, DependencyPropertyChanged_TransactionForm);
                            tokenDPC_AuthorData = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.Dialogs.SpeciesAuthorForm.AuthorDataProperty, DependencyPropertyChanged_AuthorData);
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
            case 1: // Dialogs\SpeciesAuthorForm.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 3: // Dialogs\SpeciesAuthorForm.xaml line 65
                {
                    this.txfAuthorID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Dialogs\SpeciesAuthorForm.xaml line 69
                {
                    this.txfAuthorsName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Dialogs\SpeciesAuthorForm.xaml line 72
                {
                    this.txfAuthorsSuffix = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Dialogs\SpeciesAuthorForm.xaml line 75
                {
                    this.msgAuthorsName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Dialogs\SpeciesAuthorForm.xaml line 77
                {
                    this.msgAuthorsSuffix = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // Dialogs\SpeciesAuthorForm.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)target;
                    SpeciesAuthorForm_obj1_Bindings bindings = new SpeciesAuthorForm_obj1_Bindings();
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

