using BStorm.Tools.Database;
using FQ25L008_GestContacts.Models;
using FQ25L008_GestContacts.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace FQ25L008_GestContacts.Controllers
{
    public class ContactController : Controller
    {
        const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
        public IActionResult Index()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return View(connection.ExecuteReader("SELECT Id, Nom, Prenom, Email, Tel FROM Personne",
                    reader => new Contact((int)reader["Id"], (string)reader["Nom"],
                                (string)reader["Prenom"], (string)reader["Email"],
                                reader["Tel"] as string)).ToList());
            }
        }

        public IActionResult Details(int id)
        {
            Contact? contact;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                contact = connection.ExecuteReader("SELECT Id, Nom, Prenom, Email, Tel FROM Personne WHERE Id = @Id",
                    reader => new Contact((int)reader["Id"], (string)reader["Nom"],
                                (string)reader["Prenom"], (string)reader["Email"],
                                reader["Tel"] as string), parameters: new { id }).SingleOrDefault();
            }

            if(contact is null)
            {
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateContactForm form)
        {
            return View();
        }
    }
}
