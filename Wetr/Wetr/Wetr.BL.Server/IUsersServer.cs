using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IUsersServer
    {
        IEnumerable<Users> FindAllUsers();
        Users FindUserByUsername(string username);
        bool InsertUser(Users user);
        bool DeleteUser(string username);
    }
} 
