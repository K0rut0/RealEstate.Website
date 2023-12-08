
using System.ComponentModel.DataAnnotations;

namespace RealEstateManager.Context.DBModel
{
    public class user_table
    {
        [Key]
        public Int16 id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public int user_type { get; set; }
    }
}
