using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Services
{
    public class PersonService : IPersonService // IPersonService = punaherjalla hiiren oikea ja automaagiset metodit luokalle (implement interface) ja PersonServicestä konstruktorit
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

       

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _personRepository.Read();
        }

        public Person Read(int id)
        {
            return _personRepository.Read(id);
        }

        public Person Update(int id, Person person)
        {
            var savedPerson = _personRepository.Read(id);
            if (savedPerson == null)
                throw new Exception("Person not found!");
            
                return _personRepository.Update(person);
            
        }
    }
}
