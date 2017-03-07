using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using MyAppTrial.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyAppTrial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        public LoginPage()
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

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SecondPage));
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            string loginParams = "email=" + EmailtextBox.Text + "&password=" + passwordBox.Password;
            string responseBody = await checkLogin(loginParams);
            if (responseBody != "ERROR LOGIN")
            {
                String data = responseBody;

                JArray obj = JArray.Parse(data);
                var user = new User();

                for (int i = 0; i < obj.Count;)
                {
                    JObject row = JObject.Parse(obj[i].ToString());

                    user.id = Int32.Parse(row["id"].ToString());
                    user.password = row["password"].ToString();
                    user.email = row["email"].ToString();
                    break;
                }
                var dialog = new MessageDialog("Login Successfull !!!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Trips), user.id);

                Debug.WriteLine("Login Successfull !!!");
            }
            else
            {
                var dialog = new MessageDialog(responseBody);
                await dialog.ShowAsync();
            }
        }

        public async System.Threading.Tasks.Task<string> checkLogin(string loginParams)
        {

            string teamResponse = "http://thilinim.cnsytex.com/wp/login.php?" + loginParams;
            Debug.WriteLine(teamResponse);

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.PostAsync(new Uri(teamResponse), null);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;

            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", ex.Message);
                return ex.Message;
            }
        }

    }
}
