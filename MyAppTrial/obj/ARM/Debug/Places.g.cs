﻿

#pragma checksum "C:\Users\Thilini\Desktop\MyAppTrial\MyAppTrial\Places.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E452423D46471467B4D2B838725E35EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyAppTrial
{
    partial class Places : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 9 "..\..\..\Places.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.Page_Loaded;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 16 "..\..\..\Places.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.placeslist_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 39 "..\..\..\Places.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.toggleButtonExit_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 40 "..\..\..\Places.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.toggleButtonBack_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

