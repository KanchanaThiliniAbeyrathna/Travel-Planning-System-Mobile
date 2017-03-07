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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MyAppTrial.Models;
using Windows.UI.Xaml.Media.Imaging;
using System.Globalization;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyAppTrial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Hotels : Page
    {
        List<Place> hotelList;

        public Hotels()
        {
            hotelList = new List<Place>();
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void data_arrived(object sender, DownloadCompleteData e)
        {

            String data = e.data;

            JArray obj = JArray.Parse(data);

            for (int i = 0; i < obj.Count; i++)
            {

                JObject row = JObject.Parse(obj[i].ToString());

                var item = new Place();
                item.name = row["name"].ToString();
                item.address = row["address"].ToString();
                item.email = row["email"].ToString();
                item.category = row["category"].ToString();
                item.city = row["city"].ToString();
                double latitude;
                if (double.TryParse(row["latitude"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out latitude))
                {
                    item.latitude = latitude;
                }

                double longitude;
                if (double.TryParse(row["longitude"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out longitude))
                {
                    item.longitude = longitude;
                }


                item.img = new BitmapImage(new Uri("http://thilinim.cnsytex.com/app1/web/" + row["path"].ToString(), UriKind.Absolute));
                list.Items.Add(item);
                hotelList.Add(item);
            }


        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            download_data dwl = new download_data();

            dwl.downloadDatacomplete += data_arrived;
            dwl.get_data("http://thilinim.cnsytex.com/wp/hotels.php");
        }

        private void list_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Place item = (Place)list.SelectedItem;
            Frame.Navigate(typeof(HotelItemPage), item);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SecondPage));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

    }
}
