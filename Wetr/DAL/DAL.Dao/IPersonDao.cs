using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface IPersonDao
    {
        IEnumerable<Person> FindAll();
        Person FindById(int id);
        bool Update(Person person);
    }
}
