using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PerfumeryStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name {  get; set; }= string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        
        public Customer() 
        { 
        }

        public Customer(int id, string name, string phoneNumber, string emailAddress, Gender gender)
        {
            Id = id;
            Name=name;
            PhoneNumber=phoneNumber;
            EmailAddress = emailAddress;
            Gender=gender;
        }
    }
}

