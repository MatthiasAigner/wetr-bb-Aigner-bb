using DAL.Dao;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Client
{
    class DALTesterStations
    {
        private IUsersDao userDao;

        public DALTesterStations(IUsersDao userDao)
        {
            this.userDao = userDao;
        }

        public void TestFindAllUsers()
        {
            foreach (Users u in userDao.FindAllUsers())
            {
                Console.WriteLine($"{u.Username,5} | {u.Station,-10} ");//| {p.LastName,-15} | {p.DateOfBirth,10:yyyy-MM-dd}");
            }
        }

        public void TestFindUserByUsername(string username)
        {
            if (userDao.FindUserByUsername(username) != null)
                Console.WriteLine($"FindByName({username}) -> {userDao.FindUserByUsername(username).Username,5} | {userDao.FindUserByUsername(username).Station,-10} ");
            else
            {
                Console.WriteLine($"FindByName({username}) -> null");
            }
        }

        public void TestInsertUser(string username, string station)
        {
            Users user = new Users(username, station);
            userDao.InsertUser(user);
            Console.WriteLine($"InsertUser({username},{station})");
        }

        public void TestDeleteUser(string username)
        {
            userDao.DeleteUser(username);
            Console.WriteLine($"DeleteUser({username})");
        }








    }
}
