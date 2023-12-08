using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Derived
{
    public class Hybrid : Industrial
    {
        public int shape_type;
        public int l;
        public int w;
        public double rent(int cost)
        {
            return cost * 0.001;
        }
    }
}
