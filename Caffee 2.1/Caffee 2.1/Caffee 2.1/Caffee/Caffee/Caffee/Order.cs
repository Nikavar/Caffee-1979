using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caffee
{
    public class Order
    {
        public int OrderNumber { get; private set; } = 1;
        public double TotalCount{ get; set; }
        // public delegate Predicate<double> WasBought();
        public Action<List<Product>> WasBought { get; set; }


        public List<OrderItem> SellingList { get; set; } = new List<OrderItem>();


        //public void CompliteSellingList(int index)
        //{
        //    var ChosenProduct = (from p in DB.DefaultProductList
        //                where p.ID == index
        //                select p).SingleOrDefault();

        //    SellingList.Add(ChosenProduct);
        //}

        

        public List<OrderItem> CompliteSellingList(Product p)
        {
            if (SellingList.Any(x => x.product == p))
            {
                var currOrder = SellingList.SingleOrDefault(o => o.product == p);
                currOrder.Quantity++;
            }
            else
            {
                OrderItem order = new OrderItem();
                order.Id = SellingList.Count + 1;
                order.product = p;
                SellingList.Add(order);
            }
            return SellingList;
        }

        //public void PrintOrder()
        //{
        //    foreach (var item in SellingList)
        //    {
        //        Console.WriteLine($"Id:{item.ID} - Product Name:{item.ProductName} -Price: {item.Price}");
        //        Console.WriteLine($"Total Price: {CalculateTotalPrice()}");
        //    }
        //}

        public double CalculateTotalPrice()
        {
            return SellingList.Sum(x => x.ProductPrice);
        }

        public void Remove(OrderItem item)
        {
            SellingList.Remove(item);
        }

        public List<OrderItem> GetOrderList()
        {
            return SellingList;
        }

        //public (string message,bool isBoght) Selling(double ClientMoney)
        //{
        //    //string Note;
        //    //double amount = ClientMoney - CalculateTotalPrice();
        //    //if (amount < 0)
        //    //     Note = "You have add extra" + amount + " Gel";
        //    //else if (amount > 0)
        //    //     Note = "Get your change: " + amount + " Gel"; 
        //    //else
        //    //    Note = "Bye bye";

        //    //var orderList = GetOrderList();
        //    //WasBought?.Invoke(orderList);

        //    //return (Note, true);
        //}
    }
}
