﻿#pragma checksum "..\..\FrmClient.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5942A33FFC4E16FA10A4CF4872A24B36"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CHAT_TCP_IP_APS;
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


namespace CHAT_TCP_IP_APS {
    
    
    /// <summary>
    /// FrmClient
    /// </summary>
    public partial class FrmClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox serverConsole;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMensagem;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnviar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvConnectedUsers;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\FrmClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock3;
        
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
            System.Uri resourceLocater = new System.Uri("/CHAT TCP-IP APS;component/frmclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FrmClient.xaml"
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
            
            #line 8 "..\..\FrmClient.xaml"
            ((CHAT_TCP_IP_APS.FrmClient)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\FrmClient.xaml"
            ((CHAT_TCP_IP_APS.FrmClient)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.serverConsole = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 3:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtMensagem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnEnviar = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\FrmClient.xaml"
            this.btnEnviar.Click += new System.Windows.RoutedEventHandler(this.btnEnviar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lvConnectedUsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            
            #line 74 "..\..\FrmClient.xaml"
            this.textBlock.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.textBlock_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.comboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 75 "..\..\FrmClient.xaml"
            this.comboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textBlock3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

