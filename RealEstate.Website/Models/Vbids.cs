using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Website.Models
    {
    public class Vbids
    {
        [Key]
        public int id {  get; set; }
        public string bid_amount { get; set; }
        public string bidder {  get; set; }
        public string property_name { get; set; }
        public string property_owner { get; set; }

        
    }
}
