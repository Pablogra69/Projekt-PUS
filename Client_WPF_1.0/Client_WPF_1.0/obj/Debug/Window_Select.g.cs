﻿#pragma checksum "..\..\Window_Select.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F774C2FA5D62AF40F6B3DC47CF8C6CDC226DEA172EDBC95604B8FE9F7FF2D7B"
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
    /// Window_Select
    /// </summary>
    public partial class Window_Select : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 66 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridSQL;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Back;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Shearch;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Empty;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Picture;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLocation_1;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Catalog;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\Window_Select.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ean;
        
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
            System.Uri resourceLocater = new System.Uri("/Client_WPF_1.0;component/window_select.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Select.xaml"
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
            this.DataGridSQL = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Button_Back = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\Window_Select.xaml"
            this.Button_Back.Click += new System.Windows.RoutedEventHandler(this.Button_back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_Shearch = ((System.Windows.Controls.Button)(target));
            
            #line 157 "..\..\Window_Select.xaml"
            this.Button_Shearch.Click += new System.Windows.RoutedEventHandler(this.Button_Shearch_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_Empty = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\Window_Select.xaml"
            this.button_Empty.Click += new System.Windows.RoutedEventHandler(this.Button_Empty_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_Picture = ((System.Windows.Controls.Button)(target));
            
            #line 186 "..\..\Window_Select.xaml"
            this.button_Picture.Click += new System.Windows.RoutedEventHandler(this.button_Picture_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxLocation_1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 195 "..\..\Window_Select.xaml"
            this.textBoxLocation_1.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_Catalog_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TextBox_Catalog = ((System.Windows.Controls.TextBox)(target));
            
            #line 218 "..\..\Window_Select.xaml"
            this.TextBox_Catalog.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_Catalog_KeyDown);
            
            #line default
            #line hidden
            
            #line 218 "..\..\Window_Select.xaml"
            this.TextBox_Catalog.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_Catalog_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Ean = ((System.Windows.Controls.TextBox)(target));
            
            #line 228 "..\..\Window_Select.xaml"
            this.Ean.KeyDown += new System.Windows.Input.KeyEventHandler(this.Ean_KeyDown);
            
            #line default
            #line hidden
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
            case 2:
            
            #line 99 "..\..\Window_Select.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CheckBox_Grid_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 109 "..\..\Window_Select.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_JPG_MouseDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
