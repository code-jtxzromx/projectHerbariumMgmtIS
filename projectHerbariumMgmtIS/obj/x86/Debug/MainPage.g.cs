﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B59A845FD0E1A9B03DE6E6823E8E2BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectHerbariumMgmtIS
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ContentControl_Content(global::Windows.UI.Xaml.Controls.ContentControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Content = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::projectHerbariumMgmtIS.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.NavigationViewItem obj6;

            private MainPage_obj1_BindingsTracking bindingsTracking;

            public MainPage_obj1_Bindings()
            {
                this.bindingsTracking = new MainPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 6: // MainPage.xaml line 153
                        this.obj6 = (global::Windows.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    default:
                        break;
                }
            }

            // IMainPage_Bindings

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
                    this.dataRoot = (global::projectHerbariumMgmtIS.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::projectHerbariumMgmtIS.MainPage obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_StaffName(obj.StaffName, phase);
                    }
                }
            }
            private void Update_StaffName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 153
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentControl_Content(this.obj6, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class MainPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<MainPage_obj1_Bindings> weakRefToBindingObj; 

                public MainPage_obj1_BindingsTracking(MainPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<MainPage_obj1_Bindings>(obj);
                }

                public MainPage_obj1_Bindings TryGetBindingObject()
                {
                    MainPage_obj1_Bindings bindingObject = null;
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

                public void DependencyPropertyChanged_StaffName(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::projectHerbariumMgmtIS.MainPage obj = sender as global::projectHerbariumMgmtIS.MainPage;
                        if (obj != null)
                        {
                            bindings.Update_StaffName(obj.StaffName, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_StaffName = 0;
                public void UpdateChildListeners_(global::projectHerbariumMgmtIS.MainPage obj)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::projectHerbariumMgmtIS.MainPage.StaffNameProperty, tokenDPC_StaffName);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_StaffName = obj.RegisterPropertyChangedCallback(global::projectHerbariumMgmtIS.MainPage.StaffNameProperty, DependencyPropertyChanged_StaffName);
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
            case 2: // MainPage.xaml line 25
                {
                    this.LoginScreen = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 92
                {
                    this.MainNavigation = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // MainPage.xaml line 106
                {
                    this.navMainMenu = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.navMainMenu).SelectionChanged += this.navMainMenu_SelectionChanged;
                }
                break;
            case 7: // MainPage.xaml line 156
                {
                    this.btnAbout = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnAbout).Click += this.btnAbout_Click;
                }
                break;
            case 8: // MainPage.xaml line 161
                {
                    this.btnLogout = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnLogout).Click += this.btnLogout_Click;
                }
                break;
            case 9: // MainPage.xaml line 169
                {
                    this.frmPageContent = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 10: // MainPage.xaml line 26
                {
                    this.flvBackgrounds = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 11: // MainPage.xaml line 74
                {
                    this.lblLoginError = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 12: // MainPage.xaml line 78
                {
                    this.txfUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // MainPage.xaml line 79
                {
                    this.txfPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 14: // MainPage.xaml line 86
                {
                    this.pgrLogin = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 15: // MainPage.xaml line 82
                {
                    this.btnLogin = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLogin).Click += this.btnLogin_Click;
                }
                break;
            case 16: // MainPage.xaml line 83
                {
                    this.btnClear = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnClear).Click += this.btnClear_Click;
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
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
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

