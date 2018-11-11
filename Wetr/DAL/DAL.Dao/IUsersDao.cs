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
        IEnumerable<Users> FindAllUsers();
        Users FindUserByUsername(string username);
        bool InsertUser(Users user);
        bool DeleteUser(string username);
    }
}
