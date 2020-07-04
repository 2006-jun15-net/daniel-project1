using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Location(int locationID, string name, string address)
        {
            LocationId = locationID;
            Name = name;
            Address = address;

        }
    }
}
