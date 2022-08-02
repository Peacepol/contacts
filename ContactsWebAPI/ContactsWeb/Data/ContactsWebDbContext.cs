using ContactsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWeb.Data
{
    public class ContactsWebDbContext : DbContext
    {
        public ContactsWebDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
