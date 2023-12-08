using RealEstateManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Derived
{
    public class Both : User
    {
        public bool canSell {  get; set; }
        public int PropertyCount { get; set; }
        public string AgencyName { get; set; }
        public bool canBuy { get; set; }
        private double _balance;
        public double bids { get; set; }
        public double balance
        {
            get
            {
                return _balance - bids;
            }
            set
            {
                _balance = value;
            }
        }
    }
}
