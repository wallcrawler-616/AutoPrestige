﻿#pragma checksum "..\..\..\Windows\ManagerTech.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EA39CA26D8FE284E35ED05095AF66F456D299C7A2F897A1A58529F8C0CE565F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoPrestigeArenda;
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


namespace AutoPrestigeArenda {
    
    
    /// <summary>
    /// ManagerTech
    /// </summary>
    public partial class ManagerTech : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TechPassList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InsertBT;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AutoID;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBT;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Windows\ManagerTech.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
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
            System.Uri resourceLocater = new System.Uri("/AutoPrestigeArenda;component/windows/managertech.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ManagerTech.xaml"
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
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.TechPassList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Windows\ManagerTech.xaml"
            this.TechPassList.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.DataGrid_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.InsertBT = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Windows\ManagerTech.xaml"
            this.InsertBT.Click += new System.Windows.RoutedEventHandler(this.InsertBT_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AutoID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\Windows\ManagerTech.xaml"
            this.AutoID.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AutoID_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.UpdateBT = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Windows\ManagerTech.xaml"
            this.UpdateBT.Click += new System.Windows.RoutedEventHandler(this.UpdateBT_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Windows\ManagerTech.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
