﻿#pragma checksum "..\..\..\..\Views\ShellView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "33BBF2AB4D4C79785053FB5EA7635602"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hayman.Client.Infrastructure.Regions;
using Hayman.Client.Presentation.Windows;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Shell.Controls;
using Hayman.Shell.ViewModels;
using Microsoft.Practices.Composite.Presentation.Regions;
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


namespace Hayman.Shell.Views {
    
    
    /// <summary>
    /// ShellView
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ShellView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WindowHeader;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WindowTitle;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserName;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hayman.Shell.Controls.SplitButton ShutdownOptionsButton;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShutdownMenuItem;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hayman.Shell.Controls.SplitButton ShowSplitButton;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShowNavigationPanelMenuItem;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShowCalendarMenuItem;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShowClockMenuItem;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AboutBoxMenuItem;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_MinimizeButton;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_MaximizeButton;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_CloseButton;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ActiveWindowZone;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ActiveWindowList;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\..\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hayman.Client.Presentation.Windows.Controls.Desktop ModalContainer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Hayman.Shell;component/views/shellview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ShellView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.WindowHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.WindowTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.UserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ShutdownOptionsButton = ((Hayman.Shell.Controls.SplitButton)(target));
            return;
            case 6:
            this.ShutdownMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 7:
            this.ShowSplitButton = ((Hayman.Shell.Controls.SplitButton)(target));
            return;
            case 8:
            this.ShowNavigationPanelMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 9:
            this.ShowCalendarMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 10:
            this.ShowClockMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 11:
            this.AboutBoxMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 12:
            this.PART_MinimizeButton = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.PART_MaximizeButton = ((System.Windows.Controls.Button)(target));
            return;
            case 14:
            this.PART_CloseButton = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.ActiveWindowZone = ((System.Windows.Controls.Grid)(target));
            return;
            case 16:
            this.ActiveWindowList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 17:
            this.ModalContainer = ((Hayman.Client.Presentation.Windows.Controls.Desktop)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

