using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Data.Models;

namespace MVC_Data.Controllers
{
    public class PeopleController : Controller
    {

        IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        //(string.IsNullOrWhiteSpace(searchString)

        // GET
        [HttpGet]
        //public IActionResult Index(string searchString)
        public IActionResult Index()

        {
            //(string.IsNullOrWhiteSpace(searchString)

            PersonView pv = new PersonView();

            pv.persons = _personService.AllPersons();

            return View(pv);
        }


        [HttpPost]
        public IActionResult Filter(string filter)
        {
            PersonView pv = new PersonView();

            if (String.IsNullOrWhiteSpace(filter))
            {
                pv.persons = _personService.AllPersons();

                return PartialView("_PersonList", pv);
            }
            else
            {
                pv.persons = _personService.FilterPersonCity(filter);

                return PartialView("_PersonList", pv);
            }
        }

        [HttpPost]
        public IActionResult Sort(string sortOrder)
        {

            PersonView pv = new PersonView();

            pv.persons = _personService.Sort(sortOrder);

            return PartialView("_PersonList", pv);
        }


        [HttpPost]
        public IActionResult Create(string name, string phone, string city)
        {
            PersonView pv = new PersonView();

            //if (name == null || phone == null || city == null)
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(city))
            {
                pv.persons = _personService.AllPersons();

                return PartialView("_PersonList", pv);
            }

            Person person = _personService.CreatePerson(name, phone, city);

            pv.persons = _personService.AllPersons();

            return PartialView("_PersonList", pv);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return BadRequest();
            }

            return PartialView("_PersonConfirmEdit", person);
        }

        // POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ConfirmEdit([Bind("Id,Name,Phone,City")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);

                return PartialView("_PersonUpdate", person);

            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return BadRequest();
            }

            return PartialView("_PersonConfirmDelete", person);


            //if (id == null)
            //{
            //    return RedirectToAction("Index");
            //}

            //Person person = _personService.FindPerson((int)id);

            //if (person == null)
            //{
            //    return RedirectToAction("Index");
            //}

            //_personService.DeletePerson((int)id);

            //return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, int itemId)
        {
            if (id == itemId)
            {
                if (_personService.DeletePerson((int)id))
                {
                    return Content("");
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult ConfirmCancel(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return BadRequest();
            }

            return PartialView("_PersonUpdate", person);

        }

    }
}

