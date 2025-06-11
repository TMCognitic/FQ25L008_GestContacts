using BStorm.Tools.Database;
using FQ25L008_GestContacts.Dal.Entities;
using FQ25L008_GestContacts.Dal.Mappers;
using FQ25L008_GestContacts.Dal.Repositories;
using System.Data.Common;
namespace FQ25L008_GestContacts.Dal.Services
{
    public class ContactService : IContactRepository
    {
        private readonly DbConnection _connection;

        public ContactService(DbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public IEnumerable<Contact> Get()
        {            
            return _connection.ExecuteReader("SELECT Id, Nom, Prenom, Email, Tel FROM Personne",
                record => record.ToContact()).ToList();
           
        }

        public Contact? Get(int id)
        {
            return _connection.ExecuteReader("SELECT Id, Nom, Prenom, Email, Tel FROM Personne WHERE Id = @Id", record => record.ToContact(), parameters: new { id }).SingleOrDefault();
        }

        public int Insert(Contact contact)
        {
            return _connection.ExecuteNonQuery("INSERT INTO PERSONNE (Nom, Prenom, Email, Tel) VALUES (@Nom, @Prenom, @Email, @Tel)", parameters: contact);
        }

        public int Update(Contact contact)
        {
            return _connection.ExecuteNonQuery("UPDATE PERSONNE SET Nom = @Nom, Prenom = @Prenom, Email = @Email, Tel = @Tel WHERE Id = @Id", parameters: contact);
        }

        public int Delete(int id)
        {
            return _connection.ExecuteNonQuery("DELETE FROM Personne WHERE Id = @Id", parameters: new { id });
        }
    }
}
