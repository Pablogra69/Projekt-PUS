﻿#pragma checksum "..\..\Window_SelectionList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57BA5CCEF90C36AF6D459A8C996DB8E6A2117B14DF5F95376ECC2207867E053A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client_WPF_1._0;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Client_WPF_1._0 {
    
    
    /// <summary>
    /// Window_SelectionList
    /// </summary>
    public partial class Window_SelectionList : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 60 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddOrder;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_SelectOrder;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_DeleteOrder;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Back;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_NewOrder;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\Window_SelectionList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_OldOrder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client_WPF_1.0;component/window_selectionlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_SelectionList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Button_AddOrder = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\Window_SelectionList.xaml"
            this.Button_AddOrder.Click += new System.Windows.RoutedEventHandler(this.ButtonAddOrder_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_SelectOrder = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Window_SelectionList.xaml"
            this.Button_SelectOrder.Click += new System.Windows.RoutedEventHandler(this.Button_SelectOrder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Button_DeleteOrder = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\Window_SelectionList.xaml"
            this.Button_DeleteOrder.Click += new System.Windows.RoutedEventHandler(this.Button_DeleteOrder_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_Back = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\Window_SelectionList.xaml"
            this.Button_Back.Click += new System.Windows.RoutedEventHandler(this.Button_Back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListBox_NewOrder = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.ListBox_OldOrder = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 123 "..\..\Window_SelectionList.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CheckBox_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 155 "..\..\Window_SelectionList.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CheckBox_Click2);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

