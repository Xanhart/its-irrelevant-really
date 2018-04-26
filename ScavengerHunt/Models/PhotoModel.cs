using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScavengerHunt.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoImageLocation { get; set; }
        public string PhotoGPS { get; set; }
        public string PhotoAnimalName { get; set; }
    }
}