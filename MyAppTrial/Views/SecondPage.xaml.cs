using MyAppTrial.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyAppTrial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void textBlock1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Places));
        }

        private void textBlock2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Hotels));
        }

        private void textBlock4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private void textBlock3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*var item = new User();
            item.id = 3;
            Frame.Navigate(typeof(Trips), item);*/
            Frame.Navigate(typeof(LoginPage));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void visit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("http://thilinim.cnsytex.com/app1/web/app_dev.php"));
        }
    }
}
