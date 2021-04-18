using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBook
{
    class AddressBookMain
    {

        LinkedList<Contact> contacts = new LinkedList<Contact>();
        Dictionary<string, Contact> contactsMap = new Dictionary<string, Contact>();

        public string name;


        public void SortByName()
        {
           List<Contact> sortedContacts = contacts.OrderBy(c => c.firstName).ToList();
            contacts = new LinkedList<Contact>(sortedContacts);
        }

        public void SortByState()
        {
            List<Contact> sortedContacts = contacts.OrderBy(c => c.state).ToList();
            contacts = new LinkedList<Contact>(sortedContacts);
        }

        static LinkedList<Contact> Search(string state, LinkedList<AddressBookMain> addressBooks)
        {
            Dictionary<string, LinkedList<Contact>> addressBookDict = new Dictionary<string, LinkedList<Contact>>();
            foreach (AddressBookMain addressBook in addressBooks)
            {
                foreach (Contact i in addressBook.contacts)
                {
                    string s = i.state;
                    if (addressBookDict.ContainsKey(s))
                    {
                        addressBookDict[s].AddLast(i);
                    }
                    else
                    {
                        LinkedList<Contact> list = new LinkedList<Contact>();
                        list.AddLast(i);
                        addressBookDict.Add(s, list);
                    }
                }
            }
           
            if(addressBookDict.ContainsKey(state))
            {
                return addressBookDict[state];
            }
            else
            {
                return null;
            }
        }

        public void readCSV(string path)
        {
            //reading csv file
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (Contact contact in records)
                {
                    Console.WriteLine(contact);
                }
            }
        }

        public void writeCSV(string path)
        {
            //writing csv file
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(contacts);
            }
        }


        public void readJSON(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonText);
            //Contact c = JsonConvert.DeserializeObject<Contact>(jsonText);
            foreach (Contact i in contacts)
            {
                Console.WriteLine(i);
                Console.WriteLine("-------");
            }
        }


        public void writeJSON(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook" );

           

            AddressBookRepo addressbookrepo = new AddressBookRepo();
            //addressbookrepo.GetAddressBook();
            Contact contact = new Contact();
      
            contact.firstName = "sanjana";
            contact.lastName = "k";
            contact.address = "Chennai Highways";
            contact.city = "Krishnagiri";
            contact.state = "TamilNadu";
            contact.zip = 635001;
            contact.phoneNumber = "9988776655";
            contact.email = "aaa123@gmail.com";

            addressbookrepo.Create(contact);
            addressbookrepo.GetAddressBook();
            addressbookrepo.Update("sanjana", "Anusha" );
            addressbookrepo.Delete("K");
            DateTime fromDate = DateTime.Parse("2021-04-16");
            DateTime toDate = DateTime.Parse("2021-04-19");
            addressbookrepo.GetContacts(fromDate, toDate);
            addressbookrepo.CountContacts("Chennai");
            return;


            AddressBookMain addressBook = new AddressBookMain();
            AddressBookMain addressBook1 = new AddressBookMain();
            AddressBookMain addressBook2 = new AddressBookMain();

            addressBook.readCSV("C:\\Users\\sanja\\source\\repos\\AddressBook\\utility\\Addresses.csv");
            
            


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
            contact1.zip = 605001;          
            contact1.phoneNumber = "123456789";
            contact1.email = "aaa@gmail.com";

            contact2.firstName = "Ajith";
            contact2.lastName = "S";
            contact2.address = "3/101, ram street";
            contact2.city = "Chennai";
            contact2.state = "Tamilnadu";
            contact2.zip = 605002;
            contact2.phoneNumber = "7653289";
            contact2.email = "bbb@gmail.com";

            contact3.firstName = "Surya";
            contact3.lastName = "M";
            contact3.address = "4/101, ram street";
            contact3.city = "Hyderabad";
            contact3.state = "Telengana";
            contact3.zip = 6764636;
            contact3.phoneNumber = "6575753289";
            contact3.email = "ccc@gmail.com";

            contact4.firstName = "Divya";
            contact4.lastName = "S";
            contact4.address = "3/654, ram street";
            contact4.city = "Hosur";
            contact4.state = "Tamilnadu";
            contact4.zip = 605746;
            contact4.phoneNumber = "76335629";
            contact4.email = "ddd@gmail.com";

            Contact contact5 = new Contact();
            contact5.Initialize("C:\\Users\\sanja\\source\\repos\\AddressBook\\Example.txt");
            Console.WriteLine(contact5);




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


            addressBook.writeCSV("C:\\Users\\sanja\\source\\repos\\AddressBook\\utility\\export.csv");
            addressBook.readJSON("C:\\Users\\sanja\\source\\repos\\AddressBook\\utility\\JsonRead.json");
            addressBook.writeJSON("C:\\Users\\sanja\\source\\repos\\AddressBook\\utility\\JsonWrite.json");
            return;
        



            string state = "Tamilnadu";
            LinkedList<AddressBookMain> addressBooks = new LinkedList<AddressBookMain>();
            addressBooks.AddLast(addressBook);
            addressBooks.AddLast(addressBook1);
            addressBooks.AddLast(addressBook2);


            LinkedList<Contact> result = Search(state, addressBooks);
            if(result == null)
            {
                Console.WriteLine("contacts are not available");
            }
            else
            {
                Console.WriteLine(" Number of person in state " + state + " is " + result.Count);

                foreach (Contact i in result)
                {
                    i.Print();
                    Console.WriteLine("-------");
                }
            }

            addressBook.SortByName();
            foreach (Contact i in addressBook.contacts)
            {
                Console.WriteLine(i);
                Console.WriteLine("-------");
            }

            addressBook.SortByState();
            foreach (Contact i in addressBook.contacts)
            {
                Console.WriteLine(i);
                Console.WriteLine("-------");
            }



            addressBook.contactsMap.Add("Vijay", contact1);
            addressBook.contactsMap.Add("Ajith", contact2);
            addressBook.contactsMap.Add("Surya", contact3);
            addressBook.contactsMap.Add("Divya", contact4);

            foreach (Contact i in addressBook.contacts)
            {
                //i.Print();
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
               // i.Print();
                Console.WriteLine("-------");
            }

        }
    }
}
