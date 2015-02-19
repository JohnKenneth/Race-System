﻿#pragma checksum "..\..\AddDriverToEventForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "260B55917ED828B99215F8403870DEEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace RaceSystem {
    
    
    /// <summary>
    /// AddDriverToEventForm
    /// </summary>
    public partial class AddDriverToEventForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView driverList;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox driverName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox teamId;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vehicleModel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox rfidComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddDriverToEventForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
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
            System.Uri resourceLocater = new System.Uri("/RaceSystem;component/adddrivertoeventform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddDriverToEventForm.xaml"
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
            this.driverList = ((System.Windows.Controls.ListView)(target));
            
            #line 6 "..\..\AddDriverToEventForm.xaml"
            this.driverList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.onDriverSelected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.driverName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.teamId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.vehicleModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.rfidComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\AddDriverToEventForm.xaml"
            this.rfidComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.rfidComboBoxSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\AddDriverToEventForm.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.onAddClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\AddDriverToEventForm.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.onCancelClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\AddDriverToEventForm.xaml"
            this.txtFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter_Changed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
