using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Orderns;


namespace CSharp.OrderDataBase
{
    public class OrderData
    {//i appologise the orders are weird. i dont like generic fake data.
        private static List<Order> _orders = new List<Order>()
        {
            new Order()
            {
                Id = Guid.Parse("a232073b-6842-4e4b-8b4f-b00d33cd391a"),
                items = {"dog", "Russia", "flour"},
                price= 3.50

            },
            new Order()
            {
                Id = Guid.Parse("f31f40ab-608b-432b-8ad4-ba257afa81a7"),
                items = {"Red Fish", "Blue Fish", "REDACTED"},
                price= 345.99
            },
            new Order()
            {
                Id = Guid.Parse("979335e4-6fef-4ac6-be82-a5973190bcbe"),
                items = {"Milk", "French...Fries", "Ducktape"},
                price= 30000005.67
            }
        };

        public List<Order> orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
    }
}
