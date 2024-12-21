using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace SynCartCustomList
{
    /// <summary>
    /// Static Operation Class to perform all the functionality
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// List of All Customers
        /// </summary>
        /// <typeparam name="CustomerDetails"></typeparam>
        /// <returns></returns>
        static CustomList<CustomerDetails> customers = new CustomList<CustomerDetails>();
        /// <summary>
        /// List of All Products 
        /// </summary>
        /// <typeparam name="Product"></typeparam>
        /// <returns></returns>
        static CustomList<Product> products = new CustomList<Product>();
        /// <summary>
        /// List of All Orders
        /// </summary>
        /// <typeparam name="Order"></typeparam>
        /// <returns></returns>
        static CustomList<Order> orders = new CustomList<Order>();

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
            customers.Add(new(customerName: "Prem", city: "Tirunelveli", mobileNumber: "8738738737", walletBalance: 0, emailID: "prempk0516@gmail.com"));
            customers.Add(new(customerName: "Akash", city: "Tirunelveli", mobileNumber: "942348737", walletBalance: 0, emailID: "akash6@gmail.com"));

            products.Add(new(productName: "MacBook Pro", stock: 12, price: 100000, shippingDuration: 3));
            products.Add(new(productName: "Samsung S23", stock: 15, price: 40000, shippingDuration: 2));
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
                customers.Add(customerDetails);
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
                //Binary Search to find the Login User
                Search<CustomerDetails> search = new Search<CustomerDetails>();
                bool flag = true;
                currentLoggedCustomer = search.BinarySearch(searchElement: customerID, values: customers, prop: "CustomerID", flag: out flag);

                if (flag)
                {
                    //If user not found
                    System.Console.WriteLine("Customer Not Found..!");
                }
                else
                {
                    //If user found
                    System.Console.WriteLine("*************** Login Successful ****************");
                    SubMenu();
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
                System.Console.WriteLine("***************List Of Products****************");
                //Displaying Products not Searching
                foreach (Product product in products)
                {
                    //Show Available Products
                    System.Console.WriteLine($"Product ID : {product.ProductID}\nProduct Name : {product.ProductName}\nStock : {product.Stock}\nPrice : {product.Price}\nShipping Duration : {product.ShippingDuration}");
                    System.Console.WriteLine();
                }
                //Ask Customer to Enter Product ID and Quantity
                System.Console.WriteLine("Enter ProductID : ");
                string productID = Console.ReadLine().ToUpper();
                System.Console.WriteLine("Enter Quantity : ");
                int quantity = int.Parse(Console.ReadLine());
                bool flagOrder = true;
                //Binary Search
                //Searching for Product
                Search<Product> search = new Search<Product>();
                Product searchProduct = search.BinarySearch(values: products, searchElement: productID, flag: out flagOrder, prop: "ProductID");
                if (!flagOrder)
                {
                    if (searchProduct.Stock >= quantity)
                    {
                        //Add Delivery Charges
                        double totalPrice = (searchProduct.Price * quantity) + 50;
                        //Check Customer Wallet Balance is Enough
                        if (!(totalPrice > currentLoggedCustomer.WalletBalance))
                        {
                            //If Amount is Enough Create Order
                            Order order = new Order(customerID: currentLoggedCustomer.CustomerID, productID: searchProduct.ProductID, purchaseDate: DateTime.Now, quantity: quantity, orderStatus: OrderStatus.Ordered, totalPrice: totalPrice);
                            System.Console.WriteLine("Order Placed Successfully");
                            //Display Order ID and Shippind Date
                            //Show Message Order Placed Sucuessfull
                            System.Console.WriteLine($"Your Order ID is {order.OrderID}");
                            //Deduct Wallet Amount
                            currentLoggedCustomer.DeductWallet(totalPrice);
                            //Deduct Stock Count
                            searchProduct.Stock--;
                            orders.Add(order);
                        }
                        else
                        {
                            //If not Show Not Enough Balance
                            System.Console.WriteLine("Insufficient Wallet Balance Please Recharge");
                        }
                    }
                    //If Product Stock Not Available
                    else
                    {
                        System.Console.WriteLine("Sorry!...Stock Not Available");
                    }
                }
                //If Product Not Found
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
                foreach (Order order in orders)
                {
                    if (order.CustomerID.Equals(currentLoggedCustomer.CustomerID))
                    {
                        isOrdered = false;
                        System.Console.WriteLine($"Order ID : {order.OrderID}\nCustomer ID : {order.CustomerID}\nProduct ID: {order.ProductID}\nTotal Price : {order.TotalPrice}\nPurchase Date : {order.PurchaseDate}\nQuantity : {order.Quantity}\nOrder Status : {order.OrderStatus}");
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
                //Show Order History only the Ordered.Status 
                foreach (Order order in orders)
                {
                    if (order.CustomerID.Equals(currentLoggedCustomer.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                    {
                        isOrdered = false;
                        System.Console.WriteLine($"Order ID : {order.OrderID}\nCustomer ID : {order.CustomerID}\nProduct ID: {order.ProductID}\nTotal Price : {order.TotalPrice}\nPurchase Date : {order.PurchaseDate}\nQuantity : {order.Quantity}\nOrder Status : {order.OrderStatus}");
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
                    bool isValidOrder = true;
                    Search<Order> search = new Search<Order>();
                    //Binary Search
                    //To find the order
                    Order order = search.BinarySearch(searchElement: orderId, values: orders, prop: "OrderID", flag: out isValidOrder);
                    if (isValidOrder)
                    {
                        //Show invalid Order ID
                        System.Console.WriteLine("Incorrect Order ID...");
                    }
                    else
                    {
                        //Add the Product Quantity, Stock Count
                        order.OrderStatus = OrderStatus.Cancelled;
                        //Binary Search
                        //To find the product
                        Search<Product> searchProduct = new Search<Product>();
                        Product product = searchProduct.BinarySearch(searchElement: order.ProductID, values: products, prop: "ProductID", flag: out isValidOrder);
                        product.Stock++;
                        //Add the amount to balance
                        currentLoggedCustomer.RechargeWallet(order.TotalPrice);
                        System.Console.WriteLine("Order Cancelled Sucessfully !!!");
                        //Show Order Cancelled Sucessfully
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


