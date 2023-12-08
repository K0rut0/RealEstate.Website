using Microsoft.EntityFrameworkCore.Storage;
using RealEstateManager.Context;
using RealEstateManager.Context.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManager
{
    public class PropertyManager
    {
        public bool SellProperty(properties_table prop)
        {
            using (var context = new RealEstateDBContext())
            {
                try
                {
                    context.properties_table.Add(prop);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("here");
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public List<BPropsViewModel> GetAll()
        {
            using(var context = new RealEstateDBContext())
            {
                List<BPropsViewModel> list = new List<BPropsViewModel>();
                List<properties_table> cont = context.properties_table.ToList();
                for(int i = 0; i<cont.Count; i++)
                {
                    BPropsViewModel mod = new BPropsViewModel();
                    mod.property_price = cont[i].property_price;
                    mod.property_name = cont[i].property_name;
                    mod.property_location = cont[i].property_location;
                    mod.property_type = cont[i].property_type;
                    mod.property_purchase_tax = cont[i].property_purchase_tax;
                    mod.property_anual_tax = cont[i].property_anual_tax;
                    list.Add(mod);
                }
                return list;
            }
        }

        public double CompPropArea (int s)
        {
            return s * s;
        }

        public double CompPropArea (int l, int w)
        {
            return l * w;
        }

        
    }
}
