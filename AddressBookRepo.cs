using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    class AddressBookRepo
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AddressBookService;Integrated Security=True";
        public void GetAddressBook()
        {
            try
            {
                Contact contact = new Contact();
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    string query = @"Select* from AddressBookTable; ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
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
                            contact.zip = dr.GetInt32(5);
                            contact.phoneNumber = dr.GetString(6);
                            contact.email = dr.GetString(7);
                            Console.WriteLine(contact);

                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Create(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                string query = "INSERT INTO AddressBookTable (firstName, lastName, address, city, state, zip, phoneNumber, email)" +
                    "VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email)";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = contact.firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = contact.lastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = contact.address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = contact.city;
                cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = contact.state;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = contact.zip;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = contact.phoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = contact.email;
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void Update(String currentFirstName, String newFirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                string query = "UPDATE AddressBookTable SET firstName = @NewFirstName WHERE firstName = @CurrentFirstName";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@NewFirstName", SqlDbType.VarChar).Value = newFirstName;
                cmd.Parameters.Add("@CurrentFirstName", SqlDbType.VarChar).Value = currentFirstName;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Delete(String lastName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                string query = "DELETE FROM AddressBookTable WHERE lastName = @LastName ";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastName;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void GetContacts(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                string query = "SELECT * FROM AddressBookTable WHERE dateAdded >= @FromDate AND dateAdded < @ToDate ";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetString(0));
                       
                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }
                connection.Close();
            }
        }
        public void CountContacts(string city)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                string query = "SELECT COUNT(*) FROM AddressBookTable where city = @City ";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetInt32(0));

                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }
                connection.Close();
            }
        }

    }
    
}
   