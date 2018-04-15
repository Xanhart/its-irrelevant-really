using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScavengerHunt.Models
{
    public class Park
    {
        public int ParkID { get; set; }
        public string ParkName { get; set; }
        public string Parkaddress { get; set; }
        public string ParkCity { get; set; }
        public string ParkState { get; set; }
        public int ParkZip { get; set; }

    }
}