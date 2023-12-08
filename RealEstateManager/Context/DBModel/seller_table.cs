using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Context.DBModel
{
    public class seller_table
    {
        public int id {  get; set; }
        [Key]
        public string user_name { get; set; }
        public int property_count { get; set; }
        
        public string agency_name { get; set; }
    }
}
