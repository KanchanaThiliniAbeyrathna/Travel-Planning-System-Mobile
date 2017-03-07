using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace MyAppTrial.Models
{
    public class Place
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public BitmapImage img { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string city { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string routeinformation { get; set; }

        public double covertToDouble(string s)
        {
            double d;
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out d))
            {
                return d;
            }
            return 0;
        }
    }
}
