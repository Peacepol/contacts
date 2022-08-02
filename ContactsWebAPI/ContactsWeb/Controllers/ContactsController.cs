using ContactsWeb.Data;
using ContactsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsWebDbContext dbContext;
        public ContactsController(ContactsWebDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(dbContext.Contacts.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContact)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = addContact.FirstName,
                LastName = addContact.LastName,
                CompanyName = addContact.CompanyName,
                MobileNumber = addContact.MobileNumber,
                EmailAddress = addContact.EmailAddress,
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContact)
        {
            var contact =await dbContext.Contacts.FindAsync(id);
            if(contact!= null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.MobileNumber = updateContact.MobileNumber;
                contact.CompanyName = updateContact.CompanyName;
                contact.EmailAddress = updateContact.EmailAddress;
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbContext.Contacts.Remove(contact);
                dbContext.SaveChanges();
                return Ok(contact);
            }
            return NotFound();
            
        }
    }
}
