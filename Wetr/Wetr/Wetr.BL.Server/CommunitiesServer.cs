using System.Collections.Generic;
using Wetr.Domainclasses;
using Wetr.DAL.Dao;
using Wetr.DAL.Common;

namespace Wetr.BL.Server
{
    public class CommunitiesServer : ICommunitiesServer
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();
        private ICommunitiesDao communityDao = new AdoCommunitiesDao(connectionFactory);

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
