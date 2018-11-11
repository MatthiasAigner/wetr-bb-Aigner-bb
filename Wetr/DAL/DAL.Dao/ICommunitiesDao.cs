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
        IEnumerable<Communities> FindAll();
        Communities FindByPostalcode(int postalcode);
        bool Update(Communities community);
    }
}
