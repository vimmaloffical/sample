using System;

namespace OrderProccessing
{
	public class Program
	{
		public static void Main(string[] args)
		{





			Product product = new Product();
			Payment payment = new Payment();
			OrderPipe orderproccessing = new OrderPipe();



			Console.WriteLine("********************Welcome********************");
			Console.WriteLine("");
			Console.WriteLine("********************select The Product ********************");

			foreach (var prod in product.LoadProduct())
			{
				Console.WriteLine(" Name Of the Product : " + prod.Name);
				Console.WriteLine("");
				Console.WriteLine(" select Of the Product using type: " + prod.ProductTypeId.ToString());
				Console.WriteLine("");
				Console.WriteLine("Cost : " + prod.Cost.ToString());
			}
			Console.WriteLine("");
			Console.WriteLine(" select Of the Product Now: ");

			var ReceivedProduct = Console.ReadLine();

			var producttype = int.Parse(ReceivedProduct);
			if (producttype < 6)
			{
				var productorder = product.GetProduct(producttype);

				Console.WriteLine("******************** You have Liked : " + productorder.Name);
				Console.WriteLine("");
				Console.WriteLine("********************Make the Payment********************");

				var money = Console.ReadLine();
				decimal moneyreceived = decimal.Parse(money);
				var result = payment.Makepayment(moneyreceived);

				Console.WriteLine("********************Payment Received********************");
				Console.WriteLine("");
				Console.WriteLine("********************We have received Payment of rs: " + result.ToString());
				Console.WriteLine("");
				Console.WriteLine("********************Order Processing started*******************");
				Console.WriteLine("");
				orderproccessing.OrderProccessing(productorder);
				Console.WriteLine("");
				Console.WriteLine("********************Order Processing Ended*******************");
				Console.WriteLine("");
				Console.WriteLine("********************Thank You for visiting our site********************");
				Console.WriteLine("");
				Console.WriteLine("********************send your Feedback to this email xxxx@xxx.com********************");
				Console.WriteLine("");

			}
			else

			{
				Console.WriteLine("********************Error in selection********************");

				Console.WriteLine("********************Thank You for visiting our site********************");

			}


			Console.ReadLine();
		}
	}

	#region Product

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ProductTypeId { get; set; }
		public decimal Cost { get; set; }


		public List<Product> LoadProduct()
		{
			List<Product> products = new List<Product>();
			Product product = new Product();
			product.Id = 1;
			product.Name = "Physical Product";
			product.ProductTypeId = 1;
			product.Cost = 25;

			products.Add(product);
			product = new Product();
			product.Id = 2;
			product.Name = "Book";
			product.ProductTypeId = 2;
			product.Cost = 250;
			products.Add(product);

			product = new Product();
			product.Id = 3;
			product.Name = "membership";
			product.Cost = 20;
			product.ProductTypeId = 3;
			products.Add(product);


			product = new Product();
			product.Id = 4;
			product.Name = "upgrade membership";
			product.ProductTypeId = 4;
			product.Cost = 50;
			products.Add(product);

			product = new Product();
			product.Id = 5;
			product.Name = "Learning ski";
			product.ProductTypeId = 5;
			products.Add(product);


			return products;

		}

		public Product GetProduct(int producttype)
		{
			return LoadProduct().Where(p => p.ProductTypeId == producttype).FirstOrDefault();

		}

	}

	#endregion

	#region Payment

	public class Payment
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int PaymentTypeId { get; set; }
		public Decimal Amount { get; set; }

		public Decimal Makepayment(Decimal amount)
		{
			//if (amount>0)
			//	return false;
			return amount;
		}
		public int PayCommission()
		{
			//if (amount>0)
			//	return false;
			return 5;
		}



	}
	public class PaymentType
	{
		public int Id { get; set; }
		public string Name { get; set; }

	}
	#endregion

	#region Region
	public class Address
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

	}
	public class state
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

	}
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }

	}
	#endregion

	#region Slip
	public class PackingSlip
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int PackingSlipTypeId { get; set; }

		public string GeneratePackingSlip() { return Guid.NewGuid().ToString(); }
		//public string GeneratePackingSlip(string link) { return Guid.NewGuid().ToString(); }
		//public string GenerateRolaitySlip() { return Guid.NewGuid().ToString(); }


	}
	public class PackingSlipType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Guid Code { get; set; }
	}
	public class Membership
	{
		public void MembershipActived()
		{
			Console.WriteLine("");
			Console.WriteLine("Activation code : " + Guid.NewGuid().ToString());
			Console.WriteLine("");
			Console.WriteLine("Membership activitated Now login here from verification:");
			Console.WriteLine("");

		}
		public void upgrade()
		{
			Console.WriteLine("Activation code : " + Guid.NewGuid().ToString());
			Console.WriteLine("");
			Console.WriteLine("Membership upgraded:");
			Console.WriteLine("");
		}
		//public void upgrade()
		//{
		//	Console.WriteLine("Activation code : " + Guid.NewGuid().ToString());
		//	Console.WriteLine("");
		//	Console.WriteLine("Membership upgraded:");
		//	Console.WriteLine("");
		//}

	}
	#endregion

	#region Payment

	/// <summary>
	/// 
	/// </summary>
	public class NotificationService
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int NotificationTypeId { get; set; }


		public void Maild(string extraemaild = "")
		{
			//if (amount>0)
			//	return false;
			Console.WriteLine("Enter your Email id here :");
			var emaild = Console.ReadLine();
			Console.WriteLine("");
			Console.WriteLine("Email Order copy to Sent to address: " + emaild);
			Console.WriteLine("");
		}
		public string SMS(string phoneNo = "")
		{
			//if (amount>0)
			//	return false;
			Console.WriteLine("enter your Email id here :");
			var phoneNo1 = Console.ReadLine();
			if (!string.IsNullOrEmpty(phoneNo))
				return "phoneNo Message to sent: " + phoneNo1;
			else
				return "phoneNo Message to sent: " + phoneNo1 + " second number " + phoneNo;
		}

	}
	public class NotificationType
	{
		public int Id { get; set; }
		public string Name { get; set; }

	}
	#endregion


	public class OrderPipe
	{


		/// <summary>
		/// /
		/// </summary>
		/// <param name="product"></param>
		public void OrderProccessing(Product product)
		{
			Membership membership = new Membership();
			PackingSlip packingSlip = new PackingSlip();
			NotificationService notificationService = new NotificationService();
			Random random = new Random();
			Payment payment = new Payment();
			if (product.Id == 1)
			{

				string slip = packingSlip.GeneratePackingSlip();
				Console.WriteLine("Printing slip : " + slip);
				Console.WriteLine("");
				Console.WriteLine("Order No : " + random.Next(1, 999999999).ToString());
				Console.WriteLine("");

			}
			else if (product.Id == 2)
			{

				string slip = packingSlip.GeneratePackingSlip();
				Console.WriteLine("Royalty slip : " + slip);
				Console.WriteLine("Commission Earned : " + payment.PayCommission().ToString());
				Console.WriteLine("");
				Console.WriteLine("Order No : " + random.Next(1, 999999999).ToString());
			}
			else if (product.Id == 3)
			{


				membership.MembershipActived();
				Console.WriteLine("");
				Console.WriteLine("Order No : " + random.Next(1, 999999999).ToString());

			}
			else if (product.Id == 4)
			{

				membership.MembershipActived();
				Console.WriteLine("");
				Console.WriteLine("Order No : " + random.Next(1, 999999999).ToString());

			}
			else if (product.Id == 5)
			{

				membership.upgrade();
				Console.WriteLine("");
				Console.WriteLine("Order No : " + random.Next(1, 999999999).ToString());
			}
			Console.WriteLine("");
			notificationService.Maild();
		}

	}

	/// <summary>
	/// 
	/// </summary>
	public interface IRule
	{
		bool Product(Product product, Payment paid);
	}




}


	//namespace sample
	//{


	//    class User
	//	{
	//		public int Age { get; set; }
	//		public string UserName { get; set; }
	//	}

	//		public class Program
	//	{

	//		public class User
	//		{
	//			public int Age
	//			{
	//				get;
	//				set;
	//			}

	//			public string Name
	//			{
	//				get;
	//				set;
	//			}
	//		}

	//		static Expression BuildExpr<T>(Rule r, ParameterExpression param)
	//		{
	//			var left = MemberExpression.Property(param, r.Name);
	//			var tProp = typeof(T).GetProperty(r.Name).PropertyType;
	//			ExpressionType tBinary;
	//			// is the operator a known .NET operator?
	//			if (ExpressionType.TryParse(r.Operator, out tBinary))
	//			{
	//				var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tProp));
	//				// use a binary operation, e.g. 'Equal' -> 'u.Age == 15'
	//				return Expression.MakeBinary(tBinary, left, right);
	//			}
	//			else
	//			{
	//				var method = tProp.GetMethod(r.Operator);
	//				var tParam = method.GetParameters()[0].ParameterType;
	//				var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tParam));
	//				// use a method call, e.g. 'Contains' -> 'u.Tags.Contains(some_tag)'
	//				return Expression.Call(left, method, right);
	//			}
	//		}

	//		public static void Main()
	//		{
	//			List<Rule> rules = new List<Rule>
	//		{
	//		new Rule("Age", "GreaterThan", "20"), new Rule("Name", "Equal", "John")}

	//			;
	//			var user1 = new User
	//			{
	//				Age = 13,
	//				Name = "royi"
	//			}

	//			;
	//			var user2 = new User
	//			{
	//				Age = 33,
	//				Name = "john"
	//			}

	//			;
	//			var user3 = new User
	//			{
	//				Age = 53,
	//				Name = "paul"
	//			}

	//			;
	//			var rule = new Rule("Age", "GreaterThan", "20");
	//			Func<User, bool> compiledRule = CompileRule<User>(rule);
	//			//compiledRule(user2).Dump();

	//		}

	//		public static Func<T, bool> CompileRule<T>(Rule r)
	//		{
	//			var paramUser = Expression.Parameter(typeof(User));
	//			Expression expr = BuildExpr<T>(r, paramUser);
	//			// build a lambda function User->bool and compile it
	//			return Expression.Lambda<Func<T, bool>>(expr, paramUser).Compile();
	//		}

	//		public class Rule
	//		{
	//			public string Name
	//			{
	//				get;
	//				set;
	//			}

	//			public string Operator
	//			{
	//				get;
	//				set;
	//			}

	//			public string TargetValue
	//			{
	//				get;
	//				set;
	//			}

	//			public Rule(string MemberName, string Operator, string TargetValue)
	//			{
	//				this.Name = MemberName;
	//				this.Operator = Operator;
	//				this.TargetValue = TargetValue;
	//			}
	//		}



	//	}
	//}
}
