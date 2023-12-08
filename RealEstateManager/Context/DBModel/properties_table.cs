using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Context.DBModel
{
    public class properties_table
    {
        [Key]
        public int id {  get; set; }
        public string property_name { get; set; }
        public string property_location { get; set; }
        public int property_type { get; set; }
        public string property_price { get; set; }
        public string property_anual_tax { get; set; }
        public string property_purchase_tax { get; set; }

    }
}
