using RealEstateManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Derived
{
    public class Commercial : PropertyCosts
    {
        private double _AnnualTax;
        private double _PurchaseTax;
        public int cost {  get; set; }
        public override double CompAnnualTax(int cost)
        {
            _AnnualTax = cost * 0.005;
            return cost * 0.005;
        }

        public override double CompPurchaseTax(int cost)
        {
            _PurchaseTax = cost * 0.15;
            return cost * 0.15;
        }
        public double AnnualTax { get { return _AnnualTax; }  }
        public double PurchaseTax { get { return _PurchaseTax; } }
    }
}
