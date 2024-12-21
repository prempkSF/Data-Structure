using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SynCartCustomDict
{
    /// <summary>
    /// Static Operation Class to perform all the functionality
    /// </summary>
    public static class Operation
    {
        /// Dictionary of All Customers
        static CustomDictionary<string, CustomerDetails> customers = new CustomDictionary<string, CustomerDetails>();

        /// Dictionary of All Products
        static CustomDictionary<string, Product> products = new CustomDictionary<string, Product>();
        /// Dictionary of All Orders
        static CustomDictionary<string, Order> orders = new CustomDictionary<string, Order>();

        /// <summary>
        /// Customer Object Globally Currently LoggedIn Customer
        /// </summary>
        static CustomerDetails currentLoggedCustomer;

        /// <summary>
        /// To Load Default Data i.e Products
        /// </summary>
        public static void LoadDefaultData()
        {
            System.Console.WriteLine("*************** Application Started ****************\n");
            //Adding to Custom Dictionary
            //{ Customer ID 1 : CustomerDetails1 ,Customer ID 2 : CustomerDetails2}
            CustomerDetails customer1 = new(customerName: "Prem", city: "Tirunelveli", mobileNumber: "8738738737", walletBalance: 0, emailID: "prempk0516@gmail.com");
            customers.Add(customer1.CustomerID, customer1);
            CustomerDetails customer2 = new(customerName: "Akash", city: "Tirunelveli", mobileNumber: "942348737", walletBalance: 0, emailID: "akash6@gmail.com");
            customers.Add(customer2.CustomerID, customer2);
            Product product1 = new(productName: "MacBook Pro", stock: 12, price: 100000, shippingDuration: 3);
            products.Add(product1.ProductID, product1);
            Product product2 = new(productName: "Samsung S23", stock: 10, price: 40000, shippingDuration: 2);
            products.Add(product2.ProductID, product2);
        }

        /// <summary>
        /// <see cref="MainMenu()"/> which display Main Menu options
        /// </summary>
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("*********Application Exit********");
                            flag = false;
                            break;
                        }
                }

            } while (flag);
        }

        /// <summary>
        /// Customer Registration
        /// </summary>
        public static void Registration()
        {
            try
            {
                System.Console.WriteLine("*************** Registration ****************");
                System.Console.WriteLine("Enter Customer Name : ");
                string customerName = Console.ReadLine();
                System.Console.WriteLine("Enter City : ");
                string city = Console.ReadLine();
                System.Console.WriteLine("Enter Mobile Number : ");
                string mobileNumber = Console.ReadLine();
                System.Console.WriteLine("Enter Wallet Amount : ");
                double walletBalance;
                while (double.TryParse(Console.ReadLine(), null, out walletBalance))
                {
                    System.Console.WriteLine("Enter valid Wallet Balance : ");
                }
                System.Console.WriteLine("Enter Email ID : ");
                string emailID = Console.ReadLine();
                CustomerDetails customerDetails = new CustomerDetails(customerName: customerName, city: city, mobileNumber: mobileNumber, walletBalance: walletBalance, emailID: emailID);
                customerDetails.RechargeWallet(walletBalance);
                //Adding to Dictionary
                customers.Add(customerDetails.CustomerID, customerDetails);
                System.Console.WriteLine("Registration Successful");
                System.Console.WriteLine($"Your Customer ID {customerDetails.CustomerID}");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }

        }

        /// <summary>
        /// Customer Login
        /// </summary>
        public static void Login()
        {
            try
            {
                System.Console.WriteLine("Enter Customer ID : ");
                string customerID = Console.ReadLine().ToUpper();
                //If customerID contains in the customer ID Dictionary
                if (customers.ContainsKey(customerID))
                {
                    currentLoggedCustomer = customers[customerID];
                    System.Console.WriteLine("*************** Login Successful ****************");
                    SubMenu();
                }
                else
                {
                    System.Console.WriteLine("Customer Not Found..!");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// <see cref="SubMenu()"/> SubMenu Options
        /// </summary>
        public static void SubMenu()
        {
            try
            {
                bool subMenuFlag = true;
                do
                {
                    System.Console.WriteLine("1.Purchase      | 2.OrderHistory   | 3.Cancel Order");
                    System.Console.WriteLine("4.WalletBalance | 5.WalletRecharge | 6.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                CancelOrder();
                                break;
                            }
                        case 4:
                            {
                                WalletBalance();
                                break;
                            }
                        case 5:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 6:
                            {
                                System.Console.WriteLine("*************** Exit ****************");
                                subMenuFlag = false;
                                break;
                            }
                    }
                } while (subMenuFlag);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// To Purchase the Products
        /// </summary>
        public static void Purchase()
        {
            try
            {
                System.Console.WriteLine("***************Purchase****************");
                System.Console.WriteLine();
                System.Console.WriteLine("*************** List Of Products ****************");
                foreach (KeyValue<string, Product> product in products)
                {
                    //Show Available Products
                    //Key Value Pair
                    System.Console.WriteLine($"Product ID : {product.Value.ProductID}\nProduct Name : {product.Value.ProductName}\nStock : {product.Value.Stock}\nPrice : {product.Value.Price}\nShipping Duration : {product.Value.ShippingDuration}");
                    System.Console.WriteLine();
                }
                //Ask Customer to Enter Product ID and Quantity
                System.Console.WriteLine("Enter ProductID : ");
                string productID = Console.ReadLine().ToUpper();
                System.Console.WriteLine("Enter Quantity : ");
                int quantity = int.Parse(Console.ReadLine());
                if (products.ContainsKey(productID))
                {
                    Product product = products[productID];
                    //Check Product Stock is Enough
                    if (product.Stock >= quantity)
                    {
                        //Add Delivery Charges
                        double totalPrice = (product.Price * quantity) + 50;
                        //Check Customer Wallet Balance is Enough
                        if (!(totalPrice > currentLoggedCustomer.WalletBalance))
                        {
                            //If Amount is Enough Create Order
                            Order order = new Order(customerID: currentLoggedCustomer.CustomerID, productID: product.ProductID, purchaseDate: DateTime.Now, quantity: quantity, orderStatus: OrderStatus.Ordered, totalPrice: totalPrice);
                            System.Console.WriteLine("Order Placed Successfully");
                            //Display Order ID and Shippind Date
                            //Show Message Order Placed Sucuessfull
                            System.Console.WriteLine($"Your Order ID is {order.OrderID}");
                            //Deduct Wallet Amount
                            currentLoggedCustomer.DeductWallet(totalPrice);
                            //Deduct Stock Count
                            product.Stock=product.Stock-quantity;
                            orders.Add(order.OrderID, order);
                        }
                        else
                        {
                            //If not Show Not Enough Balance
                            System.Console.WriteLine("Insufficient Wallet Balance Please Recharge");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Sorry!...Stock Not Available");
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid Product ID");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }

        }
        /// <summary>
        /// To show the Order History
        /// </summary>
        public static void OrderHistory()
        {
            try
            {
                bool isOrdered = true;
                foreach (KeyValue<string, Order> order in orders)
                {
                    //Key Value Pair
                    if (order.Value.CustomerID.Equals(currentLoggedCustomer.CustomerID))
                    {
                        isOrdered = false;
                        System.Console.WriteLine($"Order ID : {order.Value.OrderID}\nCustomer ID : {order.Value.CustomerID}\nProduct ID: {order.Value.ProductID}\nTotal Price : {order.Value.TotalPrice}\nPurchase Date : {order.Value.PurchaseDate}\nQuantity : {order.Value.Quantity}\nOrder Status : {order.Value.OrderStatus}");
                        System.Console.WriteLine();
                    }
                }
                if (isOrdered)
                {
                    System.Console.WriteLine("No Order History Found...!");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// To Cancel a Order
        /// </summary>
        public static void CancelOrder()
        {
            try
            {
                bool isOrdered = true;
                //Show Order History
                foreach (KeyValue<string, Order> order in orders)
                {
                    //Key Value Pair
                    if (order.Value.CustomerID.Equals(currentLoggedCustomer.CustomerID) && order.Value.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        isOrdered = false;
                        System.Console.WriteLine($"Order ID : {order.Value.OrderID}\nCustomer ID : {order.Value.CustomerID}\nProduct ID: {order.Value.ProductID}\nTotal Price : {order.Value.TotalPrice}\nPurchase Date : {order.Value.PurchaseDate}\nQuantity : {order.Value.Quantity}\nOrder Status : {order.Value.OrderStatus}");
                        System.Console.WriteLine();
                    }
                }
                if (isOrdered)
                {
                    System.Console.WriteLine("No Order History Found...!");
                }
                else
                {
                    //Get Order ID
                    System.Console.WriteLine("Enter Order ID to Cancel : ");
                    string orderId = Console.ReadLine().ToUpper();
                    //Check if Order ID exists
                    if (orders.ContainsKey(orderId))
                    {
                        //Add the Product Quantity, Stock Count
                        Order order = orders[orderId];
                        order.OrderStatus = OrderStatus.Cancelled;
                        Product product = products[order.ProductID];
                        product.Stock=product.Stock+order.Quantity;
                        //Add the amount to balance
                        currentLoggedCustomer.RechargeWallet(order.TotalPrice);
                        System.Console.WriteLine("Order Cancelled Sucessfully !!!");
                        //Show Order Cancelled Sucessfully

                    }
                    else
                    {
                        //If Order ID is Valid check Order Status if in Valid Show invalid Order ID
                        System.Console.WriteLine("Incorrect Order ID...");
                    }

                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// To Check the Customer Wallet Balance
        /// </summary>
        public static void WalletBalance()
        {
            //Get Wallet Balance
            System.Console.WriteLine($"Your Current Balance is {currentLoggedCustomer.CurrentBalance()}");
        }
        /// <summary>
        /// To Recharge the Customer Wallet
        /// </summary>
        public static void WalletRecharge()
        {
            try
            {
                //Wallet Recharge
                //If Amount is Valid>0 add to Wallet and Show Balance
                //Else Show Invalid Amount

                System.Console.WriteLine("Enter Wallet Recharge Amount : ");
                double rechargeWallet = double.Parse(Console.ReadLine());
                if (rechargeWallet > 0)
                {
                    currentLoggedCustomer.RechargeWallet(rechargeAmount: rechargeWallet);
                    WalletBalance();
                }
                else
                {
                    System.Console.WriteLine("Invalid Recharge Amount");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }

    }
}


