using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public class UsersServer : IUsersServer
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();
        private IUsersDao usersDao = new AdoUsersDao(connectionFactory);

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
