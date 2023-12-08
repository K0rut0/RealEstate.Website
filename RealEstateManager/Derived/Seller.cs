using RealEstateManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Derived
{
    public class Seller : User
    { 
        public bool canSell {  get; set; }
        public int PropertyCount { get; set; }
        public string AgencyName { get; set; }

    }
}
