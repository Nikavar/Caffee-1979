﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace Caffee
{
    public static class Platform
    {
        public static string DatabasePath { get; set; }
    }

    public class DBLite
    {
        SQLiteConnection Conn { get; }

        public DBLite()
        {
            string path = Platform.DatabasePath;
            Conn = new SQLiteConnection(path);
            Conn.CreateTable<TableProduct>();
            Conn.CreateTable<OrderItemTable>();
            Conn.CreateTable<OrderTable>();
        }

        public void Add(Product p)
        {
            Conn.Insert(new TableProduct() { Price = p.Price, ProductName = p.ProductName });
        }

        public void Remove(Product p)
        {
            Conn.Delete(Conn.Table<TableProduct>().FirstOrDefault(x => x.Id == p.ID));
        }

        public void Update(Product p)
        {
            var result = Conn.Table<TableProduct>().Where(x => x.Id == p.ID).
                         SingleOrDefault();

            result.Price = p.Price;
            result.ProductName = p.ProductName;

            Conn.Update(result);
        }

        public List<Product> getProducts()
        {
            return Conn.Table<TableProduct>().ToList().Select(x=> new Product { ID = x.Id, Price = x.Price, ProductName = x.ProductName }).ToList();
        }

        /*Methods for OrderItem Class*/

        public void AddOrder(List<OrderItem> ItemList)
        {
            var row = new OrderTable() { SoldDate = DateTime.Now };
            Conn.Insert(row);
            

            foreach (var i in ItemList)
            {
                Conn.Insert(new OrderItemTable() { OrderId = row.Id, ProductId = i.product.ID, Quantity = i.Quantity });
            }            

            //var query = from order in Conn.Table<OrderTable>().ToList()
            //            join orderItem in Conn.Table<OrderItemTable>().ToList()
            //            join p in Conn.Table<TableProduct>().ToList();

        }

        public void Update(OrderItem order)
        {
            var query = Conn.Table<OrderItemTable>().Where(x => x.Id == order.Id).
                        SingleOrDefault();
        }
    }

    public class TableProduct
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }
    }


    public class OrderItemTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime SoldDate { get; set; }
    }

}
