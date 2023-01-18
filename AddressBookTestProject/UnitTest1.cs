using AddressBookProblemADO;
namespace AddressBookTestProject
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookService addressBookService = new AddressBookService();
        [TestMethod]
        public void GivenPersonInfo_AbleToAdd()
        {
            AddressBook contact = new AddressBook()
            {
                First_name = "Nilaya",
                Last_name = "Swain",
                Address = "lala",
                City = "DKL",
                State = "Odisha",
                Zip = 759024,
                Phone_number = 9091009090,
                Email = "nilaya@gmail.com",
                Type = "Friend"
            };
            string result = addressBookService.AddContactInDB(contact);
            Assert.AreEqual("Employee Added Successfully", result);
        }
        [TestMethod]
        public void GivenColumnName_AbleToRetriveDataFromDB()
        {
            string result = addressBookService.RetrieveEntriesFromAddressBDB();
            Assert.AreEqual("Retrive Sucessfull", result);
        }
        [TestMethod]
        public void GivenPesonInfo_AbleToUpdateDetailsOfPersonInfoInDB()
        {
            AddressBook contacts = new AddressBook
            {
                First_name = "Papun",
                Last_name = "Nayak",
                Phone_number = 9938001211,
                Address = "Patia",
            };
            string result = addressBookService.UpdateDataInDatabase(contacts);
            Assert.AreEqual("Contact Updated Successfully", result);
        }
        [TestMethod]
        public void GivenPersonName_AbleToDeleteDetailsOfEmployeeInfoInDB()
        {
            string result = addressBookService.DeleteDataFromDatabase("Rohit");
            Assert.AreEqual("Contact Deleted Successfully", result);
        }
    }
}