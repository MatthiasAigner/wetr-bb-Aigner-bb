using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    class UsersServer : IUsersServer
    {
        private IUsersDao usersDao;

        public bool DeleteUser(string username)
        {
            return usersDao.DeleteUser(username);
        }

        public IEnumerable<Users> FindAllUsers()
        {
            return usersDao.FindAllUsers();
        }

        public Users FindUserByUsername(string username)
        {
            return usersDao.FindUserByUsername(username);
        }

        public bool InsertUser(Users user)
        {
            return usersDao.InsertUser(user);
        }
    }
}
