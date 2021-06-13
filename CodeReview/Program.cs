using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview
{

	public interface ICartTotal
	{
		double Calculate(IEnumerable<Product> products, string country);
	}
	//public interface ILocalizationInfo
	//{
	//	string Country;
	//}
	public class Product
	{
		Guid Id { get; set; }
		public double Price { get; set; }
	}

	public class CartTotal : ICartTotal
	{
		public double Calculate(IEnumerable<Product> products, string country)
		{
			double total = 0.0;   //add total of products
			foreach (var product in products)
			{
				total += product.Price;
			}
			double taxRate = 0.0;
			switch (country)
			{
				case "us":
					taxRate = 0.05;
					break;
				case "ca":
					taxRate = 0.15;
					break;
			}
			total += (total * taxRate);
			return total;
		}

		public double Calculate_v2(IEnumerable<Product> products, string country)
		{
			double total = products.Sum(p => p.Price);

			total += (total * GetTaxRate(country));

			return total;
		}

		private double GetTaxRate(string country)
		{
			double taxRate = 0.0;
			switch (country)
			{
				case "us":
					taxRate = 0.05;
					break;
				case "ca":
					taxRate = 0.15;
					break;
			}
			return taxRate;
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			CartTotal cartTotal = new CartTotal();

			List<Product> products = new List<Product>();
			products.Add(new Product() { Price = 10 });
			products.Add(new Product() { Price = 10 });
			products.Add(new Product() { Price = 10 });
			products.Add(new Product() { Price = 10 });

			cartTotal.Calculate_v2(products, "us");
        }
    }
}
