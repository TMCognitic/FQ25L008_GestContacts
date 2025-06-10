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
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
        [DisplayName("Adresse email : ")]        
        public string Email { get; set; }
        [DisplayName("Téléphone : ")]
        public string Tel { get; set; }
    }
}
