﻿#pragma checksum "..\..\EntrenadorMainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D07C33FF52C01C21E1AF60E21284EEF99851C433"
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
    /// EntrenadorMainWindow
    /// </summary>
    public partial class EntrenadorMainWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\EntrenadorMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel jugadores;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\EntrenadorMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel equipo;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\EntrenadorMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Calendario;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\EntrenadorMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel tabla;
        
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
            System.Uri resourceLocater = new System.Uri("/League planner;component/entrenadormainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EntrenadorMainWindow.xaml"
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
            
            #line 17 "..\..\EntrenadorMainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.StackPanel_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.jugadores = ((System.Windows.Controls.StackPanel)(target));
            
            #line 36 "..\..\EntrenadorMainWindow.xaml"
            this.jugadores.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelMouseEnter);
            
            #line default
            #line hidden
            
            #line 36 "..\..\EntrenadorMainWindow.xaml"
            this.jugadores.MouseLeave += new System.Windows.Input.MouseEventHandler(this.PanelMouseLeave);
            
            #line default
            #line hidden
            
            #line 36 "..\..\EntrenadorMainWindow.xaml"
            this.jugadores.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.JugadoresMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.equipo = ((System.Windows.Controls.StackPanel)(target));
            
            #line 50 "..\..\EntrenadorMainWindow.xaml"
            this.equipo.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelMouseEnter);
            
            #line default
            #line hidden
            
            #line 50 "..\..\EntrenadorMainWindow.xaml"
            this.equipo.MouseLeave += new System.Windows.Input.MouseEventHandler(this.PanelMouseLeave);
            
            #line default
            #line hidden
            
            #line 50 "..\..\EntrenadorMainWindow.xaml"
            this.equipo.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.EquiposMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Calendario = ((System.Windows.Controls.StackPanel)(target));
            
            #line 58 "..\..\EntrenadorMainWindow.xaml"
            this.Calendario.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelMouseEnter);
            
            #line default
            #line hidden
            
            #line 58 "..\..\EntrenadorMainWindow.xaml"
            this.Calendario.MouseLeave += new System.Windows.Input.MouseEventHandler(this.PanelMouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tabla = ((System.Windows.Controls.StackPanel)(target));
            
            #line 67 "..\..\EntrenadorMainWindow.xaml"
            this.tabla.MouseEnter += new System.Windows.Input.MouseEventHandler(this.PanelMouseEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\EntrenadorMainWindow.xaml"
            this.tabla.MouseLeave += new System.Windows.Input.MouseEventHandler(this.PanelMouseLeave);
            
            #line default
            #line hidden
            
            #line 67 "..\..\EntrenadorMainWindow.xaml"
            this.tabla.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.tabla_MouseUp);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 88 "..\..\EntrenadorMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Salir);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 95 "..\..\EntrenadorMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CambiarUsuario);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

