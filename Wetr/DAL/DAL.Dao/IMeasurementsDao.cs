using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dao
{
    public interface IMeasurementsDao
    {
        IEnumerable<Measurements> FindAll();
        Measurements FindById(int id);
        bool Update(Measurements measurment);
    }
}
