﻿#pragma checksum "C:\Users\Me\Desktop\blackJack\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F97D4F8F27FCFD1D4DEACAE85421D295"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Project_Blackjack
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 102
                {
                    this.btnDraw = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDraw).Click += this.Draw_Click;
                }
                break;
            case 3: // MainPage.xaml line 103
                {
                    this.btnStart = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnStart).Click += this.Start_Click;
                }
                break;
            case 4: // MainPage.xaml line 105
                {
                    this.btnStop = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnStop).Click += this.Stop_Click;
                }
                break;
            case 5: // MainPage.xaml line 70
                {
                    this.GridUserHand = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // MainPage.xaml line 63
                {
                    this.ComputerStoppedSign = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7: // MainPage.xaml line 65
                {
                    this.UserStoppedSign = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 8: // MainPage.xaml line 34
                {
                    this.GridComputerHand = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9: // MainPage.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Exit_Click;
                }
                break;
            case 10: // MainPage.xaml line 22
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Question_Click;
                }
                break;
            case 11: // MainPage.xaml line 23
                {
                    this.btnTestMode = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnTestMode).Click += this.TestMode_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

