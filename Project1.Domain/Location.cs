using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Location
    { 



        public string Name { get; set; }
        public string Address { get; set; }

        //removed locationID
        public Location(string name, string address)
        {
            Name = name;
            Address = address;

        }



    }
}
