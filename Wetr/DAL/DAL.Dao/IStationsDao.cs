using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface IStationsDao
    {
        IEnumerable<Stations> FindAll();
        Stations FindByName(string station);
        bool Update(Stations station);
    }
}
