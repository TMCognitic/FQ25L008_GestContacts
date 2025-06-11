using FQ25L008_GestContacts.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQ25L008_GestContacts.Dal.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact? Get(int id);
        int Insert(Contact contact);
        int Update(Contact contact);
        int Delete(int id);
    }
}
