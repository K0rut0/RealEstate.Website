using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Abstract
{
    public abstract class PropertyCosts
    {
        public abstract double CompAnnualTax(int cost);
        public abstract double CompPurchaseTax(int cost);
    }
}
