namespace AddressBookProblemADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookService addressBookService = new AddressBookService();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the option : \n 1.AddContactInDB\n 2.RetrieveEntriesFromAddressBDB\n 3.UpdateDataInDatabase\n 4.DeleteDataFromDatabase");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddressBook contact = new AddressBook()
                        {
                            First_name = "Manit",
                            Last_name = "Nayak",
                            Address = "Jiral",
                            City = "DKL",
                            State = "Odisha",
                            Zip = 759024,
                            Phone_number = 9090909090,
                            Email = "manit@gmail.com",
                            Type = "Family"
                        };
                        addressBookService.AddContactInDB(contact);
                        break;
                    case 2:
                        addressBookService.RetrieveEntriesFromAddressBDB();
                        break;
                    case 3:
                        AddressBook contacts = new AddressBook
                        {
                            First_name = "Papun",
                            Last_name = "Bana",
                            Phone_number = 9938101112,
                            Address = "Jiral",
                            

                        };
                        addressBookService.UpdateDataInDatabase(contacts);
                        break;
                    case 4:
                        addressBookService.DeleteDataFromDatabase("Akanksha");
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}