﻿#pragma checksum "..\..\..\Catalogos\ArbitroPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D5B55BB9D7D03E0C204E66A8F4BBFA491EC92D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using League_planner;
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


namespace League_planner {
    
    
    /// <summary>
    /// ArbitroPage
    /// </summary>
    public partial class ArbitroPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Toolbar;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nombre;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox paterno;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox materno;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker nacimiento;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox telefono;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Catalogos\ArbitroPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
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
            System.Uri resourceLocater = new System.Uri("/League planner;component/catalogos/arbitropage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Catalogos\ArbitroPage.xaml"
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
            this.Toolbar = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            
            #line 30 "..\..\..\Catalogos\ArbitroPage.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.StackPanel_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.paterno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.materno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.nacimiento = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.telefono = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\Catalogos\ArbitroPage.xaml"
            this.telefono.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.telefono_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 89 "..\..\..\Catalogos\ArbitroPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Aceptar);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 92 "..\..\..\Catalogos\ArbitroPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancelar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
