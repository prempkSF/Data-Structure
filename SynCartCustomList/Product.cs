using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartCustomList
{
    public class Product
    {
        /// <summary>
        /// Static integer to manage unique Product ID
        /// </summary>
        private static int s_productID = 1000;
        /// <summary>
        /// Unique Product ID
        /// </summary>
        /// <value>PID1001</value>
        public string ProductID { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        /// <value></value>
        public string ProductName { get; set; }
        /// <summary>
        /// Product Count
        /// </summary>
        /// <value></value>
        public int Stock { get; set; }
        /// <summary>
        /// Product Price
        /// </summary>
        /// <value></value>
        public double Price { get; set; }
        /// <summary>
        /// Number of days for Shipping
        /// </summary>
        /// <value></value>
        public double ShippingDuration { get; set; }

        /// <summary>
        /// Parametrised Constructor
        /// </summary>
        /// <param name="productName">Product's Name</param>
        /// <param name="stock">Product's Stock Count</param>
        /// <param name="price">Product's Price</param>
        /// <param name="shippingDuration">Number of Days for Shipping</param>
        public Product(string productName, int stock, double price, double shippingDuration)
        {
            ProductID = $"PID{++s_productID}";
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;
        }
    }
}