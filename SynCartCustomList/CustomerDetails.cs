using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartCustomList
{
    public class CustomerDetails
    {
        /// <summary>
        /// static integer to manage Unique Customer ID
        /// </summary>
        private static int s_customerID=1000;
        /// <summary>
        /// To Store Customer Wallet Balance Read, Write
        /// </summary>
        /// <value></value>
        private double _walletBalance { get; set; }
        /// <summary>
        /// Unique Customer ID
        /// </summary>
        /// <value>CID1001</value>
        public string CustomerID { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        /// <value></value>
        public string CustomerName { get; set; }
        /// <summary>
        /// Customer Resident City
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>
        /// <value></value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// To Store Customer Wallet Balance Read Only
        /// </summary>
        /// <value></value>
        public double WalletBalance { get{return _walletBalance;} }
        /// <summary>
        /// Customer's Email ID
        /// </summary>
        /// <value></value>
        public string EmailID { get; set; }

        /// <summary>
        /// Parametrised Constructor
        /// </summary>
        /// <param name="customerName">Customer's Name</param>
        /// <param name="city">Customer's Resident City</param>
        /// <param name="mobileNumber">Customer's Mobile Number</param>
        /// <param name="walletBalance">Customer's Wallet Balance</param>
        /// <param name="emailID">Customer's Email ID</param>
        public CustomerDetails(string customerName,string city,string mobileNumber,double walletBalance,string emailID)
        {
            CustomerID=$"CID{++s_customerID}";
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            _walletBalance=walletBalance;
            EmailID=emailID;
        }

        /// <summary>
        /// To Return Customer Current Balance
        /// </summary>
        /// <returns></returns>
        public double CurrentBalance()
        {
            return _walletBalance;
        }
        /// <summary>
        /// To Recharge Customer's Wallet
        /// </summary>
        /// <param name="rechargeAmount"></param>
        public void RechargeWallet(double rechargeAmount)
        {
            _walletBalance=_walletBalance+rechargeAmount;
        }
        /// <summary>
        /// To Deduct Amount from Cusotmer's Wallet
        /// </summary>
        /// <param name="deductAmoubt"></param>
        public void DeductWallet(double deductAmoubt)
        {
            _walletBalance=_walletBalance-deductAmoubt;
        }
    }
}