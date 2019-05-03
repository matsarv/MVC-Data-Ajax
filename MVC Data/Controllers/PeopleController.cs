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

        // GET
        [HttpGet]
        public IActionResult Index(string searchString)
        {
            PersonView pv = new PersonView();
            //(string.IsNullOrWhiteSpace(searchString)
            if (!String.IsNullOrEmpty(searchString))
            {
                pv.persons = _personService.FilterPersonCity(searchString);
            }
            else
            {
                pv.persons = _personService.AllPersons();
            }
            return View(pv);

        }

        public IActionResult Create(string name, int phone, string city)
        {
            if (name == null || city == null)
            {
                //return RedirectToAction("Index");
                return BadRequest();
            }

            Person person = _personService.CreatePerson(name, phone, city);


            //PersonView pv = new PersonView();
            //pv.persons = _personService.AllPersons();
            //return RedirectToAction("Index");
            //return PartialView("_Person", person);
            //return PartialView("_PersonList", _personService.AllPersons());



            //return PartialView("_PersonList", pv);

            return PartialView("_PersonUpdate", person);
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
                //return RedirectToAction("Index");
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






        //Ajax implementation
        public IActionResult AJAXPartialExample(int id)
        {
            //return PartialView("_Person", _personService.AllPersons());
            return PartialView("_Person", _personService.FindPerson(id));
        }
    }

}

