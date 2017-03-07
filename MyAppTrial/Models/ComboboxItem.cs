using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTrial.Models
{
    class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public Place place { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
