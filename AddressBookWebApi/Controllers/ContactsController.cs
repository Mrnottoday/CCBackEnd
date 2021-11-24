using AddressBook.Access;
using AddressBook.Access.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepo contactRepo;

        public ContactsController(IContactRepo contactRepo)
        {
            this.contactRepo = contactRepo;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await contactRepo.GetAllContacts();

            return new OkObjectResult(contacts);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await contactRepo.GetById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return new OkObjectResult(contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            await contactRepo.UpdateContact(contact);

            return NoContent();
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            await contactRepo.CreateContact(contact);

            return new OkResult();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await contactRepo.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            await contactRepo.DeleteContact(contact);

            return NoContent();
        }
    }
}
