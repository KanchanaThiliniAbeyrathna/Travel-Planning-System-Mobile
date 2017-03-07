using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTrial.Models
{
    class Trip
    {
        public int id { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
        public int user_id { get; set; }
        public List<Place> places { get; set; }

        public User getuser(int id)
        {
            User user = new User();
            user.id = id;
            return user;
        }
    }
}
