namespace ContactsWeb.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public long MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
