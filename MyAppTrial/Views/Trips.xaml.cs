using MyAppTrial.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyAppTrial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Trips : Page
    {
        int user_id;
        public Trips()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void data_arrived(object sender, DownloadCompleteData e)
        {
            String data = e.data;

            if( data != "You have no trips yet")
            {
                JArray obj = JArray.Parse(data);

                for (int i = 0; i < obj.Count; i++)
                {
                    JObject row = JObject.Parse(obj[i].ToString());
                    var trip = new Trip();
                    trip.id = Int32.Parse(row["id"].ToString());
                    trip.name = row["name"].ToString();
                    trip.city_id = Int32.Parse(row["city_id"].ToString());
                    trip.user_id = Int32.Parse(row["user_id"].ToString());
                    TriplistView.Items.Add(trip);
                }
            }
            else
            {
                notrips.Text = data;
            }

            

            /*JArray obj = JArray.Parse(data);
            Debug.WriteLine(obj[0].ToString());
            var trip = new Trip();
            trip.name = obj[0].ToString();

            String place_data = obj[1].ToString();
            
            JArray place_obj = JArray.Parse(place_data);

            for (int i = 0; i < place_obj.Count;i++ )
            {
                JObject row = JObject.Parse(place_obj[i].ToString());
                var item = new Place();
                item.name = row["name"].ToString();
                item.address = row["address"].ToString();
                item.city = row["city"].ToString();
                item.category = row["category"].ToString();
                item.img = new BitmapImage(new Uri("http://thilinim.cnsytex.com/app1/web/" + row["path"].ToString(), UriKind.Absolute));
                trip.places.Add(item);

            }

            String hotel_data = obj[2].ToString();
            JArray hotel_obj = JArray.Parse(hotel_data);

            for (int i = 0; i < hotel_obj.Count; i++)
            {
                JObject row = JObject.Parse(hotel_obj[i].ToString());
                var item = new Hotel();
                item.name = row["name"].ToString();
                item.address = row["address"].ToString();
                item.city = row["city"].ToString();
                item.category = row["category"].ToString();
                item.img = new BitmapImage(new Uri("http://thilinim.cnsytex.com/app1/web/" + row["path"].ToString(), UriKind.Absolute));
                trip.hotels.Add(item);

            }*/
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //this.teamResponse = e.Parameter.ToString();
            this.user_id = (Int32)e.Parameter;
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            download_data dwl = new download_data();

            dwl.downloadDatacomplete += data_arrived;
            string teamResponse = "http://thilinim.cnsytex.com/wp/trip.php?id=" + this.user_id.ToString();
            dwl.get_data(teamResponse);
        }

        private void TriplistView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var trip = (Trip)TriplistView.SelectedItem;
            Frame.Navigate(typeof(TripPageItem), trip);
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
