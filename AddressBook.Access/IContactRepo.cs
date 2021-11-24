using AddressBook.Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Access
{
    public interface IContactRepo
    {
        Task<IEnumerable<Contact>> GetAllContacts();

        Task<Contact> GetById(int id);

        Task CreateContact(Contact contact);

        Task UpdateContact(Contact contact);

        Task DeleteContact(Contact contact);
    }
}
