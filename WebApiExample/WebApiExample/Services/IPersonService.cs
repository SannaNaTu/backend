using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Services
{
    public interface IPersonService
    {
        //CRUD
        Person Create(Person person);
        List<Person> Read(); //hakee kaiken tiedon listaus
        Person Read(int id); // hakee yksittäisen tiedon,kuormitettu read metodi, 
        //Person Read(string name); 
        Person Update(int id, Person person);
        void Delete(int id); //poisto idn perusteella
    }
}
