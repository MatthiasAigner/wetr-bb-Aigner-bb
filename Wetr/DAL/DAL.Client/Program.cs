using DAL.Common;
using DAL.Dao;
using DAL.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Client {

    

    class DALTesterUsers {
        private IUsersDao userDao;

        public DALTesterUsers(IUsersDao userDao) {
            this.userDao = userDao;
        }

        public void TestFindAllUsers() {
            foreach(Users u in userDao.FindAllUsers())
            {
                Console.WriteLine($"{u.Username,5} | {u.Station,-10} ");//| {p.LastName,-15} | {p.DateOfBirth,10:yyyy-MM-dd}");
            }
        }

        public void TestFindUserByUsername(string username) {
            if(userDao.FindUserByUsername(username) != null)
                Console.WriteLine($"FindByName({username}) -> {userDao.FindUserByUsername(username).Username,5} | {userDao.FindUserByUsername(username).Station,-10} ");
            else
            {
                Console.WriteLine($"FindByName({username}) -> null");
            }
        }

        public void TestInsertUser(string username, string station)
        {
            Users user = new Users(username,station);
            userDao.InsertUser(user);
            Console.WriteLine($"InsertUser({username},{station})");
        }

        public void TestDeleteUser(string username)
        {
            userDao.DeleteUser(username);
            Console.WriteLine($"DeleteUser({username})");
        }







        //public void TestTransactions() {
        //    Person person1 = personDao.FindById(1);
        //    Person person2 = personDao.FindById(2);

        //    string oldName1 = person1.LastName;
        //    string oldName2 = person2.LastName;
        //    string newName1 = string.Empty;
        //    string newName2 = string.Empty;

        //    try {
        //        using (TransactionScope scope = new TransactionScope()) {
        //            person1.LastName = newName1 = oldName1 + "-Doe";
        //            person2.LastName = newName2 = oldName2 + "-Doe";
        //            personDao.Update(person1);
        //            // throw new ArgumentException(); // comment this out to rollback transaction
        //            personDao.Update(person2);
        //            scope.Complete();
        //        }
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex);
        //    }

        //    person1 = personDao.FindById(1);
        //    person2 = personDao.FindById(2);

        //    if (oldName1 == person1.LastName && oldName2 == person2.LastName)
        //        Console.WriteLine("Transaction was ROLLED BACK.");
        //    else if (newName1 == person1.LastName && newName2 == person2.LastName)
        //        Console.WriteLine("Transaction was COMMITTED.");
        //    else
        //        Console.WriteLine("No Transaction.");
        //}

        //public async Task TestTransactionsAsync() {
        //    Person person1 = await personDao.FindByIdAsync(1);
        //    Person person2 = await personDao.FindByIdAsync(2);

        //    string oldName1 = person1.LastName;
        //    string oldName2 = person2.LastName;
        //    string newName1 = string.Empty;
        //    string newName2 = string.Empty;

        //    try {
        //        using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
        //            person1.LastName = newName1 = oldName1 + "-Doe";
        //            person2.LastName = newName2 = oldName2 + "-Doe";
        //            await personDao.UpdateAsync(person1);
        //            // throw new ArgumentException(); // comment this out to rollback transaction
        //            await personDao.UpdateAsync(person2);
        //            scope.Complete();
        //        }
        //    } catch (Exception ex) {
        //        Console.WriteLine(ex);
        //    }

        //    person1 = await personDao.FindByIdAsync(1);
        //    person2 = await personDao.FindByIdAsync(2);

        //    if (oldName1 == person1.LastName && oldName2 == person2.LastName)
        //        Console.WriteLine("Transaction was ROLLED BACK.");
        //    else if (newName1 == person1.LastName && newName2 == person2.LastName)
        //        Console.WriteLine("Transaction was COMMITTED.");
        //    else
        //        Console.WriteLine("No Transaction.");
        //}
    }

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
