using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CSharp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Test : Controllers.Orders
	{ 
		[HttpGet]
		[Route("GetTested")]
		public string GetTested()
		{
			bool t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12;

			// Test 1 : verify getAll requires the correct password  http://localhost:5001/Orders/all/ImTheCaptain
			t1 = "" == GetAll("ImTheCaptain");

			//Test 2 : Verify that deleting a nonexistant id result in proper message http://localhost:5001/Orders/delete/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/
			t2 = "Your order based on id: 56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6 wasnt there." == DeleteOrderFromExistance("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6");

			//Test 3 : Verify that getting a record that doesnt exist produces correct message http://localhost:5001/Orders/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/
			t3 = "order: 56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6 not found" == GetAnOrder("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6");

			//Test 4: Verify that put items produces the correct response when updating an order http://localhost:5001/Orders/update/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/Milk,Cats,Karma,Lazers/420.00
			t4 = Putadditems("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6", "Milk,Cats,Karma,Lazers", 420.00) == "Your order: {\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:420\n}\n was proccessed correctly, however you should have used the Put method add/{id}/{items}/{price}";

			//Test 5 : getting an order a method that does have an entry produces proper response. http://localhost:5001/Orders/update/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/Milk,Cats,Karma,Lazers/420.00
			t5 = GetAnOrder("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6") == "{\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:420\n}\n";

			//test 6: verify that post cant add an already exisiting order and produces the correct error message http://localhost:5001/Orders/add/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/Milk,Cats,Karma,Lazers}/420.00
			t6 = PostAdd("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6", "Milk,Cats,Karma,Lazers", 420.00) == "Your order: {\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:420\n}\n was already there. Maybe you ment to use the Put method of /Update/id/items/price ";

			//Test 7: Verify that put items produces the correct response when updating an order http://localhost:5001/Orders/update/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/Milk,Cats,Karma,Lazers/420.00
			t7 = Putadditems("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6", "Milk,Cats,Karma,Lazers", 420.00) == "Your order was updated to: {\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:840\n}\n";

			//Test 8: Verify Delete Deletes items corectly and displays the correct message http://localhost:5001/Orders/delete/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/
			t8 = DeleteOrderFromExistance("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6") == "The Order {\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:840\n}\n was deleted";

			//Test 9: Verify Post adds the order correctly when it doesnt exist in the database http://localhost:5001/Orders/add/56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6/Milk,Cats,Karma,Lazers}/420.00
			t9 = PostAdd("56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6", "Milk,Cats,Karma,Lazers", 420.00) == "Your order: {\n   Id=56d5ec5d-2103-4dd7-ac6b-f5a8cfa8f8a6\n   Ordered:\n    {\n      Milk,\n      Cats,\n      Karma,\n      Lazers,\n    }\n   Price:420\n}\n was proccessed correctly";

			t10 = t1 && t2 && t3 && t4 && t5 && t6 && t7 && t8 && t9;

			return "If a test is Followed by True it passed\nTest 1:"+t1+"\nTest 2:"+t2+"\nTest 3:"+t3+"\nTest 4:"+t4 + "\nTest 5:"+t5+"\nTest 6:"+t6 + "\nTest 7:"+t7 + "\nTest 8:"+t8 + "\nTest 9:" +t9+"\n Do All tests pass:"+t10;
		}

	}
}
