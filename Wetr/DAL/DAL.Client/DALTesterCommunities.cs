using DAL.Dao;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Client
{
    class DALTesterCommunities
    {
        private ICommunitiesDao communityDao;

        public DALTesterCommunities(ICommunitiesDao communityDao)
        {
            this.communityDao = communityDao;
        }

        public void TestFindAllCommunities()
        {
            foreach (Communities c in communityDao.FindAllCommunities())
            {
                Console.WriteLine($"Community: {c.Community,5} | " +
                    $"Postalcode: {c.Postalcode,-10} | " +
                    $"District: {c.District,5} | " +
                    $"Province: {c.Province,-10}");
            }
        }

        public void TestFindCommunityByPostalcode(int postalcode)
        {
            Communities c = communityDao.FindCommunityByPostalcode(postalcode);
            if (c != null)
                Console.WriteLine($"FindStationByName({postalcode}) -> " +
                    $"Community: {c.Community,5} | " +
                    $"Postalcode: {c.Postalcode,-10} | " +
                    $"District: {c.District,5} | " +
                    $"Province: {c.Province,-10}");
            else
            {
                Console.WriteLine($"FindStationByName({postalcode}) -> null");
            }
        }        
    }
}
