using BStorm.Tools.Database;
using FQ25L008_GestContacts.Models.Forms;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace FQ25L008_GestContacts.Infrastructure.Validations
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string email)
            {
                return new ValidationResult("Ceci n'est pas une chaine de caractère");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                return new ValidationResult("L'email n'est pas définie...");
            }

            switch (validationContext.ObjectInstance)
            {
                case CreateContactForm createForm:
                    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                    {
                        connection.Open();

                        int count = (int)connection.ExecuteScalar("SELECT COUNT(*) FROM Personne WHERE Email = @Email", parameters: new { email = (string)value! })!;

                        if (count > 0)
                        {
                            return new ValidationResult("Cet email existe déjà");
                        }

                        return ValidationResult.Success;
                    }                   
                case UpdateContactForm updateForm:
                    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                    {
                        connection.Open();

                        int count = (int)connection.ExecuteScalar("SELECT COUNT(*) FROM Personne WHERE Email = @Email AND Id != @Id", parameters: new { email = (string)value!, updateForm.Id })!;

                        if (count > 0)
                        {
                            return new ValidationResult("Cet email existe déjà");
                        }

                        return ValidationResult.Success;
                    }
                    
                default:                   
                    return new ValidationResult($"Not implemented for {validationContext.ObjectInstance.GetType().Name}");
            }
        }
    }
}
