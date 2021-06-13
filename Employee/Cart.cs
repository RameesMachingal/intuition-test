using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public interface ICartTotal
    {
        double Calculate(IEnumerable<Product> products, ILocalizationInfo localInfo);
    }
    public interface ILocalizationInfo
    {
        string Country { get; set; }
    }
    public class Product
    {
        Guid Id { get; set; }
        public double Price { get; set; }
    }
    public class CartTotal : ICartTotal
    {
        public double Calculate(IEnumerable<Product> products, ILocalizationInfo localInfo)
        {
            double total = 0.0;

            // Avoid looping, use linq function SUM to sum up the price
            foreach (var product in products)
            {
                total += product.Price;
            }

            // Move the below code to a separate method, which can be reused if needed
            double taxRate = 0.0;
            switch (localInfo.Country)
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

        /// <summary>
		/// Calculate version 2
		/// </summary>
		/// <param name="products"></param>
		/// <param name="localInfo"></param>
		/// <returns></returns>
		public double CalculateV2(IEnumerable<Product> products, ILocalizationInfo localInfo)
        {
            // Get the total
            double total = products.Sum(p => p.Price);

            // Calculate the tax component
            double taxComponent = total * GetTaxRate(localInfo.Country);

            // add to the total
            total += taxComponent;
            return total;
        }

        /// <summary>
        /// Gets the tax rate by country
        /// </summary>
        /// <param name="country">country code</param>
        /// <returns>Tax rate</returns>
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
}
