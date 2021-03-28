﻿using System;
using System.Collections.Generic;

namespace AddressBook
{
    class AddressBookMain
    {

        LinkedList<Contact> contacts = new LinkedList<Contact>();
        Dictionary<string, Contact> contactsMap = new Dictionary<string, Contact>();

        public string name;


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook" );

            AddressBookMain addressBook = new AddressBookMain();
            AddressBookMain addressBook1 = new AddressBookMain();
            AddressBookMain addressBook2 = new AddressBookMain();

            addressBook.name = "Home";
            addressBook1.name = "Business";
            addressBook2.name = "Personal";

            Dictionary<string, AddressBookMain> addressBookDict = new Dictionary<string, AddressBookMain>();
          
            addressBookDict.Add("Home", addressBook);
            addressBookDict.Add("Business", addressBook1);
            addressBookDict.Add("Personal", addressBook2);


            Contact contact1 = new Contact();
            Contact contact2 = new Contact();
            Contact contact3 = new Contact();
            Contact contact4 = new Contact();

            contact1.firstName = "Ajith";           
            contact1.lastName = "K";
            contact1.address = "2/101, ram street";
            contact1.city = "Bangalore";           
            contact1.state = "Karnataka";          
            contact1.zip = "605001";          
            contact1.phoneNumber = "123456789";
            contact1.email = "aaa@gmail.com";

            contact2.firstName = "Ajith";
            contact2.lastName = "S";
            contact2.address = "3/101, ram street";
            contact2.city = "Chennai";
            contact2.state = "Tamilnadu";
            contact2.zip = "605002";
            contact2.phoneNumber = "7653289";
            contact2.email = "bbb@gmail.com";

            contact3.firstName = "Surya";
            contact3.lastName = "M";
            contact3.address = "4/101, ram street";
            contact3.city = "Hyderabad";
            contact3.state = "Telengana";
            contact3.zip = "6764636";
            contact3.phoneNumber = "6575753289";
            contact3.email = "ccc@gmail.com";

            contact4.firstName = "Divya";
            contact4.lastName = "S";
            contact4.address = "3/654, ram street";
            contact4.city = "Hosur";
            contact4.state = "Tamilnadu";
            contact4.zip = "605746";
            contact4.phoneNumber = "76335629";
            contact4.email = "ddd@gmail.com";

            addressBook.contacts.AddLast(contact1);

            if (addressBook.contacts.Find(contact2) == null)
            {
                Console.WriteLine("Added contact2");
                addressBook.contacts.AddLast(contact2);
            }
            else
            {
                Console.WriteLine("Not Added contact2");
            }


            if (addressBook.contacts.Find(contact3) == null)
            {
                Console.WriteLine("Added contact3");
                addressBook.contacts.AddLast(contact3);
            }
            else
            {
                Console.WriteLine("Not Added contact3");
            }

            if (addressBook.contacts.Find(contact4) == null)
            {
                Console.WriteLine("Added contact4");
                addressBook.contacts.AddLast(contact4);
            }
            else
            {
                Console.WriteLine("Not Added contact4");
            }


            addressBook.contactsMap.Add("Vijay", contact1);
            addressBook.contactsMap.Add("Ajith", contact2);
            addressBook.contactsMap.Add("Surya", contact3);
            addressBook.contactsMap.Add("Divya", contact4);

            foreach (Contact i in addressBook.contacts)
            {
                i.Print();
                Console.WriteLine("-------");
            }

           Console.WriteLine("Enter the name to delete :");
            string deleteName = Console.ReadLine();

            if (addressBook.contactsMap.ContainsKey(deleteName))
            {
                Contact foundContact = addressBook.contactsMap[deleteName];
                addressBook.contacts.Remove(foundContact);
                
            }

            foreach (Contact i in addressBook.contacts)
            {
                i.Print();
                Console.WriteLine("-------");
            }

        }
    }
}
