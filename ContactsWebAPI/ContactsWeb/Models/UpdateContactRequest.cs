namespace ContactsWeb.Models
{
    public class UpdateContactRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public long MobileNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
