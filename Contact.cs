﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contact
    {

        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string phoneNumber;
        public string email;

        public void Print()
        {
            Console.WriteLine("firstName is : " + firstName);
            Console.WriteLine("lastName is : " + lastName);
            Console.WriteLine("Address is : " + address);
            Console.WriteLine("city is : " + city);
            Console.WriteLine("state is : " + state);
            Console.WriteLine("zip is : " + zip);
            Console.WriteLine("phoneNumber is : " + phoneNumber);
            Console.WriteLine("email is :" + email);
        }

    }
}
