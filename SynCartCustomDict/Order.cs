using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartCustomDict
{
    public class Order
    {
        /// <summary>
        /// Static integer to manage unique Order ID
        /// </summary>
        private static int s_orderID = 1000;
        /// <summary>
        /// Unique Order ID
        /// </summary>
        /// <value>OID1001</value>
        public string OrderID { get; set; }
        /// <summary>
        /// Customer ID
        /// </summary>
        /// <value>CID1001</value> 
        public string CustomerID { get; set; }
        /// <summary>
        /// Product ID
        /// </summary>
        /// <value>PID1001</value>
        public string ProductID { get; set; }
        /// <summary>
        /// Total Price of the Order
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }
        /// <summary>
        /// Date of Order Placed
        /// </summary>
        /// <value></value>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Number of Products Ordered
        /// </summary>
        /// <value></value>
        public int Quantity { get; set; }
        /// <summary>
        /// OrderStatus Enum Default,Ordered,Cancelled
        /// </summary>
        /// <value></value>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Parametrised Constructor
        /// </summary>
        /// <param name="customerID">Customer's ID</param>
        /// <param name="productID">Product's ID</param>
        /// <param name="totalPrice">Total Price</param>
        /// <param name="purchaseDate">Date of Order Placed</param>
        /// <param name="quantity">Quantity of Products</param>
        /// <param name="orderStatus">Order Status</param>
        public Order(string customerID, string productID, double totalPrice, DateTime purchaseDate, int quantity, OrderStatus orderStatus)
        {
            OrderID = $"OID{++s_orderID}";
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }
    }
}