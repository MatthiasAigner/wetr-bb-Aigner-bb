using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;

namespace DAL.Dao
{
    public class SimplePersonDao : IPersonDao
    {
        private static readonly IList<Person> personList = new List<Person>
        {
            new Person { Id=1, FirstName="John", LastName="Doe",        DateOfBirth=DateTime.Now.AddYears(-10) },
            new Person { Id=2, FirstName="Jane", LastName="Doe",        DateOfBirth=DateTime.Now.AddYears(-20) },
            new Person { Id=3, FirstName="Max",  LastName="Mustermann", DateOfBirth=DateTime.Now.AddYears(-30) }
        };

        public IEnumerable<Person> FindAll()
        {
            return personList;
        }

        public Person FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
