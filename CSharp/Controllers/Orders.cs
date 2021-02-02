using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharp.OrderService;


namespace CSharp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Orders : ControllerBase
	{
		private OrderService.OrderService _orderService = new OrderService.OrderService();

		[HttpGet]
		[Route("")]
		public string Get()
        {
			return "Please request an order. ";
        }


		[HttpGet]
		[Route("{orderid}")]
		public string GetAnOrder(string orderid)
        {
			try
			{
				string t = _orderService.GetorderById(orderid);
				if(t!="")
					return t;
				return "order: " + orderid + " not found";
			}
            catch
            {
				return "order: " + orderid + " not found";
            }
        }

		[HttpGet]
		[Route("all/{pass}")]
		public string GetAll(string pass)
		{
			return _orderService.GetAll(pass);//used for debuging and to get all of the orders. the password was chosen as no one would guess that phrase spelled wrong
		}

		[HttpPost]
		[Route("add/{id}/{items}/{price}")]
		public string PostAdd(string id, string items, double price)
        {
			char[] splitchar = { ',', '}' };
			string[] _items= items.Split(splitchar);
            try
            {
				return _orderService.AddNewOrder(id, _items.ToList(), price);

            }
            catch
            {
				return "Order unsuccessful";
            }
        }

		[HttpPut]
		[Route("update/{id}/{items}/{price}")]
		public string Putadditems(string id, string items, double price)
        {
			char[] splitchar = { ',' };
			string[] _items = items.Split(splitchar);
			return _orderService.AddItemsToOrder(id, _items.ToList(), price);
        }

		[HttpDelete]
		[Route("delete/{id}")]
		public string DeleteOrderFromExistance(string id) 
        {
			string removed = GetAnOrder(id);
			string result = _orderService.DeleteOrder(id);
			if(result == "t")//t was chosen as i made it to return a string, and i just wanted to return a bool for if its deleted
				return "The Order "+ removed +" was deleted";
			return result;
        }

	}
}
