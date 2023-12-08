using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Npgsql.Internal;
using RealEstateManager.Context;
using RealEstateManager.Context.DBModel;
using System.Reflection.Metadata.Ecma335;

namespace RealEstateManager
{
    public class UserManager
    {
        public user_table GetUserInfo(string username)
        {
            using(var context = new RealEstateDBContext())
            {
                try
                {
                    var checkSet = context.user_table.Where(n => n.user_name == username).ToList();
                    return checkSet[0];
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public buyer_table GetBuyerInfo(string username)
        {
            using (var context = new RealEstateDBContext())
            {
                try
                {
                    var checkSet = context.buyer_table.Where(n => n.user_name == username).ToList();
                    return checkSet[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public seller_table GetSellerInfo(string username)
        {
            using (var context = new RealEstateDBContext())
            {
                try
                {
                    var checkSet = context.seller_table.Where(n => n.user_name == username).ToList();
                    return checkSet[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public bool SignUp(string username, string password, int userType)
        {
            using (var context = new RealEstateDBContext())
            {
                try
                {
                    var checkSet = context.user_table.Where(n => n.user_name == username).ToList();
                    if (checkSet.Any()) {
                        return false;
                    }
                    var user = new user_table();
                    user.user_name = username;
                    user.user_password = password;
                    user.user_type = userType;  
                    context.user_table.Add(user);
                    if(user.user_type == 1)
                    {
                        var buyer = new buyer_table();
                        buyer.bids = 0.ToString();
                        buyer.balance = 0.ToString();
                        buyer.user_name = user.user_name;
                        context.buyer_table.Add(buyer);
                    }else if (user.user_type == 2)
                    {
                        var seller = new seller_table();
                        seller.property_count = 0;
                        seller.user_name = user.user_name;
                        context.seller_table.Add(seller);
                    } else
                    {
                        var buyer = new buyer_table();
                        buyer.bids = 0.ToString();
                        buyer.balance = 0.ToString();
                        buyer.user_name = user.user_name;
                        context.buyer_table.Add(buyer);
                        var seller = new seller_table();
                        seller.property_count = 0;
                        seller.user_name = user.user_name;
                        context.seller_table.Add(seller);
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Login(string username, string password)
        {
            using(var context = new RealEstateDBContext())
            {
                var checkSet = context.user_table.Where(n => n.user_name == username).ToArray();
                if (checkSet.Any())
                {
                    if (checkSet[0].user_password == password)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
                
            }
        }
        
    }
}