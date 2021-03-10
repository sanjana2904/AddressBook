using System;
using System.Collections.Generic;

namespace AddressBook
{
    class AddressBookMain
    {

        LinkedList<Contact> contacts = new LinkedList<Contact>();
        Dictionary<string, Contact> contactsMap = new Dictionary<string, Contact>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook" );

            AddressBookMain addressBook = new AddressBookMain();

            Contact contact1 = new Contact();
            Contact contact2 = new Contact();
            Contact contact3 = new Contact();
            Contact contact4 = new Contact();

            contact1.firstName = "Vijay";           
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
            addressBook.contacts.AddLast(contact2);
            addressBook.contacts.AddLast(contact3);
            addressBook.contacts.AddLast(contact4);

            addressBook.contactsMap.Add("Vijay", contact1);
            addressBook.contactsMap.Add("Ajith", contact2);
            addressBook.contactsMap.Add("Surya", contact3);
            addressBook.contactsMap.Add("Divya", contact4);

            foreach (Contact i in addressBook.contacts)
            {
                i.Print();
                Console.WriteLine("-------");
            }

           Console.WriteLine("Enter the name to edit :");
            string editName = Console.ReadLine();

            if (addressBook.contactsMap.ContainsKey(editName))
            {
                Contact foundContact = addressBook.contactsMap[editName];

                Console.WriteLine("Enter your first name is : ");
                foundContact.firstName = Console.ReadLine();

                Console.WriteLine("Enter your last name is : ");
                foundContact.lastName = Console.ReadLine();

                Console.WriteLine("Enter your address is : ");
                foundContact.address = Console.ReadLine();

                Console.WriteLine("Enter your city is : ");
                foundContact.city = Console.ReadLine();

                Console.WriteLine("Enter your state is : ");
                foundContact.state = Console.ReadLine();

                Console.WriteLine("Enter your Zip is : ");
                foundContact.zip = Console.ReadLine();

                Console.WriteLine("Enter your phone number is : ");
                foundContact.phoneNumber = Console.ReadLine();

                Console.WriteLine("Enter your Email is : ");
                foundContact.email = Console.ReadLine();

            }

            foreach (Contact i in addressBook.contacts)
            {
                i.Print();
                Console.WriteLine("-------");
            }

        }
    }
}
