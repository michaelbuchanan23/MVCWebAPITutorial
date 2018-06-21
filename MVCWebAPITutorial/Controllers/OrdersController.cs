using MVCWebAPITutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebAPITutorial.Controllers
{
    public class OrdersController : ApiController {

		private MVCWebAPIDBContext db = new MVCWebAPIDBContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public IEnumerable<Order> List() {
			return db.Orders.ToList();
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public Order Order(int? id) {
			if (id == null) {
				return null;
			}
			return db.Orders.Find(id);
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Order order) {
			if (order == null) {
				return false;
			}
			if (!ModelState.IsValid) {
				return false;
			}
			db.Orders.Add(order);
			db.SaveChanges();
			return true;
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Order order) {
			if (order == null) {
				return false;
			}
			if (!ModelState.IsValid) {
				return false;
			}
			var ord = db.Orders.Find(order.Id);
			ord.Description = order.Description;
			ord.Total = order.Total;
			ord.CustomerId = order.CustomerId;
			db.SaveChanges();
			return true;
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Order order) {
			if (order == null) {
				return false;
			}
			if (!ModelState.IsValid) {
				return false;
			}
			var ord = db.Orders.Find(order.Id);
			db.Orders.Remove(ord);
			db.SaveChanges();
			return true;
		}
	}
}
