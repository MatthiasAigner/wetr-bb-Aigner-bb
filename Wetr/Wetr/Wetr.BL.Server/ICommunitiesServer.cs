using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface ICommunitiesServer
    {
        IEnumerable<Communities> FindAllCommunities();
        Communities FindCommunityByPostalcode(int postalcode);
        IEnumerable<Communities> FindCommunitiesByDistrict(string district);
    }
}
