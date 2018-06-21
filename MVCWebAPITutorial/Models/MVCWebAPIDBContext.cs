using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCWebAPITutorial.Controllers;

namespace MVCWebAPITutorial.Models {

	public class MVCWebAPIDBContext: DbContext {

		public MVCWebAPIDBContext() : base() { }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Order> Orders { get; set; }
	}
}