using System;
using Wetr.DAL.Common;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.DAL.Client
{
    class Program
    {
        private static void PrintTitle(string text = "", int length = 60, char ch = '-')
        {
            int preLen = (length - (text.Length + 2)) / 2;
            int postLen = length - (preLen + text.Length + 2);
            Console.WriteLine($"{new String(ch, preLen)} {text} {new String(ch, postLen)}");
        }

        private static void Main()
        {
            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration("WetrDbConnection");
            DALTesterCommunities communityTester = new DALTesterCommunities(new AdoCommunitiesDao(connectionFactory));
            DALTesterMeasurements measurementTester = new DALTesterMeasurements(new AdoMeasurementsDao(connectionFactory));
            DALTesterStations stationTester = new DALTesterStations(new AdoStationsDao(connectionFactory));
            DALTesterUsers userTester = new DALTesterUsers(new AdoUsersDao(connectionFactory));

            //PrintTitle("CommunitiesDao.FindAllCommunities", 50);
            //communityTester.TestFindAllCommunities();

            PrintTitle("CommunitiesDao.FindCommunityByPostalcode", 50);
            communityTester.TestFindCommunityByPostalcode(4040);


            //PrintTitle("MeasurementsDao.FindAllMeasurements", 50);
            //measurementTester.TestFindAllMeasurements();
            
            PrintTitle("MeasurementsDao.InsertMeasurement", 50);
            measurementTester.TestInsertMeasurement(new Measurements("ENNS", DateTime.Now, 20.9, 955.8, 5.5, 56.7, 1.2, "South"));

            PrintTitle("MeasurementsDao.FindMeasurementByStation", 50);
            measurementTester.TestFindAllMeasurementsByStation("ENNS");

            //PrintTitle("MeasurementsDao.FindMeasurementById", 50);
            //measurementTester.TestFindMeasurementById(1);

            //PrintTitle("MeasurementsDao.DeleteMeasurement", 50);
            //measurementTester.TestDeleteMeasurement(1);


            PrintTitle("StationDao.FindAllStations", 50);
            stationTester.TestFindAllStations();

            PrintTitle("StationDao.InsertStation", 50);
            stationTester.TestInsertStation(new Stations("TestStation", "TAWES", 17.2, 46.3, 4040));

            PrintTitle("StationDao.FindStationByName", 50);
            stationTester.TestFindStationByName("TestStation");

            //PrintTitle("StationDao.FindStationById", 50);
            //stationTester.TestFindStationById(1);

            PrintTitle("StationDao.DeleteStation", 50);
            stationTester.TestDeleteStation("TestStation");


            PrintTitle("UsersDao.FindAllUsers", 50);
            userTester.TestFindAllUsers();

            PrintTitle("UsersDao.InsertUser", 50);
            userTester.TestInsertUser(new Users("User999", "Hans", "Lustig", "HansLustig@gmx.at", "ENNS"));

            PrintTitle("UsersDao.FindUserByUsername", 50);
            userTester.TestFindUserByUsername("User999");

            PrintTitle("UsersDao.DeleteUser", 50);
            userTester.TestDeleteUser("User999");

            //InsertALotOfMeasurments();
            Console.ReadKey();
        }

        private static void InsertALotOfMeasurments()
        {
            int[] Array = {3,4,2,5,5,6,3,2,1,0,-2,-3,-4,-5,-4,-3,-2,
                0,2,3,4,5,5,5,6,5,5,6,4,4,5,6,7,6,5,4,5,6,7,7,7,8,8,
                9,9,9,8,6,5,6,7,8,9,9,10,9,8,8,9,10,11,12,12,13,12,12,
                13,14,15,16,17,16,16,16,15,14,15,12, 13,12,11,13,14,
                13,11,12,15,10,14,15,16,17,16,17,17,18,18,19,20,21,15,
                14,15,18,21,22,22,22,16,16,15,14,14,13,15,16,18,19,22,
                23,24,19,18,16,17,21,23,23,23,22,21,24,20,19,18,18,24,
                25,26,24,25,24,25,26,25,25,24,25,26,27,25,27,28,26,27,
                28,29,30,30,29,28,29,25,18,19,18,21,22,22,23,24,25,26,
                29,28,29,30,31,30,32,33,30,25,26,28,30,26,27,28,30,30,
                31,32,29,28,26,25,24,25,26,27,28,29,30,32,31,30,32,33,
                34,30,28,26,25,24,23,22,22,22,23,25,26,27,28,29,30,31,
                30,31,30,32,33,34,35,35,34,30,28,26,25,24,24,25,27,26,
                25,24,27,27,28,29,30,31,32,33,32,30,31,27,24,23,24,25,
                26,28,29,30,32,32,34,35,36,35,30,29,28,25,25,27,28,24,
                25,26,24,23,22,20,20,21,24,25,21,22,23,28,27,18,17,16,
                16,18,20,22,23,25,24,19,18,16,17,18,16,17,19,20,14,14,
                13,12,11,14,15,14,13,12,11,10,9,10,8,7,9,8,9,10,14,13,
                13,9,9,8,9,7,8,9,10,9,7,6,4,7,6,5,3,2,2,3,2,4,3,5,6,4,2,2};

            Random random = new Random();

            for (long i = 0; i < 1000000; i++)
            {
                double offsetTemp = random.NextDouble() * 4 - 2;
                double offsetPressure = random.NextDouble() * 40 - 20;
                double offsetHumidity = random.NextDouble() * 20 - 10;
                int randomDay = random.Next(1, 365);
                int randomHour = random.Next(0, 23);
                int randomMin = random.Next(0, 59);
                int randomSec = random.Next(0, 59);
                DateTime randomDate = new DateTime(2018, 1, 1);
                randomDate = randomDate.AddDays(randomDay);
                randomDate = randomDate.AddHours(randomHour);
                randomDate = randomDate.AddMinutes(randomMin);
                randomDate = randomDate.AddSeconds(randomSec);                
                double airTemp = Math.Round((Array[randomDay - 1] + offsetTemp - Math.Abs(randomDate.Hour - 12.0) * 0.7) , 1);
                double airpressure = Math.Round((970 + offsetPressure) , 1);
                double rainfall = Math.Round((random.NextDouble() * 50 - 25) , 1);
                if (rainfall < 0.0)
                    rainfall = 0.0;
                double humidity = Math.Round((55 + offsetHumidity) , 1);
                double windspeed = Math.Round((random.NextDouble() * 50) , 1);
                int windDirectionRandom = random.Next(1, 8);
                string windDirection = "";
                switch (windDirectionRandom)
                {
                    case 1:
                        windDirection = "North";
                        break;
                    case 2:
                        windDirection = "Northeast";
                        break;
                    case 3:
                        windDirection = "East";
                        break;
                    case 4:
                        windDirection = "Southeast";
                        break;
                    case 5:
                        windDirection = "South";
                        break;
                    case 6:
                        windDirection = "Southwest";
                        break;
                    case 7:
                        windDirection = "West";
                        break;
                    case 8:
                        windDirection = "Northwest";
                        break;
                }
                int randomId = random.Next(1, 120);
                IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration("WetrDbConnection");
                AdoMeasurementsDao measurementDao = new AdoMeasurementsDao(connectionFactory);
                AdoStationsDao stationDao = new AdoStationsDao(connectionFactory);
                Stations randomStation = stationDao.FindStationById(randomId);
                Measurements m = new Measurements(randomStation.Station, randomDate, airTemp, airpressure, rainfall, humidity, windspeed, windDirection);
                measurementDao.InsertMeasurement(m);
            }
        }
    }
}
