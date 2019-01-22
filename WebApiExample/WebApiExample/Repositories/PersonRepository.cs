using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public class PersonRepository : IPersonRepository  //punaherjalla, tee automaattiset sudin päältä
    {
        private readonly Task1Context _context; // otetaan yhteys tietokantaan (muutuja <-)

        public PersonRepository(Task1Context _context) //luodaan luokalle konstruktori
        {
            this._context = _context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var deletedPerson = Read(id);
            _context.Person.Remove(deletedPerson);
            _context.SaveChanges();
        }


        public List<Person> Read()
        {
            //SELECT* FROM PERSON;
            //return _context.Person
            //    .Include(p =>p.Phone)
            //    .ToList();
            return _context.Person.FromSql("Select * From Person").ToList();
        

            //SELECT Person.Name FROM Person
            //return _context.Person.FromSql XXXXX
        }

        public Person Read(int id)
        {
            //SELECT* FROM PERSON WHERE ID={id};
            //SELECT PERSON.*,PHONE.*
            //FROM PERSON INNER JOIN PHONE ON PERSON. ID = PHONE.PERSONID
            // WHERE PERSON.ID={id};
            return _context.Person
                .AsNoTracking()
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            //var updatedPerson = Read(Person); TÄMÄ ASIA ON PAREMPI TEHDÄ SERVISE TASOLLA!!!!!!!!!!!!!!
            //if (updatedPerson == null)
            //    throw new Exception("Person not found");
            _context.Person.Update(person);
            _context.SaveChanges();
            return person;
        }
    }
}
