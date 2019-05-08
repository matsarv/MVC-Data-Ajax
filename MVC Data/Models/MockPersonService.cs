using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Data.Models
{
    public class MockPersonService : IPersonService
    {
        PersonView pv = new PersonView();

        private int idCount = 6;

        public MockPersonService()
        {
            pv.persons.Add(new Person() { Id = 0, Name = "Nisse Person", Phone = "0731234567", City = "Växjö" });
            pv.persons.Add(new Person() { Id = 1, Name = "Nisse Karlsson", Phone = "0731234567", City = "Växjö" });
            pv.persons.Add(new Person() { Id = 2, Name = "Kalle Nilsson", Phone = "0731234567", City = "Växjö" });
            pv.persons.Add(new Person() { Id = 3, Name = "Kalle Karlsson", Phone = "0731234567", City = "Kalmar" });
            pv.persons.Add(new Person() { Id = 4, Name = "Pelle Nilsson", Phone = "0731234567", City = "Kalmar" });
            pv.persons.Add(new Person() { Id = 5, Name = "Pelle Person", Phone = "0731234567", City = "Lund" });
        }

        public List<Person> AllPersons()
        {
            return pv.persons;
        }

        public Person CreatePerson(string name, string phone, string city)
        {
            Person person = new Person() { Id = idCount, Name = name, Phone = phone, City = city };
            idCount++;
            pv.persons.Add(person);

            return person;
        }

        public bool DeletePerson(int id)
        {

            Person person = pv.persons.SingleOrDefault(x => x.Id == id);

            if (person == null)
            {
                return false;
            }

            return pv.persons.Remove(person);

            //bool wasRemoved = false;

            //foreach (Person item in pv.persons)
            //{
            //    if (item.Id == id)
            //    {
            //        pv.persons.Remove(item);

            //        wasRemoved = true;
            //        break;
            //    }
            //}

            //return wasRemoved;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in pv.persons)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }


        public bool UpdatePerson(Person person)
        {
            bool wasUpdated = false;

            foreach (Person orginal in pv.persons)
            {
                if (orginal.Id == person.Id)
                {
                    orginal.Name = person.Name;
                    orginal.Phone = person.Phone;
                    orginal.City = person.City;

                    wasUpdated = true;
                    break;
                }
            }

            return wasUpdated;
        }

        public List<Person> FilterPersonCity(string searchString)
        {
            var people = pv.persons.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || s.City.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return (people);
        }

        public List<Person> Sort(string sortOrder)
        {
            var people = pv.persons.ToList();

            switch (sortOrder)
            {
                case "name":
                    people = pv.persons.OrderBy(s => s.Name).ToList();
                    break;
                case "name_desc":
                    people = pv.persons.OrderByDescending(s => s.Name).ToList();
                    break;
                case "phone":
                    people = pv.persons.OrderBy(s => s.Phone).ToList();
                    break;
                case "city":
                    people = pv.persons.OrderBy(s => s.City).ToList();
                    break;
                default:
                    people = pv.persons.ToList();
                    break;
            }
          

            return (people);
        }
    }
}
