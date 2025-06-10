using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FQ25L008_GestContacts.Models.Forms
{
#nullable disable
    public class CreateContactForm
    {
        [Required]
        [MinLength(1)]
        [DisplayName("Nom : ")]
        public string Nom { get; set; }
        [Required]
        [MinLength(1)]
        [DisplayName("Prénom : ")]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Adresse email : ")]        
        public string Email { get; set; }
        [DisplayName("Téléphone : ")]
        public string Tel { get; set; }
    }
}
