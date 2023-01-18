using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblemADO
{
    public  class AddressBookService
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;";
        public string AddContactInDB(AddressBook addressBook)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddNewAddressBook", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", addressBook.First_name);
                    command.Parameters.AddWithValue("@Last_name", addressBook.Last_name);
                    command.Parameters.AddWithValue("@Address", addressBook.Address);
                    command.Parameters.AddWithValue("@City", addressBook.City);
                    command.Parameters.AddWithValue("@State", addressBook.State);
                    command.Parameters.AddWithValue("@Zip", addressBook.Zip);
                    command.Parameters.AddWithValue("@Phone_number", addressBook.Phone_number);
                    command.Parameters.AddWithValue("@Email", addressBook.Email);
                    command.Parameters.AddWithValue("@Type", addressBook.Type);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
                        return "Employee Added Successfully";
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string RetrieveEntriesFromAddressBDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBook> contacts = new List<AddressBook>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBook cont = new AddressBook();
                            cont.First_name = dr.GetString(0);
                            cont.Last_name = dr.GetString(1);
                            cont.Address = dr.GetString(2);
                            cont.City = dr.GetString(3);
                            cont.State = dr.GetString(4);
                            cont.Zip = dr.GetInt32(5);
                            cont.Phone_number = dr.GetInt64(6);
                            cont.Email = dr.GetString(7);
                            cont.Type = dr.GetString(8);

                            contacts.Add(cont);
                        }
                        Console.WriteLine("First Name" + "  " + "Last Name" + "  " + "Address" + "  " + "City" + "  " + "State" + "  " + "Zip" + "  " + "Phone Number" + "  " + "Email" + "  " + "Type");
                        foreach (var data in contacts)
                        {
                            Console.WriteLine(data.First_name + " " + data.Last_name + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.Phone_number + " " + data.Email + " " + data.Type);
                        }
                        return "Retrive Sucessfull";
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string UpdateDataInDatabase(AddressBook addressBook)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", addressBook.First_name);
                    command.Parameters.AddWithValue("@Last_name", addressBook.Last_name);
                    command.Parameters.AddWithValue("@Address", addressBook.Address);
                    command.Parameters.AddWithValue("@Phone_number", addressBook.Phone_number);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Updated Successfully");
                        return "Contact Updated Successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string DeleteDataFromDatabase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", name);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Deleted Successfully");
                        return "Contact Deleted Successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
