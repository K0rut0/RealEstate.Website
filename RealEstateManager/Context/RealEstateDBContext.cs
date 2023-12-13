using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstateManager.Context.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager.Context
{
    public class RealEstateDBContext : DbContext
    {
        public DbSet<user_table> user_table { get; set; }
        public DbSet<buyer_table> buyer_table { get; set; }
        public DbSet<seller_table> seller_table { get; set; }
        public DbSet<properties_table> properties_table { get; set; }
        public DbSet<bids> bids { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("User Id = postgres; Password=eSy0RR0ClV0i5MoX;Server=db.zmebaqpxjlkacjajfoxn.supabase.co;Port=5432;Database=postgres");
    }
}
