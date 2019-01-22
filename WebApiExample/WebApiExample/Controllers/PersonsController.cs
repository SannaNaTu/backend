using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository _personRepository)
        {
            this._personRepository = _personRepository;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            //var users = new List<Person>
            //{

            //    new Person("James",45),
            //    new Person("Lissu",34),
            //  };
            var persons = _personRepository.Read();
            return new JsonResult(persons);
        }

        // GET api/persons/5 HAKU
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personRepository.Read(id);
            return new JsonResult(person);
        }
        // POST : api/Persons
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personRepository.Create(person);
            return new JsonResult(newPerson);
        }

        // PUT:api/Persons/5 (joku luku)
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, Person person)
        {
            var updatePerson = _personRepository.Update(person);
            return updatePerson;
        }
        // DELETE : api/Persons/

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personRepository.Delete(id);
            return new NoContentResult();

          
        }



    }
}