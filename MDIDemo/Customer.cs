// Customer.cs
// Author:  Kyle Chapman
// Date:    March 1, 2021
// Description:
//  A class designed to as a record of an individual customer,
//  including a little information that describes their importance.

using System;
using System.Collections.Generic;
using System.Text;

namespace MDIDemo
{
    /// <summary>
    /// A class designed to as a record of an individual customer, including a little information that describes their importance.
    /// </summary>
    class Customer
    {
        // Static private variable to hold the number of customers.
        private static int customerCount = 0;
        // Private variable to hold the customer's identification number.
        private int customerId = 0;
        // Private variable to hold the customer's title.
        private string customerTitle = String.Empty;
        // Private variable to hold the customer's first name.
        private string customerFirstName = String.Empty;
        // Private variable to hold the customer's last name.
        private string customerLastName = String.Empty;
        // Private variable to hold the customer's status.
        private bool customerVipStatus = false;

        /// <summary>
        /// Constructor - Default - creates a new customer object.
        /// </summary>
        public Customer()
        {
            customerCount += 1;
            customerId = customerCount;
        }

        /// <summary>
        /// Constructor - Parameterized - creates a new customer object
        /// </summary>
        /// <param name="title">Customer's title</param>
        /// <param name="firstName">Customer's first name</param>
        /// <param name="lastName">Customer's last name</param>
        /// <param name="vipStatus">true if a customer is a very important person</param>
        public Customer(string title, string firstName, string lastName, bool vipStatus): this()
        {
            // The ": this()" part above calls the default constructor, setting the Id.

            // Set all of the instance variables within this class using the values
            // passed into this constructor.
            customerTitle = title;
            customerFirstName = firstName;
            customerLastName = lastName;
            customerVipStatus = vipStatus;
        }

        /// <summary>
        /// Count ReadOnly Property - Gets the number of customers that have been instantiated/created
        /// </summary>
        public int Count
        {
            get
            {
                return customerCount;
            }
        }

        /// <summary>
        /// IdentificationNumber ReadOnly Property - Gets a specific customers' identification number
        /// </summary>
        public int Id
        {
            get
            {
                return customerId;
            }
        }

        /// <summary>
        /// VeryImportantPersonStatus Property - >Gets and Sets the Very Important Person status of a customer
        /// </summary>
        public bool VipStatus
        {
            get
            {
                return customerVipStatus;
            }
            set
            {
                // The value passed in is always called "value" by default.
                customerVipStatus = value;
            }
        }

        /// <summary>
        /// Title property - Gets and Sets the title of a customer
        /// </summary>
        public string Title
        {
            get
            {
                return customerTitle;
            }
            set
            {
                // The value passed in is always called "value" by default - regardless of the data type.
                customerTitle = value;
            }
        }

        /// <summary>
        /// FirstName property - Gets and Sets the first name of a customer
        /// </summary>
        public string FirstName
        {
            get
            {
                return customerFirstName;
            }
            set
            {
                customerFirstName = value;
            }
        }

        /// <summary>
        /// LastName property - Gets and Sets the last name of a customer
        /// </summary>
        public string LastName
        {
            get
            {
                return customerLastName;
            }
            set
            {
                customerLastName = value;
            }
        }

        /// <summary>
        /// GetSalutation is a function that a salutation based on the private properties within the class scope
        /// </summary>
        /// <returns>string describing the customer</returns>
        public string GetSalutation()
        {
            return "Hi, my name is " + customerTitle + " " + customerFirstName + " " + customerLastName + ", " + (customerVipStatus ? "I am a VIP" : "I am not a VIP");

            // The single line of code above is equivalent to the following eight lines of code:
            //if (customerVipStatus)
            //{
            //    return "Hi, my name is " + customerTitle + " " + customerFirstName + " " + customerLastName + ", I am a VIP";
            //}
            //else
            //{
            //    return "Hi, my name is " + customerTitle + " " + customerFirstName + " " + customerLastName + ", I am not a VIP";
            //}
        }

    }
}
