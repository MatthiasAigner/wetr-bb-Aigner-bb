using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;
using Wetr.DAL.Dao;

namespace Wetr.BL.Server
{
    class CommunitiesServer : ICommunitiesServer
    {
        private ICommunitiesDao communityDao;

        public IEnumerable<Communities> FindAllCommunities()
        {
            return communityDao.FindAllCommunities();
        }

        public IEnumerable<Communities> FindCommunitiesByDistrict(string district)
        {
            return communityDao.FindCommunitiesByDistrict(district);
        }

        public Communities FindCommunityByPostalcode(int postalcode)
        {
            return communityDao.FindCommunityByPostalcode(postalcode);
        }
    }
}
