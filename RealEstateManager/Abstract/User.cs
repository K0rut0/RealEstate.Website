using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Abstract
{
    public abstract class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public int userType { get; set; }

    }
}
