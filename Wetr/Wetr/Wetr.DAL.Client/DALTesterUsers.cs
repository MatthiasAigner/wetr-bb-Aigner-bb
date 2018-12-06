
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.DAL.Client
{
    class DALTesterUsers
    {
        private IUsersDao userDao;

        public DALTesterUsers(IUsersDao userDao)
        {
            this.userDao = userDao;
        }

        public void TestFindAllUsers()
        {
            foreach (Users u in userDao.FindAllUsers())
            {
                Console.WriteLine($"{u.Username,5} | {u.Station,-10} ");
            }
        }

        public void TestFindUserByUsername(string username)
        {
            Users u = userDao.FindUserByUsername(username);
            if (u != null)
                Console.WriteLine($"FindByName({username}) -> {u.Username,5} | {u.Station,-10} ");
            else
            {
                Console.WriteLine($"FindByName({username}) -> null");
            }
        }

        public void TestInsertUser(Users u)
        {
            userDao.InsertUser(u);
            Console.WriteLine($"InsertUser({u.Username,5} | {u.Station,-10})");
        }

        public void TestDeleteUser(string username)
        {
            userDao.DeleteUser(username);
            Console.WriteLine($"DeleteUser({username})");
        }








    }
}
