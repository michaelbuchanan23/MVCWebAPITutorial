using MVCWebAPITutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebAPITutorial.Controllers
{
	public class CustomersController : ApiController {

		private MVCWebAPIDBContext db = new MVCWebAPIDBContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public IEnumerable<Customer> List() {
			return db.Customers.ToList();
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public Customer Customer(int? id) {
			if (id == null) {
				return null;
			}
			return db.Customers.Find(id);
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Customer customer) {
			if (customer == null) {
				return false;
			}
			if(!ModelState.IsValid) {
				return false;
			}
			db.Customers.Add(customer);
			db.SaveChanges();
			return true;
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Customer customer) {
			if (customer == null) {
				return false;
			}
			if (!ModelState.IsValid) {
				return false;
			}
			var cust = db.Customers.Find(customer.Id);
			cust.Name = customer.Name;
			cust.City = customer.City;
			cust.State = customer.State;
			cust.Preferred = customer.Preferred;
			db.SaveChanges();
			return true;
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Customer customer) {
			if (customer == null) {
				return false;
			}
			if (!ModelState.IsValid) {
				return false;
			}
			var cust = db.Customers.Find(customer.Id);
			db.Customers.Remove(cust);
			db.SaveChanges();
			return true;
		}
	}
}
