using System;

namespace AddressBook
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook" );

            Contact contact1 = new Contact();
            
            Console.WriteLine("Enter your first name is : ");
            contact1.firstName = Console.ReadLine();
            
            Console.WriteLine("Enter your last name is : ");
            contact1.lastName = Console.ReadLine();

            Console.WriteLine("Enter your address is : ");
            contact1.address = Console.ReadLine();

            Console.WriteLine("Enter your city is : ");
            contact1.city = Console.ReadLine();

            Console.WriteLine("Enter your state is : ");
            contact1.state = Console.ReadLine();

            Console.WriteLine("Enter your Zip is : ");
            contact1.zip = Console.ReadLine();

            Console.WriteLine("Enter your phone number is : ");
            contact1.phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your Email is : ");
            contact1.email = Console.ReadLine();

            Console.WriteLine("First name is : " + contact1.firstName );
            Console.WriteLine("Last name is : " + contact1.lastName);
            Console.WriteLine("address is : " + contact1.address);
            Console.WriteLine("city : " + contact1.city);
            Console.WriteLine("state is : " + contact1.state);
            Console.WriteLine("zip is : " + contact1.zip);
            Console.WriteLine("PhoneNumber is : " + contact1.phoneNumber);
            Console.WriteLine("Email is : " + contact1.email);


        }
    }
}
