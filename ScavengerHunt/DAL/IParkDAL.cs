using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScavengerHunt.Models;

namespace ScavengerHunt.DAL
{
    interface IParkDAL
    {
        List<Park> AllParks();
    }
}
