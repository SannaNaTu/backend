using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public interface IPersonRepository // muista lisätä public
    {
        //CRUD
        Person Create(Person person);
        List<Person> Read(); //hakee kaiken tiedon listaus
        Person Read(int id); // hakee yksittäisen tiedon,kuormitettu read metodi, 
        //Person Read(string name); 
        Person Update(Person person);
        void Delete(int id); //poisto idn perusteella



    }
}
