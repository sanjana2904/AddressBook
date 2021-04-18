using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBook
{
    class Contact
    {


        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        /*   public string firstName;
           public string lastName;
           public string address;
           public string city;
           public string state;
           public string zip;
           public string phoneNumber;
           public string email;       */


        public void Initialize(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("File exists");
                String[] lines;
                lines = File.ReadAllLines(path);
                firstName = lines[0];
                lastName = lines[1];
                address = lines[2];
                city = lines[3];
                state = lines[4];
                zip = Int32.Parse(lines[5]);
                phoneNumber = lines[6];
                email = lines[7];
            }
            else
            {
                Console.WriteLine("File not exist");
            }

        }

        public override string ToString()
        {
            return "Contact: " + firstName + " " + lastName + " " + address + " " + city + " " + state + " " + zip + " " + phoneNumber + " " + email;
        }

        public override bool Equals(object obj)
        {
            Contact c = (Contact)obj;
            return firstName.Equals(c.firstName);
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode();
        }

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

