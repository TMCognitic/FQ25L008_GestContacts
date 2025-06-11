using FQ25L008_GestContacts.Dal.Entities;
using FQ25L008_GestContacts.Dal.Repositories;
using FQ25L008_GestContacts.Models.Forms;
using Microsoft.AspNetCore.Mvc;


namespace FQ25L008_GestContacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Get());
        }

        public IActionResult Details(int id)
        {
            Contact? contact = _repository.Get(id);

            if (contact is null)
            {
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //[HttpGet] // Http Verb Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Http Verb Post
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateContactForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            //Insertion dans la DB
            _repository.Insert(new Contact() { Nom = form.Nom, Prenom = form.Prenom, Email = form.Email, Tel = form.Tel });
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Contact? contact = _repository.Get(id);

            if (contact is null)
            {
                return RedirectToAction("Index");
            }

            UpdateContactForm updateContactForm = new UpdateContactForm()
            {
                Id = contact.Id,
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Email = contact.Email,
                Tel = contact.Tel
            };

            return View(updateContactForm);
        }

        [HttpPost]
        public IActionResult Edit(int id, UpdateContactForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            // Update au niveau de la DB
            _repository.Update(new Contact() { Id = id, Nom = form.Nom, Prenom = form.Prenom, Email = form.Email, Tel = form.Tel });

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Contact? contact = _repository.Get(id);
           
            if (contact is null)
            {
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            _repository.Delete(id);           

            return RedirectToAction("Index");
        }
    }
}
