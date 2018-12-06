
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.DAL.Client
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
                Console.WriteLine($"FindStationByPostalcode({postalcode}) -> " +
                    $"Community: {c.Community,5} | " +
                    $"Postalcode: {c.Postalcode,-10} | " +
                    $"District: {c.District,5} | " +
                    $"Province: {c.Province,-10}");
            else
            {
                Console.WriteLine($"FindStationByPostalcode({postalcode}) -> null");
            }
        }
    }
}
