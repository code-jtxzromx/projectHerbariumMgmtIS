﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Maintenance\BorrowerPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB4F5CC59BBFFE9911031DAD2019483F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectHerbariumMgmtIS.Maintenance
{
    partial class BorrowerPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Maintenance\BorrowerPage.xaml line 32
                {
                    this.dgrBorrowerTable = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 3: // Maintenance\BorrowerPage.xaml line 27
                {
                    this.btnAddBorrower = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnAddBorrower).Click += this.btnAddBorrower_Click;
                }
                break;
            case 4: // Maintenance\BorrowerPage.xaml line 28
                {
                    this.btnEditBorrower = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnEditBorrower).Click += this.btnEditBorrower_Click;
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
            return returnValue;
        }
    }
}
