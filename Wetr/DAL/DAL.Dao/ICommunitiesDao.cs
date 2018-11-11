using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface ICommunitiesDao
    {
        IEnumerable<Communities> FindAllCommunities();
        Communities FindCommunityByPostalcode(int postalcode);
    }
}
