using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    class AddressBookRepo
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AddressBookService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAddressBook()
        {
            try
            {
                Contact contact = new Contact();
                using (this.connection)
                {
                    string query = @"Select* from AddressBookTable; ";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contact.firstName = dr.GetString(0);
                            contact.lastName = dr.GetString(1);
                            contact.address = dr.GetString(2);
                            contact.city = dr.GetString(3);
                            contact.state = dr.GetString(4);
                            contact.zip = dr.GetInt32(5).ToString();
                            contact.phoneNumber = dr.GetString(6);
                            contact.email = dr.GetString(7);
                            Console.WriteLine(contact);

                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
