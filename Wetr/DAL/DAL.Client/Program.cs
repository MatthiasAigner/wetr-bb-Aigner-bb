using DAL.Common;
using DAL.Dao;
using DAL.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Client {

    

    

    class Program {
        private static void PrintTitle(string text = "", int length = 60, char ch = '-') {
            int preLen = (length - (text.Length + 2)) / 2;
            int postLen = length - (preLen + text.Length + 2);
            Console.WriteLine($"{new String(ch, preLen)} {text} {new String(ch, postLen)}");
        }

        private static void /* async Task */ Main() {
            //
            // Concrete top level components should only be created in one place.
            // Usually a container is responsible for that.
            // Here we create the component tree in the main programm.
            //

            //DALTester tester1 = new DALTester(new SimplePersonDao());

            //PrintTitle("PersonDaoSimple.FindAll", 50);
            //tester1.TestFindAll();

            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration("WetrDbConnection");
            DALTesterUsers userTester = new DALTesterUsers(new AdoUsersDao(connectionFactory));

            

            PrintTitle("UsersDao.FindAll", 50);
            userTester.TestFindAllUsers();

            PrintTitle("UsersDao.InsertUser", 50);
            userTester.TestInsertUser("User999", "ENNS");

            PrintTitle("UsersDao.FindUserByUsername", 50);
            userTester.TestFindUserByUsername("User999");

            PrintTitle("UsersDao.DeleteUser", 50);
            userTester.TestDeleteUser("User999");


            Console.ReadKey();
        }
    }
}
