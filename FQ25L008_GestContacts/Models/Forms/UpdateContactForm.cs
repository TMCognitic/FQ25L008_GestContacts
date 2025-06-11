using FQ25L008_GestContacts.Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FQ25L008_GestContacts.Models.Forms
{
    public class UpdateContactForm
    {
        [HiddenInput]
        public int Id { get; set; }

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
        [UniqueEmail]
        [DisplayName("Adresse email : ")]
        public string Email { get; set; }
        [DisplayName("Téléphone : ")]
        public string? Tel { get; set; }
    }
}
