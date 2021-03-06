﻿using EntityFrameworkCore.Models;
using System;
using System.Linq;


namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using BankDBContext context = new BankDBContext();
            var table = from data in context.Borrows
                        select data;
            foreach (var item in table)
            {
                Console.WriteLine($"{item.Bname}\t\t\t{item.Cname}\t\t\t{item.Amount}");
            }

            Customer Cus = new Customer() { Cname = "Viral", City = "Rajkot" };

            context.Customers.Remove(new Customer() { Cname = "Viral", City = "Rajkot" });

            context.Customers.Add(Cus);
            context.SaveChanges();

            var table1 = from data in context.Customers
                         select data;
            foreach (var item in table1)
            {
                Console.WriteLine($"{item.Cname}\t\t\t{item.City}");
            }
        }
    }
}