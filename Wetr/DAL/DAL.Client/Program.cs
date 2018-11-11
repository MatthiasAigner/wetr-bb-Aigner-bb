using DAL.Common;
using DAL.Dao;
using DAL.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Client {

    static class Extensions {
        public static string ToStringOrNull<T>(this T value) {
            return value == null ? "<null>" : value.ToString();
        }
    }

    class DALTester {
        private IUsersDao userDao;

        public DALTester(IUsersDao userDao) {
            this.userDao = userDao;
        }

        public void TestFindAll() {
            foreach(Users u in userDao.FindAll())
            {
                Console.WriteLine($"{u.Username,5} | {u.Station,-10} ");//| {p.LastName,-15} | {p.DateOfBirth,10:yyyy-MM-dd}");

            }
        }

        public void TestFindByName(string username) {
            //Users user1 = personDao.FindById(1);
            //Console.WriteLine($"FindByName({username}) -> {userDao.FindByName(username).ToStringOrNull()}");
            if(userDao.FindByName(username) != null)
                Console.WriteLine($"FindByName({username}) -> {userDao.FindByName(username).Username,5} | {userDao.FindByName(username).Station,-10} ");
            else
            {
                Console.WriteLine($"FindByName({username}) -> null");
            }
            //Person person2 = personDao.FindById(99);
            //Console.WriteLine($"FindById(99) -> {person2.ToStringOrNull()}");
        }

        //public void TestUpdate() {
        //    Person person = personDao.FindById(1);
        //    Console.WriteLine($"before update: person -> {person.ToStringOrNull()}");
        //    person.DateOfBirth = DateTime.Now.AddYears(-100);
        //    personDao.Update(person);

        //    person = personDao.FindById(1);
        //    Console.WriteLine($"after update:  person -> {person.ToStringOrNull()}");
        //}







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

            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration("PersonDbConnection"); //gehört noch umbenannt
            DALTester tester2 = new DALTester(new AdoUsersDao(connectionFactory));

            

            PrintTitle("UsersDao.FindAll", 50);
            tester2.TestFindAll();

            PrintTitle("UsersDao.FindByName", 50);
            tester2.TestFindByName("Use2");

            PrintTitle("UsersDao.FindByName", 50);
            tester2.TestFindByName("User2");

            //PrintTitle("PersonDao.Update", 50);
            //tester2.TestUpdate();

            PrintTitle("Transactions", 50);
            //tester2.TestTransactions();

            Console.ReadKey();
        }
    }
}
