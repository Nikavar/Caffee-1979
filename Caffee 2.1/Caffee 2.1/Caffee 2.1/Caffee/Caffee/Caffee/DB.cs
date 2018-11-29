using System;
using System.Collections.Generic;
using System.Text;

namespace Caffee
{
    public class DB
    {
        public static List<Product> DefaultProductList { get; private set; } =
            new List<Product>()
            {
                new Product { ID = 1, Price = 0.35, ProductName = "Aplle"},
                new Product { ID = 2, Price = 0.63, ProductName = "Banana"},
                new Product { ID = 3, Price = 1.35, ProductName = "Sandwitch"},
                new Product { ID = 4, Price = 2.63, ProductName = "Roat Potato"},
                new Product { ID = 5, Price = 2.63, ProductName = "Khachapuri"}
            };

        static DBLite dbLite = new DBLite();

        public static void Add(Product p)
        {
            dbLite.Add(p);
            //DefaultProductList.Add(p);
        }

        public static void Remove(Product p)
        {
            dbLite.Remove(p);
            //DefaultProductList.Remove(p);
        } 

        public static void Update(Product p)
        {
            dbLite.Update(p);
        }

        public static List<Product> GetAllProducts()
        {
            return dbLite.getProducts();
        }

        /* Methods for OrderItem Class in front side*/

        public static void AddOrders(OrderItem order)
        {
            dbLite.AddOrder(order);
        }

    }
}
