using MyAppTrial.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyAppTrial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DirectionsPage : Page
    {
        Place item;
        
        public DirectionsPage()
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
            this.item = (Place)e.Parameter;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HotelItemPage), this.item);
        }

        private async void map_Loaded(object sender, RoutedEventArgs e)
        {
            var loc = new Geopoint(new BasicGeoposition() { Latitude = this.item.latitude , Longitude = this.item.longitude });
            //debug print geopintSS
            var pin = new MapIcon()
            {
                Location = loc,
                Title = this.item.name,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")),
                NormalizedAnchorPoint = new Point() { X = 0.32, Y = 0.78 },
            };
            map.MapElements.Add(pin);
            await map.TrySetViewAsync(loc, 15, 0, 0, MapAnimationKind.Bow);
        }

        private void Me_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RouteSteps),this.item);
        }

        private async void Back_Click(object sender, RoutedEventArgs e)
        {
            var loc = new Geopoint(new BasicGeoposition() { Latitude = this.item.latitude, Longitude = this.item.longitude });
            var pin = new MapIcon()
            {
                Location = loc,
                Title = this.item.name,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")),
                NormalizedAnchorPoint = new Point() { X = 0.32, Y = 0.78 },
            };
            map.MapElements.Add(pin);
            await map.TrySetViewAsync(loc, 15, 0, 0, MapAnimationKind.Bow);
        }

        private void Road_Click(object sender, RoutedEventArgs e)
        {
            map.Style = MapStyle.Road;
        }

        private void Aerial_Click(object sender, RoutedEventArgs e)
        {
            map.Style = MapStyle.Aerial;
        }

        private void AR_Click(object sender, RoutedEventArgs e)
        {
            map.Style = MapStyle.AerialWithRoads;
        }

        private async void Directions_Click(object sender, RoutedEventArgs e)
        {
            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
            Geopoint startPoint = location.Coordinate.Point;

            Geopoint endPoint = new Geopoint(new BasicGeoposition() { Latitude = this.item.latitude, Longitude = this.item.longitude });

            MapRouteFinderResult routeResult = await MapRouteFinder.GetDrivingRouteAsync(startPoint,endPoint,MapRouteOptimization.Time,MapRouteRestrictions.None,290);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Blue;
                viewOfRoute.OutlineColor = Colors.DarkBlue;
                map.Routes.Add(viewOfRoute);
                await map.TrySetViewBoundsAsync(routeResult.Route.BoundingBox,null,Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);

                System.Text.StringBuilder routeInfo = new System.Text.StringBuilder();

                routeInfo.Append("Total estimated time (minutes) = ");
                routeInfo.Append(routeResult.Route.EstimatedDuration.TotalMinutes.ToString());
                routeInfo.Append("\nTotal length (kilometers) = ");
                routeInfo.Append((routeResult.Route.LengthInMeters / 1000).ToString());

                routeInfo.Append("\n\nDIRECTIONS\n\n");

                foreach (MapRouteLeg leg in routeResult.Route.Legs)
                {
                    foreach (MapRouteManeuver maneuver in leg.Maneuvers)
                    {
                        routeInfo.AppendLine(maneuver.InstructionText);
                        routeInfo.AppendLine("\n");
                    }
                }

                this.item.routeinformation = routeInfo.ToString();
                Me.IsEnabled = true;
                /*
                var dialog = new MessageDialog(routeInfo.ToString());
                await dialog.ShowAsync();*/
            }

        }

        private async void MyLocation_Click(object sender, RoutedEventArgs e)
        {
            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));

            var pin = new MapIcon()
            {
                Location = location.Coordinate.Point,
                Title = "You are here!",
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")),
                NormalizedAnchorPoint = new Point() { X = 0.32, Y = 0.78 },
            };
            map.MapElements.Add(pin);
            await map.TrySetViewAsync(location.Coordinate.Point, 15, 0, 0, MapAnimationKind.Bow);
        }
    }
}
