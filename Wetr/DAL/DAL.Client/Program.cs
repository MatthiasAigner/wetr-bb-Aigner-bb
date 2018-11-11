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

        private static void Main() {            

            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration("WetrDbConnection");
            DALTesterCommunities communityTester = new DALTesterCommunities(new AdoCommunitiesDao(connectionFactory));
            DALTesterMeasurements measurementTester = new DALTesterMeasurements(new AdoMeasurementsDao(connectionFactory));
            DALTesterStations stationTester = new DALTesterStations(new AdoStationsDao(connectionFactory));
            DALTesterUsers userTester = new DALTesterUsers(new AdoUsersDao(connectionFactory));

            PrintTitle("CommunitiesDao.FindAllCommunities", 50);
            //communityTester.TestFindAllCommunities();

            PrintTitle("CommunitiesDao.FindCommunityByPostalcode", 50);
            //communityTester.TestFindCommunityByPostalcode(4040);


            PrintTitle("MeasurementsDao.FindAllMeasurements", 50);
            //measurementTester.TestFindAllMeasurements();

            PrintTitle("MeasurementsDao.InsertMeasurement", 50);
            measurementTester.TestInsertMeasurement(new Measurements("ENNS",20.0, 995.4, 0.0, 50.6, 1.2, "SouthEast", DateTime.Now));

            PrintTitle("MeasurementsDao.FindMeasurementByStation", 50);
            //measurementTester.TestFindAllMeasurementsByStation("ENNS");

            PrintTitle("MeasurementsDao.FindMeasurementById", 50);
            //measurementTester.TestFindMeasurementById(1);

            PrintTitle("MeasurementsDao.DeleteMeasurement", 50);
            //measurementTester.TestDeleteMeasurement(1);


            PrintTitle("StationDao.FindAllStations", 50);
            //stationTester.TestFindAllStations();

            PrintTitle("StationDao.InsertStation", 50);
            //stationTester.TestInsertStation(new Stations("TestStation", "Typ1", 17.2, 46.3, 4040));

            PrintTitle("StationDao.FindStationByName", 50);
            //stationTester.TestFindStationByName("TestStation");

            PrintTitle("StationDao.DeleteStation", 50);
            //stationTester.TestDeleteStation("TestStation");


            PrintTitle("UsersDao.FindAllUsers", 50);
            userTester.TestFindAllUsers();

            PrintTitle("UsersDao.InsertUser", 50);
            userTester.TestInsertUser(new Users("User999", "ENNS"));

            PrintTitle("UsersDao.FindUserByUsername", 50);
            userTester.TestFindUserByUsername("User999");

            PrintTitle("UsersDao.DeleteUser", 50);
            userTester.TestDeleteUser("User999");


            Console.ReadKey();
        }
    }
}
