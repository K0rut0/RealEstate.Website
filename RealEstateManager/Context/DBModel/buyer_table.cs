using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Context.DBModel
{
    public class buyer_table
    {
        public int id { get; set; }
        public string balance { get; set; }
        public string bids { get; set; }
        [Key]
        public string user_name { get; set; }
    }
}
