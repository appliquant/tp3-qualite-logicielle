﻿#pragma checksum "..\..\..\..\Views\DashboardPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4EDC82487C409881A3FC6366114A82E64629BC76"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using _14E_TP2_A23.Views;


namespace _14E_TP2_A23.Views {
    
    
    /// <summary>
    /// DashboardPage
    /// </summary>
    public partial class DashboardPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbCurrentUser;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbCurrentUserRole;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddCustomer;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateCustomers;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateEmployees;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/14E_TP2_A23;V1.0.0.0;component/views/dashboardpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\DashboardPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbCurrentUser = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbCurrentUserRole = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnAddCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Views\DashboardPage.xaml"
            this.btnAddCustomer.Click += new System.Windows.RoutedEventHandler(this.btnAddCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUpdateCustomers = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Views\DashboardPage.xaml"
            this.btnUpdateCustomers.Click += new System.Windows.RoutedEventHandler(this.btnUpdateCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnUpdateEmployees = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Views\DashboardPage.xaml"
            this.btnUpdateEmployees.Click += new System.Windows.RoutedEventHandler(this.btnUpdateEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Views\DashboardPage.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

