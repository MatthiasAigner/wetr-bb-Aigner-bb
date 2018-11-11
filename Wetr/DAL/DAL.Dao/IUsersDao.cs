using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface IUsersDao
    {
        IEnumerable<Users> FindAll();
        Users FindByName(string user);
        bool Update(Users user);
    }
}
