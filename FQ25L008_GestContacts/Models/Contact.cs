namespace FQ25L008_GestContacts.Models
{
    public class Contact
    {
        public int Id { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }
        public string? Tel { get; }
        public Contact(int id, string nom, string prenom, string email, string? tel)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }
    }
}
