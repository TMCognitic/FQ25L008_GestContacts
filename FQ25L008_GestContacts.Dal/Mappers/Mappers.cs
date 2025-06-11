using FQ25L008_GestContacts.Dal.Entities;
using System.Data;

namespace FQ25L008_GestContacts.Dal.Mappers
{
    internal static class Mappers
    {
        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                Email = (string)record["Email"],
                Tel = record["Tel"] as string,
            };
        }
    }
}
