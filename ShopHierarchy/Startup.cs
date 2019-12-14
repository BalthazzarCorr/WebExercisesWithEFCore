namespace ShopHierarchy
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Startup
	{
		static void Main()
		{
			using (var db = new MyDbContext())
			{
				PrepareDatabase(db);

				SaveSalesman(db);
				SaveItems(db);
				ProcessCommands(db);

				//	PrintCustomerCountPerSalesman(db);
				//PrintCustomerCountReviewsAndOrders(db);

				PrintCustomerOrdersAndReviews(db);

				//PrintCustomerData(db);
			}
		}

		


		private static void PrintCustomerCountReviewsAndOrders(MyDbContext db)
		{
			var customersData = db.Customers.Select(c => new
			{
				c.Name,
				Orders = c.Orders.Count,
				Reviews = c.Reviews.Count
			}).OrderByDescending(c => c.Orders)
				.ThenByDescending(r => r.Reviews)
				.ToList();

			foreach (var customer in customersData)
			{
				Console.WriteLine(customer.Name);
				Console.WriteLine($"Orders:{customer.Orders}");
				Console.WriteLine($"Reviews: {customer.Reviews}");
			}
		}


		private static void ProcessCommands(MyDbContext db)
		{
			while (true)
			{
				var line = Console.ReadLine();

				if (line == "END")
				{
					break;
				}

				var args = line.Split('-');
				var command = args[0];
				var arguments = args[1];
				
				switch (command)
				{
					case "register":
						RegisterCustomer(db, arguments);
						break;
					case "order":
						SaveOrder(db, arguments);
						break;
					case "review":
						SaveReview(db, arguments);
						break;
					default:
						break;

				}




			}
		}


		private static void RegisterCustomer(MyDbContext db, string argumentStrings)
		{
			var arguments = argumentStrings.Split(';');
			var name = arguments[0];
			var id = int.Parse(arguments[1]);
			db.Add(new Customer
			{
				Name = name,
				SalesmanId = id
			});
			db.SaveChanges();
		}


		private static void PrepareDatabase(MyDbContext db)
		{
			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();

		}

		private static void SaveSalesman(MyDbContext db)
		{
			var salesmans = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

			foreach (var salesman in salesmans)
			{
				db.Add(new Salesman { Name = salesman });
			}

			db.SaveChanges();
		}

		private static void PrintCustomerCountPerSalesman(MyDbContext db)
		{

			var SalesmanInformation = db.Salesmans.Select(s => new
			{
				s.Name,
				s.Customers.Count
			}).OrderByDescending(s => s.Count).ThenBy(s => s.Name).ToList();


			foreach (var salsemanInfo in SalesmanInformation)
			{
				Console.WriteLine($"{salsemanInfo.Name} - {salsemanInfo.Count} customers");
			}
		}

		private static void SaveReview(MyDbContext db, string arguments)
		{
			var parts = arguments.Split(';');
			var customerId = int.Parse(parts[0]);
			var itemId = int.Parse(parts[1]);

			db.Add(new Review
			{
				CustomerId = customerId,
				ItemId = itemId
			});
			db.SaveChanges();
		}

		private static void SaveOrder(MyDbContext db, string arguments)
		{
			var parts = arguments.Split(';');
			var customerId = int.Parse(parts[0]);
			
			var order = new Order
			{
				CustomerId = customerId
			};

			for (int i = 1; i < parts.Length; i++)
			{
				var itemId = int.Parse(parts[i]);


				order.Items.Add(new ItemOrder
				{
					ItemId = itemId
				});
			}

			

			db.Add(order);
			db.SaveChanges();
		}

		private static void SaveItems(MyDbContext db)
		{
			while (true)
			{
				var line = Console.ReadLine();

				if (line=="END")
				{
					break;
				}

				var parts = line.Split(';');
				var itemName = parts[0];
				var itemPrice = decimal.Parse(parts[1]);

				db.Add(new Item
				{
					Name = itemName,
					Price = itemPrice
				});
				
			}
			db.SaveChanges();
		}

		private static void PrintCustomerOrdersAndReviews(MyDbContext db)
		{
			
			int customerId = int.Parse(Console.ReadLine());

			var customerData = db
				.Customers
				.Where(c => c.Id == customerId)
				.Select(c=> new
				{
					Orders = c
						.Orders
						.Select(o=> new
					{
						o.Id,
						Items = o.Items.Count
					})
						.OrderByDescending(o=>o.Id)
					,Reviews = c.Reviews.Count
				}).FirstOrDefault();
				
//
//			foreach (var order in customerData.Orders)
//			{
//				Console.WriteLine($"order{order.Id} : {order.Items}");
//			}
//
//			Console.WriteLine($"reviews: {customerData.Reviews}");
		}

	}

}
