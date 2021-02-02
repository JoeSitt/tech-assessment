using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.OrderDataBase;
using CSharp.Orderns;
using CSharp.Controllers;

namespace CSharp.OrderService
{
    public class OrderService
    {
        OrderData _orderData = new OrderData();

        public string GetorderById(string id)
        {
            return ListToString(_orderData.orders.Where(x => x.Id.ToString() == id).ToList());
        }

        public string GetAll(string Pass)
        {
            if (Pass == "ImTheCaptian")
            {
                return ListToString(_orderData.orders);
            }
            else
            {
                return ListToString(_orderData.orders.Where(x => x.Id == Guid.Empty ).ToList());//dont want them to get the list with out the pass so send them back an empty list
            }
        }

        public string AddNewOrder(string id, List<string> itemsl, double price)
        {
            try
            {
                Orderns.Order temp = new Orderns.Order
                {
                    Id = Guid.Parse(id),
                    items = itemsl,
                    price = price
                };
                
                if (_orderData.orders.Where(x => x.Id == temp.Id).FirstOrDefault() == null)
                {
                    _orderData.orders.Add(temp);
                }
                else
                {
                    return "Your order: " + ListToString(_orderData.orders.Where(x => x.Id == temp.Id).ToList()) + " was already there. Maybe you ment to use the Put method of /Update/id/items/price ";
                }

                return "Your order: " + ListToString(_orderData.orders.Where(x => x.Id == temp.Id).ToList()) + " was proccessed correctly";
            }catch{
                return "your order cannot be processed";//should never be reached, but just in case
            }

        }

        public string DeleteOrder(string id)
        {
            try
            {

                Orderns.Order removed = _orderData.orders.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
                if (_orderData.orders.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault() != null)
                {
                    
                    _orderData.orders.Remove(removed);
                    return "t";//wanted to return a bool for sucess, so i chose t for true
                }
                else
                {
                    return "Your order based on id: " + id + " wasnt there.";
                }

            }
            catch
            {
                return "your order cannot be processed";
            }

        }

        public string AddItemsToOrder(string id, List<string> itemsl, double price)
        {
            try
            {
                Orderns.Order temp = new Orderns.Order
                {
                    Id = Guid.Parse(id),
                    items = itemsl,
                    price = price
                };
                if (_orderData.orders.Where(x => x.Id == temp.Id).FirstOrDefault() == null)
                {
                    _orderData.orders.Add(temp);
                    return "Your order: " + ListToString(_orderData.orders.Where(x => x.Id == temp.Id).ToList()) + " was proccessed correctly, however you should have used the Put method add/{id}/{items}/{price}";
                }
                else
                {
                    _orderData.orders.Where(x => x.Id.ToString() == id).ToList().FirstOrDefault().items.AddRange(itemsl);
                    _orderData.orders.Where(x => x.Id.ToString() == id).ToList().FirstOrDefault().price += price;
                    return "Your order was updated to: " + ListToString(_orderData.orders.Where(x => x.Id == temp.Id).ToList());

                }

            }
            catch
            {
                return "your order cannot be processed";
            }

        }



        public string ListToString(List<Orderns.Order> orders)
        {
            string l = "";
            foreach (Orderns.Order order in orders)
            {
                l = l + "{\n   Id=" + order.Id
                    + "\n   Ordered:" + order.ItemListToString()
                    + "\n   Price:" + order.price
                    + "\n}\n";

            }
            return l;
        }

    }
}
