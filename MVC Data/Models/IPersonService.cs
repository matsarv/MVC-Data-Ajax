using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public interface IPersonService
    {

        //Create
        Person CreatePerson(string name, int phone, string city);

        //Read All
        List<Person> AllPersons();

        //Read One
        Person FindPerson(int id);

        // ----- Read Filter 
        List<Person> FilterPersonCity(string searchString);

        //Update
        bool UpdatePerson(Person person);

        //Delete
        bool DeletePerson(int id);

    }
}
