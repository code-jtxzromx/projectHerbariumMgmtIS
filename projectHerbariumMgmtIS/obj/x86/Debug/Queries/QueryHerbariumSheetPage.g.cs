﻿#pragma checksum "C:\Users\Jtxzromx Casingal\Documents\Visual Studio 2017\Projects\projectHerbariumMgmtIS\projectHerbariumMgmtIS\Queries\QueryHerbariumSheetPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CAB9568A9DDC664FBA2967B5600F8F17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectHerbariumMgmtIS.Queries
{
    partial class QueryHerbariumSheetPage : 
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
            case 4: // Queries\QueryHerbariumSheetPage.xaml line 91
                {
                    this.cbxCategory = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbxCategory).SelectionChanged += this.cbxCategory_SelectionChanged;
                }
                break;
            case 5: // Queries\QueryHerbariumSheetPage.xaml line 113
                {
                    this.dgrSheetsTable = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 6: // Queries\QueryHerbariumSheetPage.xaml line 121
                {
                    this.btnResetTable = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnResetTable).Click += this.btnResetTable_Click;
                }
                break;
            case 7: // Queries\QueryHerbariumSheetPage.xaml line 105
                {
                    this.txfSearch = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txfSearch).TextChanged += this.txfSearch_TextChanged;
                }
                break;
            case 8: // Queries\QueryHerbariumSheetPage.xaml line 99
                {
                    this.lstCategoryResult = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 9: // Queries\QueryHerbariumSheetPage.xaml line 100
                {
                    this.btnLoadTable = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLoadTable).Click += this.btnLoadTable_Click;
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

